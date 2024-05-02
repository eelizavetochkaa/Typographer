﻿using System.Text.RegularExpressions;

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
            /* 1 кавычки, запятые итп*/
            string formattedText = Regex.Replace(inputdata.Text, @"\s+([.,;:!?])", "$1 ");
            formattedText = Regex.Replace(formattedText, @"([.,;:!?])\s+", "$1 ");
            formattedText = Regex.Replace(formattedText, @"\s+(\(|\)|\'\{|\}|\[|\]|\"")", "$1");
            formattedText = Regex.Replace(formattedText, @"(\s|^)-|-(\s|$)", "$1$2");

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

            outputdata.Text = formattedText;
            
        }
    }
}
