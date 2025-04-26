namespace EcoCalc_Plus
{
    partial class AnalyticsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            predictTab = new TabPage();
            exitBtn3 = new Krypton.Toolkit.KryptonPictureBox();
            refreshPredictionBtn = new Krypton.Toolkit.KryptonButton();
            deletePredictionBtn = new Krypton.Toolkit.KryptonButton();
            predictionsTable = new Krypton.Toolkit.KryptonDataGridView();
            manageCarbon = new TabPage();
            exitBtn2 = new Krypton.Toolkit.KryptonPictureBox();
            refreshBtn = new Krypton.Toolkit.KryptonButton();
            deleteBtn = new Krypton.Toolkit.KryptonButton();
            editBtn = new Krypton.Toolkit.KryptonButton();
            emissionsDataGrid = new Krypton.Toolkit.KryptonDataGridView();
            graphTab = new TabPage();
            priorityListBtn = new Krypton.Toolkit.KryptonPictureBox();
            historicalLine = new Krypton.Toolkit.KryptonLabel();
            hLineBtn = new PictureBox();
            historicalLineChart = new OxyPlot.WindowsForms.PlotView();
            uiSet = new Krypton.Toolkit.KryptonThemeComboBox();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            trendLbl = new Krypton.Toolkit.KryptonLabel();
            barBtn = new PictureBox();
            lineBtn = new PictureBox();
            comboboxPanel = new Panel();
            timePeriodCombo = new Krypton.Toolkit.KryptonComboBox();
            panel1 = new Panel();
            priorityLbl = new Label();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            metricTon = new Krypton.Toolkit.KryptonLabel();
            pounds = new Krypton.Toolkit.KryptonLabel();
            predictedValLbsLbl = new Krypton.Toolkit.KryptonLabel();
            unitLbl = new Krypton.Toolkit.KryptonLabel();
            predictBtn = new Krypton.Toolkit.KryptonButton();
            aveHEVal = new Krypton.Toolkit.KryptonLabel();
            aveVehicularLbl = new Krypton.Toolkit.KryptonLabel();
            overallEmissionLbl = new Krypton.Toolkit.KryptonLabel();
            aveWasteLbl = new Krypton.Toolkit.KryptonLabel();
            userLbl = new Krypton.Toolkit.KryptonLabel();
            aveAppLbl = new Krypton.Toolkit.KryptonLabel();
            overallAveVal = new Krypton.Toolkit.KryptonLabel();
            aveHELbl = new Krypton.Toolkit.KryptonLabel();
            predictedValTonLbl = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            aveVehicleVal = new Krypton.Toolkit.KryptonLabel();
            potentialEmission = new Krypton.Toolkit.KryptonLabel();
            overallTotalVal = new Krypton.Toolkit.KryptonLabel();
            aveAppliancesVal = new Krypton.Toolkit.KryptonLabel();
            aveWasteVal = new Krypton.Toolkit.KryptonLabel();
            lineGraph = new OxyPlot.WindowsForms.PlotView();
            exitBtn = new PictureBox();
            timePeriodLbl = new Krypton.Toolkit.KryptonLabel();
            barChart = new OxyPlot.WindowsForms.PlotView();
            emissionTabs = new TabControl();
            predictTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exitBtn3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)predictionsTable).BeginInit();
            manageCarbon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exitBtn2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emissionsDataGrid).BeginInit();
            graphTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)priorityListBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hLineBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)uiSet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lineBtn).BeginInit();
            comboboxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timePeriodCombo).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exitBtn).BeginInit();
            emissionTabs.SuspendLayout();
            SuspendLayout();
            // 
            // predictTab
            // 
            predictTab.BackColor = Color.RosyBrown;
            predictTab.Controls.Add(exitBtn3);
            predictTab.Controls.Add(refreshPredictionBtn);
            predictTab.Controls.Add(deletePredictionBtn);
            predictTab.Controls.Add(predictionsTable);
            predictTab.Location = new Point(4, 37);
            predictTab.Name = "predictTab";
            predictTab.Size = new Size(1867, 984);
            predictTab.TabIndex = 2;
            predictTab.Text = "Prediction Records";
            // 
            // exitBtn3
            // 
            exitBtn3.Image = Properties.Resources.sprite_exitBtn;
            exitBtn3.Location = new Point(16, 17);
            exitBtn3.Name = "exitBtn3";
            exitBtn3.Size = new Size(120, 120);
            exitBtn3.SizeMode = PictureBoxSizeMode.StretchImage;
            exitBtn3.TabIndex = 3;
            exitBtn3.TabStop = false;
            exitBtn3.Click += exitBtn3_Click;
            exitBtn3.MouseEnter += exitBtn3_MouseEnter;
            exitBtn3.MouseLeave += exitBtn3_MouseLeave;
            // 
            // refreshPredictionBtn
            // 
            refreshPredictionBtn.Location = new Point(16, 399);
            refreshPredictionBtn.Name = "refreshPredictionBtn";
            refreshPredictionBtn.Size = new Size(233, 70);
            refreshPredictionBtn.StateCommon.Content.ShortText.Color1 = Color.Black;
            refreshPredictionBtn.StateCommon.Content.ShortText.Font = new Font("Minecraft", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            refreshPredictionBtn.TabIndex = 2;
            refreshPredictionBtn.Values.DropDownArrowColor = Color.Empty;
            refreshPredictionBtn.Values.Text = "Refresh";
            refreshPredictionBtn.Click += refreshPredictionBtn_Click;
            // 
            // deletePredictionBtn
            // 
            deletePredictionBtn.Location = new Point(16, 323);
            deletePredictionBtn.Name = "deletePredictionBtn";
            deletePredictionBtn.Size = new Size(233, 70);
            deletePredictionBtn.StateCommon.Content.ShortText.Color1 = Color.Black;
            deletePredictionBtn.StateCommon.Content.ShortText.Font = new Font("Minecraft", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deletePredictionBtn.TabIndex = 1;
            deletePredictionBtn.Values.DropDownArrowColor = Color.Empty;
            deletePredictionBtn.Values.Text = "Delete Prediction";
            deletePredictionBtn.Click += deletePredictionBtn_Click;
            // 
            // predictionsTable
            // 
            predictionsTable.BorderStyle = BorderStyle.None;
            predictionsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            predictionsTable.Location = new Point(336, 17);
            predictionsTable.Name = "predictionsTable";
            predictionsTable.RowHeadersWidth = 51;
            predictionsTable.Size = new Size(1356, 829);
            predictionsTable.TabIndex = 0;
            // 
            // manageCarbon
            // 
            manageCarbon.BackColor = Color.Gold;
            manageCarbon.Controls.Add(exitBtn2);
            manageCarbon.Controls.Add(refreshBtn);
            manageCarbon.Controls.Add(deleteBtn);
            manageCarbon.Controls.Add(editBtn);
            manageCarbon.Controls.Add(emissionsDataGrid);
            manageCarbon.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            manageCarbon.ForeColor = Color.SkyBlue;
            manageCarbon.Location = new Point(4, 37);
            manageCarbon.Name = "manageCarbon";
            manageCarbon.Padding = new Padding(3);
            manageCarbon.Size = new Size(1867, 984);
            manageCarbon.TabIndex = 1;
            manageCarbon.Text = "Manage Footprint";
            // 
            // exitBtn2
            // 
            exitBtn2.Image = Properties.Resources.sprite_exitBtn;
            exitBtn2.Location = new Point(16, 17);
            exitBtn2.Name = "exitBtn2";
            exitBtn2.Size = new Size(120, 120);
            exitBtn2.SizeMode = PictureBoxSizeMode.StretchImage;
            exitBtn2.TabIndex = 5;
            exitBtn2.TabStop = false;
            exitBtn2.Click += exitBtn2_Click;
            exitBtn2.MouseEnter += exitBtn2_MouseEnter;
            exitBtn2.MouseLeave += exitBtn2_MouseLeave;
            // 
            // refreshBtn
            // 
            refreshBtn.Location = new Point(16, 475);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(233, 70);
            refreshBtn.StateCommon.Content.ShortText.Color1 = Color.Black;
            refreshBtn.StateCommon.Content.ShortText.Font = new Font("Minecraft", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            refreshBtn.TabIndex = 4;
            refreshBtn.Values.DropDownArrowColor = Color.Empty;
            refreshBtn.Values.Text = "Refresh";
            refreshBtn.Click += refreshBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(16, 399);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(233, 70);
            deleteBtn.StateCommon.Content.ShortText.Color1 = Color.Black;
            deleteBtn.StateCommon.Content.ShortText.Font = new Font("Minecraft", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteBtn.TabIndex = 2;
            deleteBtn.Values.DropDownArrowColor = Color.Empty;
            deleteBtn.Values.Text = "Delete";
            deleteBtn.Click += deleteBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(16, 323);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(233, 70);
            editBtn.StateCommon.Content.ShortText.Color1 = Color.Black;
            editBtn.StateCommon.Content.ShortText.Font = new Font("Minecraft", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editBtn.TabIndex = 1;
            editBtn.Values.DropDownArrowColor = Color.Empty;
            editBtn.Values.Text = "Edit";
            editBtn.Click += editBtn_Click;
            // 
            // emissionsDataGrid
            // 
            emissionsDataGrid.BorderStyle = BorderStyle.None;
            emissionsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            emissionsDataGrid.Location = new Point(336, 17);
            emissionsDataGrid.Name = "emissionsDataGrid";
            emissionsDataGrid.RowHeadersWidth = 51;
            emissionsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            emissionsDataGrid.Size = new Size(1356, 829);
            emissionsDataGrid.StateCommon.Background.Color1 = Color.Maroon;
            emissionsDataGrid.StateCommon.Background.Color2 = Color.Transparent;
            emissionsDataGrid.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            emissionsDataGrid.StateCommon.DataCell.Back.Color1 = Color.Gold;
            emissionsDataGrid.StateCommon.DataCell.Back.Color2 = Color.DarkGray;
            emissionsDataGrid.StateCommon.HeaderColumn.Back.Color1 = Color.Maroon;
            emissionsDataGrid.StateCommon.HeaderColumn.Back.Color2 = Color.Gold;
            emissionsDataGrid.StateCommon.HeaderColumn.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            emissionsDataGrid.StateCommon.HeaderRow.Back.Color1 = Color.Gold;
            emissionsDataGrid.StateCommon.HeaderRow.Back.Color2 = Color.Maroon;
            emissionsDataGrid.StateSelected.DataCell.Back.Color1 = Color.FromArgb(128, 255, 255);
            emissionsDataGrid.StateSelected.DataCell.Back.Color2 = Color.FromArgb(192, 255, 255);
            emissionsDataGrid.TabIndex = 0;
            // 
            // graphTab
            // 
            graphTab.BackColor = Color.SkyBlue;
            graphTab.BorderStyle = BorderStyle.FixedSingle;
            graphTab.Controls.Add(priorityListBtn);
            graphTab.Controls.Add(historicalLine);
            graphTab.Controls.Add(hLineBtn);
            graphTab.Controls.Add(historicalLineChart);
            graphTab.Controls.Add(uiSet);
            graphTab.Controls.Add(kryptonLabel2);
            graphTab.Controls.Add(trendLbl);
            graphTab.Controls.Add(barBtn);
            graphTab.Controls.Add(lineBtn);
            graphTab.Controls.Add(comboboxPanel);
            graphTab.Controls.Add(panel1);
            graphTab.Controls.Add(lineGraph);
            graphTab.Controls.Add(exitBtn);
            graphTab.Controls.Add(timePeriodLbl);
            graphTab.Controls.Add(barChart);
            graphTab.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            graphTab.ForeColor = Color.SkyBlue;
            graphTab.Location = new Point(4, 37);
            graphTab.Name = "graphTab";
            graphTab.Padding = new Padding(3);
            graphTab.Size = new Size(1867, 984);
            graphTab.TabIndex = 0;
            graphTab.Text = "Visualize Footprint";
            // 
            // priorityListBtn
            // 
            priorityListBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            priorityListBtn.Image = Properties.Resources.sprite_priorityBtnOrig;
            priorityListBtn.Location = new Point(1717, 2);
            priorityListBtn.Name = "priorityListBtn";
            priorityListBtn.Size = new Size(100, 100);
            priorityListBtn.TabIndex = 45;
            priorityListBtn.TabStop = false;
            priorityListBtn.Click += priorityListBtn_Click;
            priorityListBtn.MouseEnter += priorityListBtn_MouseEnter;
            priorityListBtn.MouseLeave += priorityListBtn_MouseLeave;
            // 
            // historicalLine
            // 
            historicalLine.Location = new Point(240, 184);
            historicalLine.Name = "historicalLine";
            historicalLine.Size = new Size(229, 33);
            historicalLine.StateCommon.LongText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            historicalLine.StateCommon.ShortText.Color1 = Color.Black;
            historicalLine.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            historicalLine.TabIndex = 44;
            historicalLine.Values.Text = "Emission Trend";
            // 
            // hLineBtn
            // 
            hLineBtn.Anchor = AnchorStyles.Top;
            hLineBtn.Image = Properties.Resources.sprite_emptyBtn;
            hLineBtn.Location = new Point(203, 184);
            hLineBtn.Name = "hLineBtn";
            hLineBtn.Size = new Size(30, 30);
            hLineBtn.TabIndex = 43;
            hLineBtn.TabStop = false;
            hLineBtn.Click += hLineBtn_Click;
            // 
            // historicalLineChart
            // 
            historicalLineChart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            historicalLineChart.BackColor = Color.SkyBlue;
            historicalLineChart.ForeColor = Color.Black;
            historicalLineChart.Location = new Point(16, 338);
            historicalLineChart.Name = "historicalLineChart";
            historicalLineChart.PanCursor = Cursors.Hand;
            historicalLineChart.Size = new Size(1069, 625);
            historicalLineChart.TabIndex = 42;
            historicalLineChart.Text = "plotView1";
            historicalLineChart.ZoomHorizontalCursor = Cursors.SizeWE;
            historicalLineChart.ZoomRectangleCursor = Cursors.SizeNWSE;
            historicalLineChart.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // uiSet
            // 
            uiSet.DefaultPalette = Krypton.Toolkit.PaletteMode.Office2010BlueDarkMode;
            uiSet.DropDownWidth = 94;
            uiSet.Location = new Point(916, 37);
            uiSet.Name = "uiSet";
            uiSet.Size = new Size(94, 26);
            uiSet.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            uiSet.TabIndex = 41;
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(599, 128);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(303, 33);
            kryptonLabel2.StateCommon.LongText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kryptonLabel2.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel2.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kryptonLabel2.TabIndex = 38;
            kryptonLabel2.Values.Text = "Categorical Average";
            // 
            // trendLbl
            // 
            trendLbl.Location = new Point(240, 128);
            trendLbl.Name = "trendLbl";
            trendLbl.Size = new Size(257, 33);
            trendLbl.StateCommon.LongText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            trendLbl.StateCommon.ShortText.Color1 = Color.Black;
            trendLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            trendLbl.TabIndex = 36;
            trendLbl.Values.Text = "Periodic Emission";
            // 
            // barBtn
            // 
            barBtn.Anchor = AnchorStyles.Top;
            barBtn.Image = Properties.Resources.sprite_emptyBtn;
            barBtn.Location = new Point(562, 128);
            barBtn.Name = "barBtn";
            barBtn.Size = new Size(30, 30);
            barBtn.TabIndex = 35;
            barBtn.TabStop = false;
            barBtn.Click += barBtn_Click;
            // 
            // lineBtn
            // 
            lineBtn.Anchor = AnchorStyles.Top;
            lineBtn.Image = Properties.Resources.sprite_fillBtn;
            lineBtn.Location = new Point(203, 128);
            lineBtn.Name = "lineBtn";
            lineBtn.Size = new Size(30, 30);
            lineBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            lineBtn.TabIndex = 34;
            lineBtn.TabStop = false;
            lineBtn.Click += lineBtn_Click;
            // 
            // comboboxPanel
            // 
            comboboxPanel.Controls.Add(timePeriodCombo);
            comboboxPanel.Location = new Point(236, 52);
            comboboxPanel.Name = "comboboxPanel";
            comboboxPanel.Size = new Size(329, 47);
            comboboxPanel.TabIndex = 40;
            // 
            // timePeriodCombo
            // 
            timePeriodCombo.DropButtonStyle = Krypton.Toolkit.ButtonStyle.ListItem;
            timePeriodCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            timePeriodCombo.DropDownWidth = 318;
            timePeriodCombo.InputControlStyle = Krypton.Toolkit.InputControlStyle.Ribbon;
            timePeriodCombo.IntegralHeight = false;
            timePeriodCombo.Location = new Point(3, 4);
            timePeriodCombo.Name = "timePeriodCombo";
            timePeriodCombo.Size = new Size(318, 36);
            timePeriodCombo.StateActive.ComboBox.Content.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timePeriodCombo.StateCommon.ComboBox.Content.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timePeriodCombo.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            timePeriodCombo.TabIndex = 10;
            timePeriodCombo.SelectedIndexChanged += timePeriodCombo_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(priorityLbl);
            panel1.Controls.Add(kryptonLabel4);
            panel1.Controls.Add(kryptonLabel3);
            panel1.Controls.Add(metricTon);
            panel1.Controls.Add(pounds);
            panel1.Controls.Add(predictedValLbsLbl);
            panel1.Controls.Add(unitLbl);
            panel1.Controls.Add(predictBtn);
            panel1.Controls.Add(aveHEVal);
            panel1.Controls.Add(aveVehicularLbl);
            panel1.Controls.Add(overallEmissionLbl);
            panel1.Controls.Add(aveWasteLbl);
            panel1.Controls.Add(userLbl);
            panel1.Controls.Add(aveAppLbl);
            panel1.Controls.Add(overallAveVal);
            panel1.Controls.Add(aveHELbl);
            panel1.Controls.Add(predictedValTonLbl);
            panel1.Controls.Add(kryptonLabel1);
            panel1.Controls.Add(aveVehicleVal);
            panel1.Controls.Add(potentialEmission);
            panel1.Controls.Add(overallTotalVal);
            panel1.Controls.Add(aveAppliancesVal);
            panel1.Controls.Add(aveWasteVal);
            panel1.ForeColor = Color.SkyBlue;
            panel1.Location = new Point(1091, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(768, 907);
            panel1.TabIndex = 37;
            // 
            // priorityLbl
            // 
            priorityLbl.AutoSize = true;
            priorityLbl.ForeColor = Color.Gray;
            priorityLbl.Location = new Point(597, 59);
            priorityLbl.Name = "priorityLbl";
            priorityLbl.Size = new Size(168, 28);
            priorityLbl.TabIndex = 41;
            priorityLbl.Text = "PRIORITY";
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            kryptonLabel4.Location = new Point(112, 684);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(538, 65);
            kryptonLabel4.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel4.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            kryptonLabel4.TabIndex = 40;
            kryptonLabel4.Values.Text = "Globally, an average person produces \r\nabout 4 tons of CO₂ per year.\r\n";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            kryptonLabel3.Location = new Point(20, 684);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(86, 33);
            kryptonLabel3.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel3.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            kryptonLabel3.TabIndex = 39;
            kryptonLabel3.Values.Text = "Note: ";
            // 
            // metricTon
            // 
            metricTon.Location = new Point(626, 502);
            metricTon.Name = "metricTon";
            metricTon.Size = new Size(94, 35);
            metricTon.StateCommon.ShortText.Color1 = Color.Black;
            metricTon.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            metricTon.TabIndex = 38;
            metricTon.Values.Text = "t. CO₂";
            // 
            // pounds
            // 
            pounds.Location = new Point(626, 541);
            pounds.Name = "pounds";
            pounds.Size = new Size(123, 35);
            pounds.StateCommon.ShortText.Color1 = Color.Black;
            pounds.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            pounds.TabIndex = 37;
            pounds.Values.Text = "lbs. CO₂";
            // 
            // predictedValLbsLbl
            // 
            predictedValLbsLbl.Location = new Point(417, 543);
            predictedValLbsLbl.Name = "predictedValLbsLbl";
            predictedValLbsLbl.Size = new Size(70, 33);
            predictedValLbsLbl.StateCommon.ShortText.Color1 = Color.Black;
            predictedValLbsLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            predictedValLbsLbl.TabIndex = 36;
            predictedValLbsLbl.Values.Text = "0.00";
            // 
            // unitLbl
            // 
            unitLbl.Location = new Point(112, 167);
            unitLbl.Name = "unitLbl";
            unitLbl.Size = new Size(123, 35);
            unitLbl.StateCommon.ShortText.Color1 = Color.Black;
            unitLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            unitLbl.TabIndex = 35;
            unitLbl.Values.Text = "lbs. CO₂";
            // 
            // predictBtn
            // 
            predictBtn.Location = new Point(337, 614);
            predictBtn.Name = "predictBtn";
            predictBtn.Size = new Size(150, 50);
            predictBtn.StateCommon.Content.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            predictBtn.TabIndex = 34;
            predictBtn.Values.DropDownArrowColor = Color.Empty;
            predictBtn.Values.Text = "Predict";
            predictBtn.Click += predictBtn_Click;
            // 
            // aveHEVal
            // 
            aveHEVal.Location = new Point(543, 282);
            aveHEVal.Name = "aveHEVal";
            aveHEVal.Size = new Size(70, 33);
            aveHEVal.StateCommon.ShortText.Color1 = Color.Black;
            aveHEVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveHEVal.TabIndex = 28;
            aveHEVal.Values.Text = "0.00";
            // 
            // aveVehicularLbl
            // 
            aveVehicularLbl.Location = new Point(85, 243);
            aveVehicularLbl.Name = "aveVehicularLbl";
            aveVehicularLbl.Size = new Size(402, 33);
            aveVehicularLbl.StateCommon.ShortText.Color1 = Color.Black;
            aveVehicularLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveVehicularLbl.TabIndex = 18;
            aveVehicularLbl.Values.Text = "Average Vehicular Emission";
            // 
            // overallEmissionLbl
            // 
            overallEmissionLbl.Location = new Point(112, 438);
            overallEmissionLbl.Name = "overallEmissionLbl";
            overallEmissionLbl.Size = new Size(375, 33);
            overallEmissionLbl.StateCommon.ShortText.Color1 = Color.Black;
            overallEmissionLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            overallEmissionLbl.TabIndex = 19;
            overallEmissionLbl.Values.Text = "Overall Average Emission";
            // 
            // aveWasteLbl
            // 
            aveWasteLbl.Location = new Point(136, 360);
            aveWasteLbl.Name = "aveWasteLbl";
            aveWasteLbl.Size = new Size(351, 33);
            aveWasteLbl.StateCommon.ShortText.Color1 = Color.Black;
            aveWasteLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveWasteLbl.TabIndex = 20;
            aveWasteLbl.Values.Text = "Average Waste Emission";
            // 
            // userLbl
            // 
            userLbl.Location = new Point(27, 59);
            userLbl.Name = "userLbl";
            userLbl.Size = new Size(322, 102);
            userLbl.StateCommon.ShortText.Color1 = Color.Black;
            userLbl.StateCommon.ShortText.Color2 = Color.Gray;
            userLbl.StateCommon.ShortText.Font = new Font("Minecraft", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userLbl.TabIndex = 33;
            userLbl.Values.Text = "User Carbon \r\nFooprint Data";
            // 
            // aveAppLbl
            // 
            aveAppLbl.Location = new Point(65, 321);
            aveAppLbl.Name = "aveAppLbl";
            aveAppLbl.Size = new Size(422, 33);
            aveAppLbl.StateCommon.ShortText.Color1 = Color.Black;
            aveAppLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveAppLbl.TabIndex = 21;
            aveAppLbl.Values.Text = "Average Appliances Emission";
            // 
            // overallAveVal
            // 
            overallAveVal.Location = new Point(543, 438);
            overallAveVal.Name = "overallAveVal";
            overallAveVal.Size = new Size(70, 33);
            overallAveVal.StateCommon.ShortText.Color1 = Color.Black;
            overallAveVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            overallAveVal.TabIndex = 32;
            overallAveVal.Values.Text = "0.00";
            // 
            // aveHELbl
            // 
            aveHELbl.Location = new Point(27, 282);
            aveHELbl.Name = "aveHELbl";
            aveHELbl.Size = new Size(460, 33);
            aveHELbl.StateCommon.ShortText.Color1 = Color.Black;
            aveHELbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveHELbl.TabIndex = 22;
            aveHELbl.Values.Text = "Average Home Energy Emission";
            // 
            // predictedValTonLbl
            // 
            predictedValTonLbl.Location = new Point(417, 504);
            predictedValTonLbl.Name = "predictedValTonLbl";
            predictedValTonLbl.Size = new Size(70, 33);
            predictedValTonLbl.StateCommon.ShortText.Color1 = Color.Black;
            predictedValTonLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            predictedValTonLbl.TabIndex = 31;
            predictedValTonLbl.Values.Text = "0.00";
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(160, 399);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(327, 33);
            kryptonLabel1.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            kryptonLabel1.TabIndex = 23;
            kryptonLabel1.Values.Text = "Overall Total Emission";
            // 
            // aveVehicleVal
            // 
            aveVehicleVal.Location = new Point(543, 243);
            aveVehicleVal.Name = "aveVehicleVal";
            aveVehicleVal.Size = new Size(70, 33);
            aveVehicleVal.StateCommon.ShortText.Color1 = Color.Black;
            aveVehicleVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveVehicleVal.TabIndex = 29;
            aveVehicleVal.Values.Text = "0.00";
            // 
            // potentialEmission
            // 
            potentialEmission.Location = new Point(27, 504);
            potentialEmission.Name = "potentialEmission";
            potentialEmission.Size = new Size(317, 65);
            potentialEmission.StateCommon.ShortText.Color1 = Color.Black;
            potentialEmission.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            potentialEmission.TabIndex = 24;
            potentialEmission.Values.Text = "Possible Average\r\nEmission after a year";
            // 
            // overallTotalVal
            // 
            overallTotalVal.Location = new Point(543, 399);
            overallTotalVal.Name = "overallTotalVal";
            overallTotalVal.Size = new Size(70, 33);
            overallTotalVal.StateCommon.ShortText.Color1 = Color.Black;
            overallTotalVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            overallTotalVal.TabIndex = 25;
            overallTotalVal.Values.Text = "0.00";
            // 
            // aveAppliancesVal
            // 
            aveAppliancesVal.Location = new Point(543, 321);
            aveAppliancesVal.Name = "aveAppliancesVal";
            aveAppliancesVal.Size = new Size(70, 33);
            aveAppliancesVal.StateCommon.ShortText.Color1 = Color.Black;
            aveAppliancesVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveAppliancesVal.TabIndex = 27;
            aveAppliancesVal.Values.Text = "0.00";
            // 
            // aveWasteVal
            // 
            aveWasteVal.Location = new Point(543, 360);
            aveWasteVal.Name = "aveWasteVal";
            aveWasteVal.Size = new Size(70, 33);
            aveWasteVal.StateCommon.ShortText.Color1 = Color.Black;
            aveWasteVal.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold);
            aveWasteVal.TabIndex = 26;
            aveWasteVal.Values.Text = "0.00";
            // 
            // lineGraph
            // 
            lineGraph.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lineGraph.BackColor = Color.SkyBlue;
            lineGraph.ForeColor = Color.Black;
            lineGraph.Location = new Point(16, 338);
            lineGraph.Name = "lineGraph";
            lineGraph.PanCursor = Cursors.Hand;
            lineGraph.Size = new Size(1069, 625);
            lineGraph.TabIndex = 16;
            lineGraph.Text = "plotView1";
            lineGraph.ZoomHorizontalCursor = Cursors.SizeWE;
            lineGraph.ZoomRectangleCursor = Cursors.SizeNWSE;
            lineGraph.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // exitBtn
            // 
            exitBtn.Image = Properties.Resources.sprite_exitBtn;
            exitBtn.Location = new Point(16, 17);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(120, 120);
            exitBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            exitBtn.TabIndex = 12;
            exitBtn.TabStop = false;
            exitBtn.Click += exitBtn_Click;
            exitBtn.MouseEnter += exitBtn_MouseEnter;
            exitBtn.MouseLeave += exitBtn_MouseLeave;
            // 
            // timePeriodLbl
            // 
            timePeriodLbl.Location = new Point(236, 17);
            timePeriodLbl.Name = "timePeriodLbl";
            timePeriodLbl.Size = new Size(188, 33);
            timePeriodLbl.StateCommon.LongText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timePeriodLbl.StateCommon.ShortText.Color1 = Color.Black;
            timePeriodLbl.StateCommon.ShortText.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timePeriodLbl.TabIndex = 11;
            timePeriodLbl.Values.Text = "Time Period:";
            // 
            // barChart
            // 
            barChart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            barChart.BackColor = Color.SkyBlue;
            barChart.ForeColor = Color.Blue;
            barChart.Location = new Point(16, 329);
            barChart.Name = "barChart";
            barChart.PanCursor = Cursors.Hand;
            barChart.Size = new Size(1040, 634);
            barChart.TabIndex = 9;
            barChart.Text = "plotView1";
            barChart.ZoomHorizontalCursor = Cursors.SizeWE;
            barChart.ZoomRectangleCursor = Cursors.SizeNWSE;
            barChart.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // emissionTabs
            // 
            emissionTabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            emissionTabs.Controls.Add(graphTab);
            emissionTabs.Controls.Add(manageCarbon);
            emissionTabs.Controls.Add(predictTab);
            emissionTabs.Font = new Font("Minecraft", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emissionTabs.Location = new Point(17, 18);
            emissionTabs.Name = "emissionTabs";
            emissionTabs.SelectedIndex = 0;
            emissionTabs.Size = new Size(1875, 1025);
            emissionTabs.TabIndex = 0;
            // 
            // AnalyticsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(emissionTabs);
            Name = "AnalyticsControl";
            Size = new Size(1920, 1080);
            predictTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)exitBtn3).EndInit();
            ((System.ComponentModel.ISupportInitialize)predictionsTable).EndInit();
            manageCarbon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)exitBtn2).EndInit();
            ((System.ComponentModel.ISupportInitialize)emissionsDataGrid).EndInit();
            graphTab.ResumeLayout(false);
            graphTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)priorityListBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)hLineBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)uiSet).EndInit();
            ((System.ComponentModel.ISupportInitialize)barBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)lineBtn).EndInit();
            comboboxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)timePeriodCombo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)exitBtn).EndInit();
            emissionTabs.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage predictTab;
        private TabPage manageCarbon;
        private Krypton.Toolkit.KryptonPictureBox exitBtn2;
        private Krypton.Toolkit.KryptonButton refreshBtn;
        private Krypton.Toolkit.KryptonButton deleteBtn;
        private Krypton.Toolkit.KryptonButton editBtn;
        private Krypton.Toolkit.KryptonDataGridView emissionsDataGrid;
        private TabPage graphTab;
        private Krypton.Toolkit.KryptonPictureBox priorityListBtn;
        private Krypton.Toolkit.KryptonLabel historicalLine;
        private PictureBox hLineBtn;
        private OxyPlot.WindowsForms.PlotView historicalLineChart;
        private Krypton.Toolkit.KryptonThemeComboBox uiSet;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel trendLbl;
        private PictureBox barBtn;
        private PictureBox lineBtn;
        private Panel comboboxPanel;
        private Krypton.Toolkit.KryptonComboBox timePeriodCombo;
        private Panel panel1;
        private Label priorityLbl;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel metricTon;
        private Krypton.Toolkit.KryptonLabel pounds;
        private Krypton.Toolkit.KryptonLabel predictedValLbsLbl;
        private Krypton.Toolkit.KryptonLabel unitLbl;
        private Krypton.Toolkit.KryptonButton predictBtn;
        private Krypton.Toolkit.KryptonLabel aveHEVal;
        private Krypton.Toolkit.KryptonLabel aveVehicularLbl;
        private Krypton.Toolkit.KryptonLabel overallEmissionLbl;
        private Krypton.Toolkit.KryptonLabel aveWasteLbl;
        private Krypton.Toolkit.KryptonLabel userLbl;
        private Krypton.Toolkit.KryptonLabel aveAppLbl;
        private Krypton.Toolkit.KryptonLabel overallAveVal;
        private Krypton.Toolkit.KryptonLabel aveHELbl;
        private Krypton.Toolkit.KryptonLabel predictedValTonLbl;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel aveVehicleVal;
        private Krypton.Toolkit.KryptonLabel potentialEmission;
        private Krypton.Toolkit.KryptonLabel overallTotalVal;
        private Krypton.Toolkit.KryptonLabel aveAppliancesVal;
        private Krypton.Toolkit.KryptonLabel aveWasteVal;
        private OxyPlot.WindowsForms.PlotView lineGraph;
        private PictureBox exitBtn;
        private Krypton.Toolkit.KryptonLabel timePeriodLbl;
        private OxyPlot.WindowsForms.PlotView barChart;
        private TabControl emissionTabs;
        private Krypton.Toolkit.KryptonDataGridView predictionsTable;
        private Krypton.Toolkit.KryptonButton refreshPredictionBtn;
        private Krypton.Toolkit.KryptonButton deletePredictionBtn;
        private Krypton.Toolkit.KryptonPictureBox exitBtn3;
    }
}
