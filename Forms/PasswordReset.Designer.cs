namespace EcoCalc_Plus
{
    partial class PasswordReset
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
            sendResetButton = new Krypton.Toolkit.KryptonButton();
            emailLabel = new Krypton.Toolkit.KryptonLabel();
            emailTextBox = new TextBox();
            cancelButton = new Krypton.Toolkit.KryptonButton();
            SuspendLayout();
            // 
            // sendResetButton
            // 
            sendResetButton.Location = new Point(137, 398);
            sendResetButton.Name = "sendResetButton";
            sendResetButton.Size = new Size(188, 54);
            sendResetButton.StateCommon.Back.Color1 = Color.Lime;
            sendResetButton.StateCommon.Content.ShortText.Font = new Font("Minecraft", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sendResetButton.StateNormal.Back.Color1 = Color.Lime;
            sendResetButton.StatePressed.Back.Color1 = Color.Yellow;
            sendResetButton.TabIndex = 0;
            sendResetButton.Values.DropDownArrowColor = Color.Empty;
            sendResetButton.Values.Text = "RESET PASS";
            sendResetButton.Click += sendResetButton_Click;
            // 
            // emailLabel
            // 
            emailLabel.Location = new Point(35, 171);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(255, 33);
            emailLabel.StateCommon.ShortText.Color1 = Color.White;
            emailLabel.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailLabel.TabIndex = 1;
            emailLabel.Values.Text = "Enter your email:";
            // 
            // emailTextBox
            // 
            emailTextBox.Font = new Font("Minecraft", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailTextBox.Location = new Point(35, 210);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(671, 40);
            emailTextBox.TabIndex = 2;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(410, 398);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(188, 54);
            cancelButton.StateCommon.Back.Color1 = Color.Red;
            cancelButton.StateCommon.Content.ShortText.Font = new Font("Minecraft", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelButton.StateNormal.Back.Color1 = Color.Red;
            cancelButton.StatePressed.Back.Color1 = Color.Yellow;
            cancelButton.TabIndex = 3;
            cancelButton.Values.DropDownArrowColor = Color.Empty;
            cancelButton.Values.Text = "CANCEL";
            cancelButton.Click += cancelButton_Click;
            // 
            // PasswordReset
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            Controls.Add(cancelButton);
            Controls.Add(emailTextBox);
            Controls.Add(emailLabel);
            Controls.Add(sendResetButton);
            Name = "PasswordReset";
            Size = new Size(741, 500);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonButton sendResetButton;
        private Krypton.Toolkit.KryptonLabel emailLabel;
        private TextBox emailTextBox;
        private Krypton.Toolkit.KryptonButton cancelButton;
    }
}
