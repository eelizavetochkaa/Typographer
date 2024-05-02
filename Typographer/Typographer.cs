using System.Text.RegularExpressions;

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
            /* 1 */
            string formattedText = Regex.Replace(inputdata.Text, @"\s+([.,;:!?])", "$1 ");
            formattedText = Regex.Replace(formattedText, @"([.,;:!?])\s+", "$1 ");
            formattedText = Regex.Replace(formattedText, @"\s+(\(|\)|\'\{|\}|\[|\]|\"")", "$1");
            formattedText = Regex.Replace(formattedText, @"(\s|^)-|-(\s|$)", "$1$2");
            formattedText = Regex.Replace(formattedText, @"'\s+", "'");
            formattedText = Regex.Replace(formattedText, @"\s+'", "'");
            formattedText = Regex.Replace(formattedText, "\"\\s*", "\"");
            formattedText = Regex.Replace(formattedText, "\\s*\"", "\"");
            /* 2 */
            formattedText = Regex.Replace(formattedText, @"\s+", " ");
            /* 9 */
            outputdata.Text = formattedText;
        }
    }
}
