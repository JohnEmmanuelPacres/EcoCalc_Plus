namespace EcoCalc_Plus
{
    partial class UserProfile
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
            userPanel = new Krypton.Toolkit.KryptonPanel();
            unitLbl2 = new Krypton.Toolkit.KryptonLabel();
            unitComboBox = new ComboBox();
            unitLbl = new Krypton.Toolkit.KryptonLabel();
            mascotPic = new Krypton.Toolkit.KryptonPictureBox();
            exitBtn = new PictureBox();
            userIDLbl = new Krypton.Toolkit.KryptonLabel();
            idLbl = new Krypton.Toolkit.KryptonLabel();
            deleteAccBtn = new PictureBox();
            updateAccBtn = new PictureBox();
            userLbl = new Krypton.Toolkit.KryptonLabel();
            overallAveVal = new Krypton.Toolkit.KryptonLabel();
            aveVehicleVal = new Krypton.Toolkit.KryptonLabel();
            aveHEVal = new Krypton.Toolkit.KryptonLabel();
            aveAppliancesVal = new Krypton.Toolkit.KryptonLabel();
            aveWasteVal = new Krypton.Toolkit.KryptonLabel();
            overallTotalVal = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            aveHELbl = new Krypton.Toolkit.KryptonLabel();
            aveAppLbl = new Krypton.Toolkit.KryptonLabel();
            aveWasteLbl = new Krypton.Toolkit.KryptonLabel();
            overallEmissionLbl = new Krypton.Toolkit.KryptonLabel();
            aveVehicularLbl = new Krypton.Toolkit.KryptonLabel();
            usernameLbl = new Krypton.Toolkit.KryptonLabel();
            updatePanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)userPanel).BeginInit();
            userPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mascotPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exitBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deleteAccBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)updateAccBtn).BeginInit();
            SuspendLayout();
            // 
            // userPanel
            // 
            userPanel.Controls.Add(unitLbl2);
            userPanel.Controls.Add(unitComboBox);
            userPanel.Controls.Add(unitLbl);
            userPanel.Controls.Add(mascotPic);
            userPanel.Controls.Add(exitBtn);
            userPanel.Controls.Add(userIDLbl);
            userPanel.Controls.Add(idLbl);
            userPanel.Controls.Add(deleteAccBtn);
            userPanel.Controls.Add(updateAccBtn);
            userPanel.Controls.Add(userLbl);
            userPanel.Controls.Add(overallAveVal);
            userPanel.Controls.Add(aveVehicleVal);
            userPanel.Controls.Add(aveHEVal);
            userPanel.Controls.Add(aveAppliancesVal);
            userPanel.Controls.Add(aveWasteVal);
            userPanel.Controls.Add(overallTotalVal);
            userPanel.Controls.Add(kryptonLabel1);
            userPanel.Controls.Add(aveHELbl);
            userPanel.Controls.Add(aveAppLbl);
            userPanel.Controls.Add(aveWasteLbl);
            userPanel.Controls.Add(overallEmissionLbl);
            userPanel.Controls.Add(aveVehicularLbl);
            userPanel.Controls.Add(usernameLbl);
            userPanel.Location = new Point(17, 18);
            userPanel.Name = "userPanel";
            userPanel.Size = new Size(1132, 577);
            userPanel.StateCommon.Color1 = Color.Gainsboro;
            userPanel.TabIndex = 48;
            // 
            // unitLbl2
            // 
            unitLbl2.Location = new Point(447, 120);
            unitLbl2.Name = "unitLbl2";
            unitLbl2.Size = new Size(69, 35);
            unitLbl2.StateCommon.ShortText.Color2 = Color.Gainsboro;
            unitLbl2.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            unitLbl2.TabIndex = 71;
            unitLbl2.Values.Text = "CO₂";
            // 
            // unitComboBox
            // 
            unitComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            unitComboBox.Font = new Font("Minecraft", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            unitComboBox.FormattingEnabled = true;
            unitComboBox.Items.AddRange(new object[] { "Pounds", "Metric Tons" });
            unitComboBox.Location = new Point(253, 120);
            unitComboBox.Name = "unitComboBox";
            unitComboBox.Size = new Size(188, 31);
            unitComboBox.TabIndex = 70;
            unitComboBox.SelectedIndexChanged += unitComboBox_SelectedIndexChanged;
            // 
            // unitLbl
            // 
            unitLbl.Location = new Point(165, 122);
            unitLbl.Name = "unitLbl";
            unitLbl.Size = new Size(77, 33);
            unitLbl.StateCommon.ShortText.Color2 = Color.Gainsboro;
            unitLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            unitLbl.TabIndex = 68;
            unitLbl.Values.Text = "Unit:";
            // 
            // mascotPic
            // 
            mascotPic.Image = Properties.Resources.sprite_rawbot;
            mascotPic.Location = new Point(772, 157);
            mascotPic.Name = "mascotPic";
            mascotPic.Size = new Size(297, 266);
            mascotPic.SizeMode = PictureBoxSizeMode.StretchImage;
            mascotPic.TabIndex = 67;
            mascotPic.TabStop = false;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = Color.Gainsboro;
            exitBtn.Image = Properties.Resources.sprite_exitBtn;
            exitBtn.Location = new Point(3, 3);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(120, 120);
            exitBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            exitBtn.TabIndex = 66;
            exitBtn.TabStop = false;
            exitBtn.Click += exitBtn_Click;
            exitBtn.MouseEnter += exitBtn_MouseEnter;
            exitBtn.MouseLeave += exitBtn_MouseLeave;
            // 
            // userIDLbl
            // 
            userIDLbl.Location = new Point(511, 64);
            userIDLbl.Name = "userIDLbl";
            userIDLbl.Size = new Size(46, 33);
            userIDLbl.StateCommon.ShortText.Color2 = Color.Gainsboro;
            userIDLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userIDLbl.TabIndex = 65;
            userIDLbl.Values.Text = "ID";
            // 
            // idLbl
            // 
            idLbl.Location = new Point(302, 64);
            idLbl.Name = "idLbl";
            idLbl.Size = new Size(46, 33);
            idLbl.StateCommon.ShortText.Color2 = Color.Gainsboro;
            idLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            idLbl.TabIndex = 64;
            idLbl.Values.Text = "ID";
            // 
            // deleteAccBtn
            // 
            deleteAccBtn.Image = Properties.Resources.sprite_deleteAcc;
            deleteAccBtn.Location = new Point(772, 464);
            deleteAccBtn.Name = "deleteAccBtn";
            deleteAccBtn.Size = new Size(297, 88);
            deleteAccBtn.TabIndex = 63;
            deleteAccBtn.TabStop = false;
            deleteAccBtn.Click += deleteAccBtn_Click;
            deleteAccBtn.MouseEnter += deleteAccBtn_MouseEnter;
            deleteAccBtn.MouseLeave += deleteAccBtn_MouseLeave;
            // 
            // updateAccBtn
            // 
            updateAccBtn.Image = Properties.Resources.sprite_updateAcc;
            updateAccBtn.Location = new Point(56, 464);
            updateAccBtn.Name = "updateAccBtn";
            updateAccBtn.Size = new Size(297, 88);
            updateAccBtn.TabIndex = 62;
            updateAccBtn.TabStop = false;
            updateAccBtn.Click += updateAccBtn_Click;
            updateAccBtn.MouseEnter += updateAccBtn_MouseEnter;
            updateAccBtn.MouseLeave += updateAccBtn_MouseLeave;
            // 
            // userLbl
            // 
            userLbl.Location = new Point(511, 25);
            userLbl.Name = "userLbl";
            userLbl.Size = new Size(159, 33);
            userLbl.StateCommon.ShortText.Color2 = Color.Gainsboro;
            userLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userLbl.TabIndex = 61;
            userLbl.Values.Text = "Username";
            // 
            // overallAveVal
            // 
            overallAveVal.Location = new Point(600, 390);
            overallAveVal.Name = "overallAveVal";
            overallAveVal.Size = new Size(70, 33);
            overallAveVal.StateCommon.ShortText.Color2 = Color.Gainsboro;
            overallAveVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            overallAveVal.TabIndex = 60;
            overallAveVal.Values.Text = "0.00";
            // 
            // aveVehicleVal
            // 
            aveVehicleVal.Location = new Point(600, 175);
            aveVehicleVal.Name = "aveVehicleVal";
            aveVehicleVal.Size = new Size(70, 33);
            aveVehicleVal.StateCommon.ShortText.Color2 = Color.Gainsboro;
            aveVehicleVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveVehicleVal.TabIndex = 59;
            aveVehicleVal.Values.Text = "0.00";
            // 
            // aveHEVal
            // 
            aveHEVal.Location = new Point(600, 214);
            aveHEVal.Name = "aveHEVal";
            aveHEVal.Size = new Size(70, 33);
            aveHEVal.StateCommon.ShortText.Color2 = Color.Gainsboro;
            aveHEVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveHEVal.TabIndex = 58;
            aveHEVal.Values.Text = "0.00";
            // 
            // aveAppliancesVal
            // 
            aveAppliancesVal.Location = new Point(600, 253);
            aveAppliancesVal.Name = "aveAppliancesVal";
            aveAppliancesVal.Size = new Size(70, 33);
            aveAppliancesVal.StateCommon.ShortText.Color2 = Color.Gainsboro;
            aveAppliancesVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveAppliancesVal.TabIndex = 57;
            aveAppliancesVal.Values.Text = "0.00";
            // 
            // aveWasteVal
            // 
            aveWasteVal.Location = new Point(600, 292);
            aveWasteVal.Name = "aveWasteVal";
            aveWasteVal.Size = new Size(70, 33);
            aveWasteVal.StateCommon.ShortText.Color2 = Color.Gainsboro;
            aveWasteVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveWasteVal.TabIndex = 56;
            aveWasteVal.Values.Text = "0.00";
            // 
            // overallTotalVal
            // 
            overallTotalVal.Location = new Point(600, 351);
            overallTotalVal.Name = "overallTotalVal";
            overallTotalVal.Size = new Size(70, 33);
            overallTotalVal.StateCommon.ShortText.Color2 = Color.Gainsboro;
            overallTotalVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            overallTotalVal.TabIndex = 55;
            overallTotalVal.Values.Text = "0.00";
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(189, 351);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(327, 33);
            kryptonLabel1.StateCommon.ShortText.Color2 = Color.Gainsboro;
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            kryptonLabel1.TabIndex = 54;
            kryptonLabel1.Values.Text = "Overall Total Emission";
            // 
            // aveHELbl
            // 
            aveHELbl.Location = new Point(56, 214);
            aveHELbl.Name = "aveHELbl";
            aveHELbl.Size = new Size(460, 33);
            aveHELbl.StateCommon.ShortText.Color2 = Color.Gainsboro;
            aveHELbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveHELbl.TabIndex = 53;
            aveHELbl.Values.Text = "Average Home Energy Emission";
            // 
            // aveAppLbl
            // 
            aveAppLbl.Location = new Point(94, 253);
            aveAppLbl.Name = "aveAppLbl";
            aveAppLbl.Size = new Size(422, 33);
            aveAppLbl.StateCommon.ShortText.Color2 = Color.Gainsboro;
            aveAppLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveAppLbl.TabIndex = 52;
            aveAppLbl.Values.Text = "Average Appliances Emission";
            // 
            // aveWasteLbl
            // 
            aveWasteLbl.Location = new Point(165, 292);
            aveWasteLbl.Name = "aveWasteLbl";
            aveWasteLbl.Size = new Size(351, 33);
            aveWasteLbl.StateCommon.ShortText.Color2 = Color.Gainsboro;
            aveWasteLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveWasteLbl.TabIndex = 51;
            aveWasteLbl.Values.Text = "Average Waste Emission";
            // 
            // overallEmissionLbl
            // 
            overallEmissionLbl.Location = new Point(141, 390);
            overallEmissionLbl.Name = "overallEmissionLbl";
            overallEmissionLbl.Size = new Size(375, 33);
            overallEmissionLbl.StateCommon.ShortText.Color2 = Color.Gainsboro;
            overallEmissionLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            overallEmissionLbl.TabIndex = 50;
            overallEmissionLbl.Values.Text = "Overall Average Emission";
            // 
            // aveVehicularLbl
            // 
            aveVehicularLbl.Location = new Point(114, 175);
            aveVehicularLbl.Name = "aveVehicularLbl";
            aveVehicularLbl.Size = new Size(402, 33);
            aveVehicularLbl.StateCommon.ShortText.Color2 = Color.Gainsboro;
            aveVehicularLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveVehicularLbl.TabIndex = 49;
            aveVehicularLbl.Values.Text = "Average Vehicular Emission";
            // 
            // usernameLbl
            // 
            usernameLbl.Location = new Point(189, 25);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(159, 33);
            usernameLbl.StateCommon.ShortText.Color2 = Color.Gainsboro;
            usernameLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameLbl.TabIndex = 48;
            usernameLbl.Values.Text = "Username";
            // 
            // updatePanel
            // 
            updatePanel.Dock = DockStyle.Fill;
            updatePanel.Location = new Point(0, 0);
            updatePanel.Name = "updatePanel";
            updatePanel.Size = new Size(1171, 612);
            updatePanel.TabIndex = 67;
            // 
            // UserProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            Controls.Add(userPanel);
            Controls.Add(updatePanel);
            Name = "UserProfile";
            Size = new Size(1171, 612);
            ((System.ComponentModel.ISupportInitialize)userPanel).EndInit();
            userPanel.ResumeLayout(false);
            userPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mascotPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)exitBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)deleteAccBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)updateAccBtn).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel userPanel;
        private PictureBox deleteAccBtn;
        private PictureBox updateAccBtn;
        private Krypton.Toolkit.KryptonLabel userLbl;
        private Krypton.Toolkit.KryptonLabel overallAveVal;
        private Krypton.Toolkit.KryptonLabel aveVehicleVal;
        private Krypton.Toolkit.KryptonLabel aveHEVal;
        private Krypton.Toolkit.KryptonLabel aveAppliancesVal;
        private Krypton.Toolkit.KryptonLabel aveWasteVal;
        private Krypton.Toolkit.KryptonLabel overallTotalVal;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel aveHELbl;
        private Krypton.Toolkit.KryptonLabel aveAppLbl;
        private Krypton.Toolkit.KryptonLabel aveWasteLbl;
        private Krypton.Toolkit.KryptonLabel overallEmissionLbl;
        private Krypton.Toolkit.KryptonLabel aveVehicularLbl;
        private Krypton.Toolkit.KryptonLabel usernameLbl;
        private Krypton.Toolkit.KryptonLabel idLbl;
        private Krypton.Toolkit.KryptonLabel userIDLbl;
        private PictureBox exitBtn;
        private Panel updatePanel;
        private Krypton.Toolkit.KryptonPictureBox mascotPic;
        private Krypton.Toolkit.KryptonLabel unitLbl;
        private ComboBox unitComboBox;
        private Krypton.Toolkit.KryptonLabel unitLbl2;
    }
}
