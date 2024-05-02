namespace Typographer
{
    partial class Typographer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            inputdata = new TextBox();
            outputdata = new Label();
            copy = new Button();
            delete = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Soledago", 49.8000031F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(103, 50, 18);
            label1.Location = new Point(733, 47);
            label1.Name = "label1";
            label1.Size = new Size(463, 109);
            label1.TabIndex = 0;
            label1.Text = "Типограф";
            // 
            // inputdata
            // 
            inputdata.BackColor = Color.AntiqueWhite;
            inputdata.Font = new Font("Cambria", 15F, FontStyle.Regular, GraphicsUnit.Point, 204);
            inputdata.ForeColor = Color.SaddleBrown;
            inputdata.Location = new Point(102, 183);
            inputdata.Multiline = true;
            inputdata.Name = "inputdata";
            inputdata.Size = new Size(737, 739);
            inputdata.TabIndex = 1;
            inputdata.TextChanged += inputdata_TextChanged;
            // 
            // outputdata
            // 
            outputdata.BackColor = Color.AntiqueWhite;
            outputdata.Font = new Font("Cambria", 15F, FontStyle.Regular, GraphicsUnit.Point, 204);
            outputdata.ForeColor = Color.SaddleBrown;
            outputdata.Location = new Point(1063, 183);
            outputdata.Name = "outputdata";
            outputdata.Size = new Size(737, 739);
            outputdata.TabIndex = 2;
            // 
            // copy
            // 
            copy.BackColor = Color.AntiqueWhite;
            copy.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            copy.ForeColor = Color.SaddleBrown;
            copy.Location = new Point(1608, 925);
            copy.Name = "copy";
            copy.Size = new Size(192, 39);
            copy.TabIndex = 3;
            copy.Text = "Скопировать текст";
            copy.UseVisualStyleBackColor = false;
            copy.Click += copy_Click;
            // 
            // delete
            // 
            delete.BackColor = Color.AntiqueWhite;
            delete.Font = new Font("Cambria", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            delete.ForeColor = Color.SaddleBrown;
            delete.Location = new Point(647, 928);
            delete.Name = "delete";
            delete.Size = new Size(192, 39);
            delete.TabIndex = 4;
            delete.Text = "Стереть всё";
            delete.UseVisualStyleBackColor = false;
            // 
            // Typographer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.BurlyWood;
            ClientSize = new Size(1924, 1033);
            Controls.Add(delete);
            Controls.Add(copy);
            Controls.Add(outputdata);
            Controls.Add(inputdata);
            Controls.Add(label1);
            Name = "Typographer";
            Text = "Типограф";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox inputdata;
        private Label outputdata;
        private Button copy;
        private Button delete;
    }
}
