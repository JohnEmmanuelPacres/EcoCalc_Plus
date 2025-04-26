namespace EcoCalc_Plus
{
    partial class EditFootprintForm
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
            vehicleTxt = new Krypton.Toolkit.KryptonTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            homeEnergyTxt = new Krypton.Toolkit.KryptonTextBox();
            applianceTxt = new Krypton.Toolkit.KryptonTextBox();
            wasteTxt = new Krypton.Toolkit.KryptonTextBox();
            saveBtn = new Krypton.Toolkit.KryptonButton();
            cancelBtn = new Krypton.Toolkit.KryptonButton();
            SuspendLayout();
            // 
            // vehicleTxt
            // 
            vehicleTxt.Location = new Point(460, 94);
            vehicleTxt.Name = "vehicleTxt";
            vehicleTxt.Size = new Size(241, 37);
            vehicleTxt.StateCommon.Content.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            vehicleTxt.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            label1.Location = new Point(117, 103);
            label1.Name = "label1";
            label1.Size = new Size(318, 28);
            label1.TabIndex = 1;
            label1.Text = "New Vehicle Emission";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            label2.Location = new Point(23, 155);
            label2.Name = "label2";
            label2.Size = new Size(412, 28);
            label2.TabIndex = 2;
            label2.Text = "New Home Energy Emission";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            label3.Location = new Point(61, 204);
            label3.Name = "label3";
            label3.Size = new Size(374, 28);
            label3.TabIndex = 3;
            label3.Text = "New Appliances Emission";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            label4.Location = new Point(136, 253);
            label4.Name = "label4";
            label4.Size = new Size(299, 28);
            label4.TabIndex = 4;
            label4.Text = "New Waste Emission";
            // 
            // homeEnergyTxt
            // 
            homeEnergyTxt.Location = new Point(460, 146);
            homeEnergyTxt.Name = "homeEnergyTxt";
            homeEnergyTxt.Size = new Size(241, 37);
            homeEnergyTxt.StateCommon.Content.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            homeEnergyTxt.TabIndex = 5;
            // 
            // applianceTxt
            // 
            applianceTxt.Location = new Point(460, 195);
            applianceTxt.Name = "applianceTxt";
            applianceTxt.Size = new Size(241, 37);
            applianceTxt.StateCommon.Content.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            applianceTxt.TabIndex = 6;
            // 
            // wasteTxt
            // 
            wasteTxt.Location = new Point(460, 244);
            wasteTxt.Name = "wasteTxt";
            wasteTxt.Size = new Size(241, 37);
            wasteTxt.StateCommon.Content.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            wasteTxt.TabIndex = 7;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(205, 364);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(154, 74);
            saveBtn.StateCommon.Back.Color1 = Color.Bisque;
            saveBtn.StateCommon.Back.Color2 = Color.Yellow;
            saveBtn.StateCommon.Content.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            saveBtn.TabIndex = 8;
            saveBtn.Values.DropDownArrowColor = Color.Empty;
            saveBtn.Values.Text = "SAVE";
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(441, 364);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(154, 74);
            cancelBtn.StateCommon.Back.Color1 = Color.Bisque;
            cancelBtn.StateCommon.Back.Color2 = Color.Yellow;
            cancelBtn.StateCommon.Content.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            cancelBtn.TabIndex = 9;
            cancelBtn.Values.DropDownArrowColor = Color.Empty;
            cancelBtn.Values.Text = "CANCEL";
            cancelBtn.Click += cancelBtn_Click;
            // 
            // EditFootprintForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            Controls.Add(cancelBtn);
            Controls.Add(saveBtn);
            Controls.Add(wasteTxt);
            Controls.Add(applianceTxt);
            Controls.Add(homeEnergyTxt);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(vehicleTxt);
            Name = "EditFootprintForm";
            Size = new Size(800, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox vehicleTxt;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Krypton.Toolkit.KryptonTextBox homeEnergyTxt;
        private Krypton.Toolkit.KryptonTextBox applianceTxt;
        private Krypton.Toolkit.KryptonTextBox wasteTxt;
        private Krypton.Toolkit.KryptonButton saveBtn;
        private Krypton.Toolkit.KryptonButton cancelBtn;
    }
}