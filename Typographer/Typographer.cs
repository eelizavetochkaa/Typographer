using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Typographer
{
    public partial class Typographer : Form
    {
        public Typographer()
        {
            InitializeComponent();
        }

        private void copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(outputdata.Text);
            MessageBox.Show("Текст скопирован в буфер обмена!");
        }
        private void inputdata_TextChanged(object sender, EventArgs e)
        {
            /* 1 ??? кавычки, запятые итп*/
            string formattedText = Regex.Replace(inputdata.Text, @"\s+([.,;:!?])", "$1 ");
            formattedText = Regex.Replace(formattedText, @"([.,;:!?])\s+", "$1 ");
            formattedText = Regex.Replace(formattedText, @"\s+(\(|\)|\'\{|\}|\[|\]|\"")", "$1");
            /*formattedText = Regex.Replace(formattedText, @"(\s|^)-|-(\s|$)", "$1$2");*/

            bool incavychky = false;
            for (int i = 0; i < formattedText.Length; i++)
            {
                if (formattedText[i] == '"')
                {
                    incavychky = !incavychky;
                    if (incavychky)
                    {
                        int spacesToRemove = 0;
                        while (i + 1 < formattedText.Length && formattedText[i + 1] == ' ')
                        {
                            spacesToRemove++;
                            i++;
                        }
                        if (spacesToRemove > 0)
                        {
                            formattedText = formattedText.Remove(i - spacesToRemove + 1, spacesToRemove);
                            i -= spacesToRemove;
                        }
                    }
                }
            }
            bool inonecavychky = false;
            for (int i = 0; i < formattedText.Length; i++)
            {
                if (formattedText[i] == '\'')
                {
                    inonecavychky = !inonecavychky;
                    if (inonecavychky)
                    {
                        int spacesToRemove = 0;
                        while (i + 1 < formattedText.Length && formattedText[i + 1] == ' ')
                        {
                            spacesToRemove++;
                            i++;
                        }
                        if (spacesToRemove > 0)
                        {
                            formattedText = formattedText.Remove(i - spacesToRemove + 1, spacesToRemove);
                            i -= spacesToRemove;
                        }
                    }
                }
            }

            /* 2 нельзя писать больше 1 пробела*/
            formattedText = Regex.Replace(formattedText, @"\s+", " ");

            /* 3 заменять на ёлочки*/
            int openedcavychky = 0;
            for (int i = 0; i < formattedText.Length; i++)
            {
                if (formattedText[i] == '"')
                {
                    if (openedcavychky % 2 == 0)
                    {
                        formattedText = formattedText.Remove(i, 1).Insert(i, " «");

                    }
                    else
                    {
                        formattedText = formattedText.Remove(i, 1).Insert(i, "» ");
                    }
                    openedcavychky++;
                }
            }
            for (int i = 0; i < formattedText.Length; i++)
            {
                if (formattedText[i] == '\'')
                {
                    if (openedcavychky % 2 == 0)
                    {
                        formattedText = formattedText.Remove(i, 1).Insert(i, " «");

                    }
                    else
                    {
                        formattedText = formattedText.Remove(i, 1).Insert(i, "» ");
                    }
                    openedcavychky++;
                }
            }
            /*9*/
            formattedText = Regex.Replace(formattedText, @"\+-", "±");

            /* моё правило 1: первые буквы предложений заглавные */
            if (!string.IsNullOrEmpty(formattedText))
            {
                /*13*/
                formattedText = Regex.Replace(formattedText, @"\.{3}", "…");

                string[] sentences = Regex.Split(formattedText, @"(?<=[.!?])\s+");

                for (int i = 0; i < sentences.Length; i++)
                {
                    if (!string.IsNullOrEmpty(sentences[i]))
                    {
                        sentences[i] = sentences[i].Trim();
                        char firstChar = char.ToUpper(sentences[i][0]);
                        string restOfString = sentences[i].Substring(1);
                        sentences[i] = firstChar + restOfString;
                    }
                }

                formattedText = string.Join(" ", sentences);
            }

            /*моё правило 2 */


            /*мой абсурд*/
            formattedText = Regex.Replace(formattedText, "о", "♥", RegexOptions.IgnoreCase);
            formattedText = Regex.Replace(formattedText, "o", "♥", RegexOptions.IgnoreCase);


            outputdata.Text = formattedText;
        }
        private void delete_Click(object sender, EventArgs e)
        {
            inputdata.Text = string.Empty;
        }
    }
}
