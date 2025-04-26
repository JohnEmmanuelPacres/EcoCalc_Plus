namespace EcoCalc_Plus
{
    partial class CustomLogInMessageBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            kryptonPictureBox1 = new Krypton.Toolkit.KryptonPictureBox();
            OKBtn = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)kryptonPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // kryptonPictureBox1
            // 
            kryptonPictureBox1.Dock = DockStyle.Fill;
            kryptonPictureBox1.Image = Properties.Resources.backdrop_customLogInBorder;
            kryptonPictureBox1.Location = new Point(0, 0);
            kryptonPictureBox1.Name = "kryptonPictureBox1";
            kryptonPictureBox1.Size = new Size(1025, 742);
            kryptonPictureBox1.TabIndex = 1;
            kryptonPictureBox1.TabStop = false;
            // 
            // OKBtn
            // 
            OKBtn.Location = new Point(400, 620);
            OKBtn.Name = "OKBtn";
            OKBtn.Size = new Size(206, 79);
            OKBtn.StateCommon.Back.Color1 = Color.FromArgb(192, 255, 192);
            OKBtn.StateCommon.Back.Color2 = Color.Green;
            OKBtn.StateCommon.Content.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OKBtn.TabIndex = 2;
            OKBtn.Values.DropDownArrowColor = Color.Empty;
            OKBtn.Values.Text = "OK";
            OKBtn.Click += OKBtn_Click;
            // 
            // CustomLogInMessageBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(OKBtn);
            Controls.Add(kryptonPictureBox1);
            Name = "CustomLogInMessageBox";
            Size = new Size(1025, 742);
            Load += CustomLogInMessageBox_Load;
            ((System.ComponentModel.ISupportInitialize)kryptonPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Krypton.Toolkit.KryptonPictureBox kryptonPictureBox1;
        private Krypton.Toolkit.KryptonButton OKBtn;
    }
}
