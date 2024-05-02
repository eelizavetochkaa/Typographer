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
            outputdata.Text = inputdata.Text;
        }
    }
}
