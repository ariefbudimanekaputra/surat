namespace Surat
{
    partial class FormKlasifikasiSuratEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonEditJenisSurat = new DevComponents.DotNetBar.ButtonX();
            this.buttonEditJenisSuratKembali = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX1.Location = new System.Drawing.Point(12, 41);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(337, 26);
            this.textBoxX1.TabIndex = 0;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(13, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(103, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Edit Jenis Surat";
            // 
            // buttonEditJenisSurat
            // 
            this.buttonEditJenisSurat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonEditJenisSurat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonEditJenisSurat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditJenisSurat.Location = new System.Drawing.Point(13, 83);
            this.buttonEditJenisSurat.Name = "buttonEditJenisSurat";
            this.buttonEditJenisSurat.Size = new System.Drawing.Size(122, 43);
            this.buttonEditJenisSurat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonEditJenisSurat.TabIndex = 2;
            this.buttonEditJenisSurat.Text = "Edit Data";
            // 
            // buttonEditJenisSuratKembali
            // 
            this.buttonEditJenisSuratKembali.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonEditJenisSuratKembali.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonEditJenisSuratKembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditJenisSuratKembali.Location = new System.Drawing.Point(227, 83);
            this.buttonEditJenisSuratKembali.Name = "buttonEditJenisSuratKembali";
            this.buttonEditJenisSuratKembali.Size = new System.Drawing.Size(122, 43);
            this.buttonEditJenisSuratKembali.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonEditJenisSuratKembali.TabIndex = 3;
            this.buttonEditJenisSuratKembali.Text = "Kembali";
            // 
            // FormKlasifikasiSuratEdit
            // 
            this.ClientSize = new System.Drawing.Size(361, 142);
            this.Controls.Add(this.buttonEditJenisSuratKembali);
            this.Controls.Add(this.buttonEditJenisSurat);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.textBoxX1);
            this.DoubleBuffered = true;
            this.Name = "FormKlasifikasiSuratEdit";
            this.Text = "Edit Jenis Surat";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonEditJenisSurat;
        private DevComponents.DotNetBar.ButtonX buttonEditJenisSuratKembali;
    }
}