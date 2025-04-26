namespace EcoCalc_Plus
{
    partial class CarbonFootprintMap
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
            exitBtn = new PictureBox();
            mapView = new Microsoft.Web.WebView2.WinForms.WebView2();
            labelsPanel = new Krypton.Toolkit.KryptonPanel();
            totalCarbonValPounds = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            userLbl = new Krypton.Toolkit.KryptonLabel();
            totalCarbonVal = new Krypton.Toolkit.KryptonLabel();
            totalCarbonLbl = new Krypton.Toolkit.KryptonLabel();
            openGrid = new PictureBox();
            globalFootprintData = new Krypton.Toolkit.KryptonDataGridView();
            closeGrid = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)exitBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mapView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)labelsPanel).BeginInit();
            labelsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)openGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)globalFootprintData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closeGrid).BeginInit();
            SuspendLayout();
            // 
            // exitBtn
            // 
            exitBtn.BackColor = Color.FromArgb(0, 22, 25);
            exitBtn.Image = Properties.Resources.sprite_exitBtn;
            exitBtn.Location = new Point(25, 15);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(125, 118);
            exitBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            exitBtn.TabIndex = 0;
            exitBtn.TabStop = false;
            exitBtn.Click += exitBtn_Click;
            exitBtn.MouseEnter += exitBtn_MouseEnter;
            exitBtn.MouseLeave += exitBtn_MouseLeave;
            // 
            // mapView
            // 
            mapView.AllowExternalDrop = true;
            mapView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mapView.CreationProperties = null;
            mapView.DefaultBackgroundColor = Color.White;
            mapView.Location = new Point(6, 3);
            mapView.Name = "mapView";
            mapView.Size = new Size(1893, 1027);
            mapView.TabIndex = 1;
            mapView.ZoomFactor = 1D;
            mapView.Click += mapView_Click;
            // 
            // labelsPanel
            // 
            labelsPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelsPanel.Controls.Add(totalCarbonValPounds);
            labelsPanel.Controls.Add(kryptonLabel2);
            labelsPanel.Controls.Add(userLbl);
            labelsPanel.Controls.Add(totalCarbonVal);
            labelsPanel.Controls.Add(totalCarbonLbl);
            labelsPanel.Location = new Point(3, 783);
            labelsPanel.Name = "labelsPanel";
            labelsPanel.Size = new Size(550, 247);
            labelsPanel.StateCommon.Color1 = Color.FromArgb(0, 22, 25);
            labelsPanel.TabIndex = 2;
            // 
            // totalCarbonValPounds
            // 
            totalCarbonValPounds.Location = new Point(22, 104);
            totalCarbonValPounds.Name = "totalCarbonValPounds";
            totalCarbonValPounds.Size = new Size(70, 33);
            totalCarbonValPounds.StateCommon.ShortText.Color1 = Color.Lime;
            totalCarbonValPounds.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalCarbonValPounds.TabIndex = 4;
            totalCarbonValPounds.Values.Text = "0.00";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(22, 65);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(491, 35);
            kryptonLabel2.StateCommon.ShortText.Color1 = Color.White;
            kryptonLabel2.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kryptonLabel2.TabIndex = 3;
            kryptonLabel2.Values.Text = "Total Carbon Emission (lbs. CO₂):";
            // 
            // userLbl
            // 
            userLbl.Location = new Point(22, 17);
            userLbl.Name = "userLbl";
            userLbl.Size = new Size(180, 33);
            userLbl.StateCommon.ShortText.Color1 = Color.Yellow;
            userLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userLbl.TabIndex = 2;
            userLbl.Values.Text = "User: {user}";
            // 
            // totalCarbonVal
            // 
            totalCarbonVal.Location = new Point(22, 190);
            totalCarbonVal.Name = "totalCarbonVal";
            totalCarbonVal.Size = new Size(70, 33);
            totalCarbonVal.StateCommon.ShortText.Color1 = Color.Lime;
            totalCarbonVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalCarbonVal.TabIndex = 1;
            totalCarbonVal.Values.Text = "0.00";
            // 
            // totalCarbonLbl
            // 
            totalCarbonLbl.Location = new Point(22, 151);
            totalCarbonLbl.Name = "totalCarbonLbl";
            totalCarbonLbl.Size = new Size(448, 35);
            totalCarbonLbl.StateCommon.ShortText.Color1 = Color.White;
            totalCarbonLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalCarbonLbl.TabIndex = 0;
            totalCarbonLbl.Values.Text = "Total Carbon Emission (tCO₂):";
            // 
            // openGrid
            // 
            openGrid.BackColor = Color.FromArgb(0, 22, 25);
            openGrid.Image = Properties.Resources.sprite_earthBtn;
            openGrid.Location = new Point(1792, 15);
            openGrid.Name = "openGrid";
            openGrid.Size = new Size(84, 86);
            openGrid.SizeMode = PictureBoxSizeMode.StretchImage;
            openGrid.TabIndex = 3;
            openGrid.TabStop = false;
            openGrid.Click += openGrid_Click;
            openGrid.MouseEnter += openGrid_MouseEnter;
            openGrid.MouseLeave += openGrid_MouseLeave;
            // 
            // globalFootprintData
            // 
            globalFootprintData.AllowUserToAddRows = false;
            globalFootprintData.AllowUserToDeleteRows = false;
            globalFootprintData.AllowUserToOrderColumns = true;
            globalFootprintData.BorderStyle = BorderStyle.None;
            globalFootprintData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            globalFootprintData.Location = new Point(247, 54);
            globalFootprintData.Name = "globalFootprintData";
            globalFootprintData.ReadOnly = true;
            globalFootprintData.RowHeadersWidth = 51;
            globalFootprintData.Size = new Size(1504, 634);
            globalFootprintData.TabIndex = 7;
            // 
            // closeGrid
            // 
            closeGrid.BackColor = Color.FromArgb(0, 22, 25);
            closeGrid.Image = Properties.Resources.sprite_earth;
            closeGrid.Location = new Point(1792, 15);
            closeGrid.Name = "closeGrid";
            closeGrid.Size = new Size(84, 86);
            closeGrid.SizeMode = PictureBoxSizeMode.StretchImage;
            closeGrid.TabIndex = 8;
            closeGrid.TabStop = false;
            closeGrid.Click += closeGrid_Click;
            closeGrid.MouseEnter += closeGrid_MouseEnter;
            closeGrid.MouseLeave += closeGrid_MouseLeave;
            // 
            // CarbonFootprintMap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 22, 25);
            Controls.Add(closeGrid);
            Controls.Add(openGrid);
            Controls.Add(globalFootprintData);
            Controls.Add(labelsPanel);
            Controls.Add(exitBtn);
            Controls.Add(mapView);
            Name = "CarbonFootprintMap";
            Size = new Size(1902, 1033);
            ((System.ComponentModel.ISupportInitialize)exitBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)mapView).EndInit();
            ((System.ComponentModel.ISupportInitialize)labelsPanel).EndInit();
            labelsPanel.ResumeLayout(false);
            labelsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)openGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)globalFootprintData).EndInit();
            ((System.ComponentModel.ISupportInitialize)closeGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox exitBtn;
        private Microsoft.Web.WebView2.WinForms.WebView2 mapView;
        private Krypton.Toolkit.KryptonPanel labelsPanel;
        private Krypton.Toolkit.KryptonLabel totalCarbonLbl;
        private Krypton.Toolkit.KryptonLabel totalCarbonVal;
        private Krypton.Toolkit.KryptonLabel userLbl;
        private Krypton.Toolkit.KryptonLabel totalCarbonValPounds;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private PictureBox openGrid;
        private Krypton.Toolkit.KryptonDataGridView globalFootprintData;
        private PictureBox closeGrid;
    }
}
