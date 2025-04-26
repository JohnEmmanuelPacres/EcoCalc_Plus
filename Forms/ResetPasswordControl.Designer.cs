namespace EcoCalc_Plus
{
    partial class ResetPasswordControl
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
            cancelButton = new Krypton.Toolkit.KryptonButton();
            confirmTextBox = new TextBox();
            confirmLabel = new Krypton.Toolkit.KryptonLabel();
            resetButton = new Krypton.Toolkit.KryptonButton();
            newPasswordTextBox = new TextBox();
            newPasswordLabel = new Krypton.Toolkit.KryptonLabel();
            tokenTextBox = new TextBox();
            tokenLabel = new Krypton.Toolkit.KryptonLabel();
            newPassVisibleBtn = new PictureBox();
            newPassInvisibleBtn = new PictureBox();
            confirmPassVisibleBtn = new PictureBox();
            confirmPassInvisibleBtn = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)newPassVisibleBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)newPassInvisibleBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)confirmPassVisibleBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)confirmPassInvisibleBtn).BeginInit();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(383, 398);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(188, 54);
            cancelButton.StateCommon.Back.Color1 = Color.Red;
            cancelButton.StateCommon.Content.ShortText.Font = new Font("Minecraft", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelButton.StateNormal.Back.Color1 = Color.Red;
            cancelButton.StatePressed.Back.Color1 = Color.Yellow;
            cancelButton.TabIndex = 7;
            cancelButton.Values.DropDownArrowColor = Color.Empty;
            cancelButton.Values.Text = "CANCEL";
            // 
            // confirmTextBox
            // 
            confirmTextBox.Font = new Font("Minecraft", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirmTextBox.Location = new Point(33, 286);
            confirmTextBox.Name = "confirmTextBox";
            confirmTextBox.Size = new Size(628, 40);
            confirmTextBox.TabIndex = 6;
            // 
            // confirmLabel
            // 
            confirmLabel.Location = new Point(33, 247);
            confirmLabel.Name = "confirmLabel";
            confirmLabel.Size = new Size(276, 33);
            confirmLabel.StateCommon.ShortText.Color1 = Color.White;
            confirmLabel.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirmLabel.TabIndex = 5;
            confirmLabel.Values.Text = "Confirm password";
            // 
            // resetButton
            // 
            resetButton.Location = new Point(137, 398);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(188, 54);
            resetButton.StateCommon.Back.Color1 = Color.Lime;
            resetButton.StateCommon.Content.ShortText.Font = new Font("Minecraft", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resetButton.StateNormal.Back.Color1 = Color.Lime;
            resetButton.StatePressed.Back.Color1 = Color.Yellow;
            resetButton.TabIndex = 4;
            resetButton.Values.DropDownArrowColor = Color.Empty;
            resetButton.Values.Text = "RESET PASS";
            // 
            // newPasswordTextBox
            // 
            newPasswordTextBox.Font = new Font("Minecraft", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            newPasswordTextBox.Location = new Point(33, 192);
            newPasswordTextBox.Name = "newPasswordTextBox";
            newPasswordTextBox.Size = new Size(628, 40);
            newPasswordTextBox.TabIndex = 9;
            // 
            // newPasswordLabel
            // 
            newPasswordLabel.Location = new Point(33, 153);
            newPasswordLabel.Name = "newPasswordLabel";
            newPasswordLabel.Size = new Size(214, 33);
            newPasswordLabel.StateCommon.ShortText.Color1 = Color.White;
            newPasswordLabel.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            newPasswordLabel.TabIndex = 8;
            newPasswordLabel.Values.Text = "New password";
            // 
            // tokenTextBox
            // 
            tokenTextBox.Font = new Font("Minecraft", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tokenTextBox.Location = new Point(33, 93);
            tokenTextBox.Name = "tokenTextBox";
            tokenTextBox.Size = new Size(671, 40);
            tokenTextBox.TabIndex = 10;
            // 
            // tokenLabel
            // 
            tokenLabel.Location = new Point(33, 54);
            tokenLabel.Name = "tokenLabel";
            tokenLabel.Size = new Size(102, 33);
            tokenLabel.StateCommon.ShortText.Color1 = Color.White;
            tokenLabel.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tokenLabel.TabIndex = 11;
            tokenLabel.Values.Text = "Token";
            // 
            // newPassVisibleBtn
            // 
            newPassVisibleBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            newPassVisibleBtn.BackColor = Color.DarkSeaGreen;
            newPassVisibleBtn.Image = Properties.Resources.sprite_visible;
            newPassVisibleBtn.Location = new Point(667, 192);
            newPassVisibleBtn.Name = "newPassVisibleBtn";
            newPassVisibleBtn.Size = new Size(37, 40);
            newPassVisibleBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            newPassVisibleBtn.TabIndex = 16;
            newPassVisibleBtn.TabStop = false;
            newPassVisibleBtn.Click += newPassVisibleBtn_Click;
            // 
            // newPassInvisibleBtn
            // 
            newPassInvisibleBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            newPassInvisibleBtn.BackColor = Color.DarkSeaGreen;
            newPassInvisibleBtn.Image = Properties.Resources.sprite_invisible;
            newPassInvisibleBtn.Location = new Point(667, 192);
            newPassInvisibleBtn.Name = "newPassInvisibleBtn";
            newPassInvisibleBtn.Size = new Size(37, 40);
            newPassInvisibleBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            newPassInvisibleBtn.TabIndex = 15;
            newPassInvisibleBtn.TabStop = false;
            newPassInvisibleBtn.Click += newPassInvisibleBtn_Click;
            // 
            // confirmPassVisibleBtn
            // 
            confirmPassVisibleBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            confirmPassVisibleBtn.BackColor = Color.DarkSeaGreen;
            confirmPassVisibleBtn.Image = Properties.Resources.sprite_visible;
            confirmPassVisibleBtn.Location = new Point(667, 286);
            confirmPassVisibleBtn.Name = "confirmPassVisibleBtn";
            confirmPassVisibleBtn.Size = new Size(37, 40);
            confirmPassVisibleBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            confirmPassVisibleBtn.TabIndex = 18;
            confirmPassVisibleBtn.TabStop = false;
            confirmPassVisibleBtn.Click += confirmPassVisibleBtn_Click;
            // 
            // confirmPassInvisibleBtn
            // 
            confirmPassInvisibleBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            confirmPassInvisibleBtn.BackColor = Color.DarkSeaGreen;
            confirmPassInvisibleBtn.Image = Properties.Resources.sprite_invisible;
            confirmPassInvisibleBtn.Location = new Point(667, 286);
            confirmPassInvisibleBtn.Name = "confirmPassInvisibleBtn";
            confirmPassInvisibleBtn.Size = new Size(37, 40);
            confirmPassInvisibleBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            confirmPassInvisibleBtn.TabIndex = 17;
            confirmPassInvisibleBtn.TabStop = false;
            confirmPassInvisibleBtn.Click += confirmPassInvisibleBtn_Click;
            // 
            // ResetPasswordControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            Controls.Add(confirmPassVisibleBtn);
            Controls.Add(confirmPassInvisibleBtn);
            Controls.Add(newPassVisibleBtn);
            Controls.Add(newPassInvisibleBtn);
            Controls.Add(tokenLabel);
            Controls.Add(tokenTextBox);
            Controls.Add(newPasswordTextBox);
            Controls.Add(newPasswordLabel);
            Controls.Add(cancelButton);
            Controls.Add(confirmTextBox);
            Controls.Add(confirmLabel);
            Controls.Add(resetButton);
            Name = "ResetPasswordControl";
            Size = new Size(741, 500);
            ((System.ComponentModel.ISupportInitialize)newPassVisibleBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)newPassInvisibleBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)confirmPassVisibleBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)confirmPassInvisibleBtn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonButton cancelButton;
        private TextBox confirmTextBox;
        private Krypton.Toolkit.KryptonLabel confirmLabel;
        private Krypton.Toolkit.KryptonButton resetButton;
        private TextBox newPasswordTextBox;
        private Krypton.Toolkit.KryptonLabel newPasswordLabel;
        private TextBox tokenTextBox;
        private Krypton.Toolkit.KryptonLabel tokenLabel;
        private PictureBox newPassVisibleBtn;
        private PictureBox newPassInvisibleBtn;
        private PictureBox confirmPassVisibleBtn;
        private PictureBox confirmPassInvisibleBtn;
    }
}
