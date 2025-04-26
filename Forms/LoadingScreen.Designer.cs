namespace EcoCalc_Plus
{
    partial class LoadingScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingScreen));
            loadBG = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            earthSpin = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)loadBG).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)earthSpin).BeginInit();
            SuspendLayout();
            // 
            // loadBG
            // 
            loadBG.Dock = DockStyle.Fill;
            loadBG.Image = Properties.Resources.backdrop_loading;
            loadBG.Location = new Point(0, 0);
            loadBG.Name = "loadBG";
            loadBG.Size = new Size(581, 298);
            loadBG.SizeMode = PictureBoxSizeMode.StretchImage;
            loadBG.TabIndex = 0;
            loadBG.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(loadBG);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(581, 298);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(earthSpin);
            panel2.Location = new Point(170, 22);
            panel2.Name = "panel2";
            panel2.Size = new Size(210, 174);
            panel2.TabIndex = 1;
            // 
            // earthSpin
            // 
            earthSpin.Dock = DockStyle.Fill;
            earthSpin.Image = Properties.Resources.sprite_earth;
            earthSpin.Location = new Point(0, 0);
            earthSpin.Name = "earthSpin";
            earthSpin.Size = new Size(210, 174);
            earthSpin.SizeMode = PictureBoxSizeMode.StretchImage;
            earthSpin.TabIndex = 0;
            earthSpin.TabStop = false;
            // 
            // LoadingScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateBlue;
            ClientSize = new Size(581, 298);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoadingScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loading";
            ((System.ComponentModel.ISupportInitialize)loadBG).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)earthSpin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox loadBG;
        private Panel panel1;
        private Panel panel2;
        private PictureBox earthSpin;
    }
}