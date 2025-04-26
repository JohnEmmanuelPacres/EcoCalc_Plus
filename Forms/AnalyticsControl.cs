using System.Data;
using System.Text;
using EcoCalc_Plus.CarbonFootrpintCalculator;
using OxyPlot;
using Krypton.Toolkit;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using EcoCalc_Plus.UtilityClass;

namespace EcoCalc_Plus
{
    public partial class AnalyticsControl : UserControl
    {
        public event EventHandler RequestClose;
        private readonly int _userId;
        private string _username;
        private DataTable _footprintData;
        private Image _originalExit, _originalPriority;
        private readonly CarbonFootprintRepository _repository;
        private SoundManager _soundManager = new SoundManager();
        private double overallAverage, totalAverage;
        private double avgVehicle, avgHE, avgAppliances, avgWaste;
        public AnalyticsControl(string username)
        {
            InitializeComponent();
            InitializeKryptonDataGridView();
            InitializePredictionTable(username);
            InitializeGraphs();

            emissionTabs.Refresh();
            timePeriodCombo.Refresh();

            DashboardHelper.SetParent(barChart, graphTab);

            userLbl.Text = $"{username}'s Carbon \r\nFooprint Data\r\n";
            _username = username;

            _originalExit = exitBtn.Image;
            _originalPriority = priorityListBtn.Image;

            timePeriodCombo.Items.AddRange(new object[] { "Weekly", "Monthly", "Yearly" });
            if (timePeriodCombo.Items.Count > 0)
            {
                timePeriodCombo.SelectedIndex = 0;
            }

            _repository = new CarbonFootprintRepository();
            _userId = _repository.GetUserId(username);

            if (_userId == 0)
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                return;
            }

            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            emissionsDataGrid.DataBindingComplete += emissionsDataGrid_DataBindingComplete;

            DashboardHelper.SetParent(comboboxPanel, graphTab);
            uiSet.Visible = false;
            predictedValTonLbl.Visible = false;
            predictedValLbsLbl.Visible = false;
            historicalLineChart.Visible = false;
            priorityLbl.Visible = false;
            barChart.Visible = false;
        }

        private void ChooseFX()
        {
            string soundPath = Path.Combine(Application.StartupPath, "assets", "Audio", "audio_choose.wav");
            _soundManager.PlaySoundEffect(soundPath);
        }
        private void SelectFX()
        {
            string soundPath = Path.Combine(Application.StartupPath, "assets", "Audio", "audio_selectCalc.wav");
            _soundManager.PlaySoundEffect(soundPath);
        }

        private void ExitFX()
        {
            string soundPath = Path.Combine(Application.StartupPath, "assets", "Audio", "audio_selected.wav");
            _soundManager.PlaySoundEffect(soundPath);
        }

        private void InitializeGraphs()
        {
            lineGraph.Model = new PlotModel { Title = "Periodic Emission" };
            barChart.Model = new PlotModel { Title = "Categorical Average Comparison" };
            historicalLineChart.Model = new PlotModel { Title = "Carbon Emission Trend" };
        }

        private void InitializeKryptonDataGridView()
        {
            try
            {
                EmissionDataGridVisuals();
                var numericStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    NullValue = "0.00"
                };

                AddColumnFootprint("FootprintID", "FootprintID", "Footprint ID", false);
                AddColumnFootprint("VehicularEmission", "VehicularEmission", "Vehicle", true, numericStyle, 200);
                AddColumnFootprint("HomeEnergyEmission", "HomeEnergyEmission", "Home Energy", true, numericStyle, 200);
                AddColumnFootprint("AppliancesEmission", "AppliancesEmission", "Appliances", true, numericStyle, 200);
                AddColumnFootprint("WasteEmission", "WasteEmission", "Waste", true, numericStyle, 200);
                AddColumnFootprint("TotalEmission", "TotalEmission", "Total", true, numericStyle, 200);

                AddColumnFootprint("DateRecorded", "DateRecorded", "Date Recorded", true,
                    new DataGridViewCellStyle()
                    {
                        Format = "dd/MM/yyyy hh:mm tt",
                        NullValue = "N/A"
                    }, 250);

                emissionsDataGrid.DataBindingComplete += emissionsDataGrid_DataBindingComplete;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error initializing DataGridView: {e.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmissionDataGridVisuals()
        {
            emissionsDataGrid.StateCommon.BackStyle = PaletteBackStyle.GridBackgroundList;
            emissionsDataGrid.StateCommon.HeaderColumn.Back.Color1 = Color.FromArgb(51, 153, 255);
            emissionsDataGrid.StateCommon.HeaderColumn.Back.Color2 = Color.FromArgb(0, 102, 204);
            emissionsDataGrid.StateCommon.HeaderColumn.Content.Color1 = Color.White;
            emissionsDataGrid.StateCommon.DataCell.Back.Color1 = Color.White;
            emissionsDataGrid.StateCommon.DataCell.Content.Color1 = Color.Black;

            emissionsDataGrid.StateCommon.Background.Color1 = Color.Khaki;
            emissionsDataGrid.StateCommon.Background.Color2 = Color.DarkKhaki;

            emissionsDataGrid.AutoGenerateColumns = false;
            emissionsDataGrid.AllowUserToAddRows = false;
            emissionsDataGrid.MultiSelect = false;
            emissionsDataGrid.AllowUserToResizeRows = false;
            emissionsDataGrid.RowHeadersVisible = false;

            emissionsDataGrid.Columns.Clear();
        }

        private void predictBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            try
            {
                predictedValTonLbl.Visible = true;
                predictedValLbsLbl.Visible = true;

                string modelPath = Path.Combine(Application.StartupPath, "Resources", "carbon_footprint_model.onnx");

                using var predictor = new CarbonFootprintPredictor(modelPath);

                var input = new CarbonFootprintInput
                {
                    VehicularEmission = float.Parse(aveVehicleVal.Text),
                    HomeEnergyEmission = float.Parse(aveHEVal.Text),
                    AppliancesEmission = float.Parse(aveAppliancesVal.Text),
                    WasteEmission = float.Parse(aveWasteVal.Text)
                };

                float predictedValue = predictor.Predict(input);

                NormalizeInput(predictedValue);
                float variation = 0.05f * predictedValue * Random.Shared.NextSingle();
                predictedValue += Random.Shared.Next(0, 2) == 0 ? variation : -variation;

                // Ensure minimum value
                predictedValue = Math.Max(1.0f, predictedValue);

                if (overallAverage < 4000)
                {
                    predictedValue -= 5;
                }
                else if (overallAverage > 10000)
                {
                    predictedValue += 5;

                    if (overallAverage > 20000)
                    {
                        predictedValue += Random.Shared.Next(0,5);
                    }
                }

                float tonsValue = predictedValue;
                float poundsValue = tonsValue * 2205;

                if (predictedValue <= 0)
                {
                    predictedValTonLbl.Text = "0.00";
                }
                else
                {
                    if (predictedValue > 4)
                    {
                        predictedValTonLbl.StateNormal.ShortText.Color1 = Color.Red;
                        predictedValLbsLbl.StateNormal.ShortText.Color1 = Color.Red;
                    }
                    else
                    {
                        predictedValTonLbl.StateNormal.ShortText.Color1 = Color.Green;
                        predictedValLbsLbl.StateNormal.ShortText.Color1 = Color.Green;
                    }

                    predictedValTonLbl.Text = $"{tonsValue:F2}";
                    predictedValLbsLbl.Text = $"{poundsValue:F2}";
                }

                var repo = new CarbonFootprintRepository();
                int userId = repo.GetUserId(_username);
                if (userId > 0)
                {
                    bool saved = repo.SavePrediction(userId, tonsValue, poundsValue);
                    if (!saved)
                    {
                        MessageBox.Show("Prediction was calculated but couldn't be saved to history. " +
                                      "Make sure you have at least one footprint record.",
                                      "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }


                DialogResult res = MessageBox.Show("Do you want to save your prediction?", "SAVE PREDICTION", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (res == DialogResult.Yes)
                {

                    try
                    {
                        LoadUserPredictions(_username);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializePredictionTable(string username)
        {
            try
            {
                PredictionDataGridVisuals();
                predictionsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                predictionsTable.MultiSelect = true;
                var numericStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    NullValue = "0.00"
                };

                var headerStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                };

                void AddColumn(string name, string headerText, string dataPropertyName, DataGridViewCellStyle cellStyle, bool visible = true)
                {
                    var column = new DataGridViewTextBoxColumn()
                    {
                        Name = name,
                        HeaderText = headerText,
                        DataPropertyName = dataPropertyName,
                        DefaultCellStyle = cellStyle,
                        Visible = visible
                    };
                    column.HeaderCell.Style = headerStyle;
                    predictionsTable.Columns.Add(column);
                }

                AddColumn("PredictionID", "Prediction ID", "PredictionID", headerStyle, false);
                AddColumn("FootprintID", "Footprint ID", "FootprintID", headerStyle, false);
                AddColumn("MetricTons", "Metric Tons", "MetricTons", numericStyle);
                AddColumn("Pounds", "Pounds", "Pounds", numericStyle);
                AddColumn("Vehicle", "Vehicle Emission", "VehicularEmission", numericStyle, false);
                AddColumn("HomeEnergy", "Home Energy Emission", "HomeEnergy", numericStyle, false);
                AddColumn("Appliances", "Appliances Emission", "Appliances", numericStyle, false);
                AddColumn("Waste", "Waste Emission", "WasteEmission", numericStyle, false);

                AddColumn("PredictionDate", "Date Predicted", "PredictionDate", new DataGridViewCellStyle()
                {
                    Format = "g",
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                });

                LoadUserPredictions(username);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PredictionDataGridVisuals()
        {
            predictionsTable.StateCommon.BackStyle = PaletteBackStyle.GridBackgroundList;
            predictionsTable.StateCommon.HeaderColumn.Back.Color1 = Color.FromArgb(51, 153, 255);
            predictionsTable.StateCommon.HeaderColumn.Back.Color2 = Color.FromArgb(0, 102, 204);
            predictionsTable.StateCommon.HeaderColumn.Content.Color1 = Color.White;
            predictionsTable.StateCommon.DataCell.Back.Color1 = Color.White;
            predictionsTable.StateCommon.DataCell.Content.Color1 = Color.Black;

            predictionsTable.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            predictionsTable.DefaultCellStyle.SelectionForeColor = Color.Black;
            predictionsTable.RowHeadersVisible = false;
            predictionsTable.AllowUserToAddRows = false;
            predictionsTable.AllowUserToDeleteRows = false;
            predictionsTable.ReadOnly = true;

            predictionsTable.StateCommon.Background.Color1 = Color.Khaki;
            predictionsTable.StateCommon.Background.Color2 = Color.DarkKhaki;

            predictionsTable.AutoGenerateColumns = false;
            predictionsTable.AllowUserToAddRows = false;
            predictionsTable.MultiSelect = false;
            predictionsTable.AllowUserToResizeRows = false;
            predictionsTable.RowHeadersVisible = false;

            predictionsTable.Columns.Clear();
        }

        private void LoadUserPredictions(string username)
        {
            try
            {
                var repo = new CarbonFootprintRepository();
                int userId = repo.GetUserId(username);

                if (userId > 0)
                {
                    DataTable predictions = repo.GetPredictionHistory(userId);
                    predictionsTable.DataSource = predictions;
                    predictionsTable.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading predictions: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddColumnFootprint(string name, string dataPropertyName, string headerText, bool visible,
                         DataGridViewCellStyle style = null, int width = 100)
        {
            try
            {
                var column = new DataGridViewTextBoxColumn()
                {
                    Name = name,
                    DataPropertyName = dataPropertyName,
                    HeaderText = headerText,
                    Visible = visible,
                    Width = width
                };

                if (style != null)
                {
                    column.DefaultCellStyle = style;
                }

                emissionsDataGrid.Columns.Add(column);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding column: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void emissionsDataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (emissionsDataGrid != null && !emissionsDataGrid.IsDisposed)
                {
                    emissionsDataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resizing columns: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                _footprintData = _repository.GetUserFootprintHistory(_userId);

                if (emissionsDataGrid.InvokeRequired)
                {
                    emissionsDataGrid.Invoke((MethodInvoker)delegate
                    {
                        emissionsDataGrid.DataSource = null;
                        emissionsDataGrid.DataSource = _footprintData;
                    });
                }
                else
                {
                    emissionsDataGrid.DataSource = null;
                    emissionsDataGrid.DataSource = _footprintData;
                }

                CalculateDisplayAverage();
                UpdateGraphs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateGraphs()
        {
            UpdateLineGraph();
            UpdateBarChart();
        }

        private LineSeries CalculateTrendline(IList<DataPoint> points, string title, OxyColor color)
        {
            if (points.Count < 2) return null;

            // Calculate linear regression
            double xSum = 0, ySum = 0, xySum = 0, xSqSum = 0;
            int n = points.Count;

            foreach (var point in points)
            {
                xSum += point.X;
                ySum += point.Y;
                xySum += point.X * point.Y;
                xSqSum += point.X * point.X;
            }

            double slope = (n * xySum - xSum * ySum) / (n * xSqSum - xSum * xSum);
            double intercept = (ySum - slope * xSum) / n;

            // Create trendline
            var trendline = new LineSeries
            {
                Title = title,
                Color = color,
                StrokeThickness = 2,
                LineStyle = LineStyle.Dash,
                MarkerType = MarkerType.None
            };

            // Add first and last points for the line
            double minX = points.Min(p => p.X);
            double maxX = points.Max(p => p.X);
            trendline.Points.Add(new DataPoint(minX, slope * minX + intercept));
            trendline.Points.Add(new DataPoint(maxX, slope * maxX + intercept));

            return trendline;
        }

        private LineSeries CalculateMovingAverage(IList<DataPoint> points, string title, OxyColor color, int period)
        {
            if (points.Count < period) return null;

            var maSeries = new LineSeries
            {
                Title = title,
                Color = color,
                StrokeThickness = 2,
                MarkerType = MarkerType.None
            };

            // Order points by date (X value)
            var orderedPoints = points.OrderBy(p => p.X).ToList();

            for (int i = period - 1; i < orderedPoints.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < period; j++)
                {
                    sum += orderedPoints[i - j].Y;
                }
                double maValue = sum / period;
                maSeries.Points.Add(new DataPoint(orderedPoints[i].X, maValue));
            }

            return maSeries;
        }

        private void UpdateLineGraph()
        {
            if (_footprintData == null || _footprintData.Rows.Count == 0)
            {
                lineGraph.Model = new PlotModel { Title = "No data available", DefaultFont = "Minecraft" };
                historicalLineChart.Model = new PlotModel { Title = "No historical data available", DefaultFont = "Minecraft" };
                return;
            }

            var plotModel = new PlotModel
            {
                Title = "Periodic Emission",
                DefaultFont = "Minecraft",
                DefaultFontSize = 10
            };

            plotModel.Legends.Add(new Legend
            {
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.TopRight,
                LegendOrientation = LegendOrientation.Horizontal
            });

            var dateAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Date",
                StringFormat = "MMM dd",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Angle = 45
            };

            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "lbs. CO₂",
                Minimum = 0,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };
            var filteredData = FilterDataByTimePeriod(_footprintData);
            var filteredSeries = new LineSeries
            {
                Title = "Total Emissions",
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                StrokeThickness = 2
            };

            if (filteredData == null || filteredData.Rows.Count == 0)
            {
                plotModel.Title = "No data available for selected period";
                lineGraph.Model = plotModel;
                return;
            }

            var dates = filteredData.AsEnumerable()
                .Where(row => row["DateRecorded"] != DBNull.Value)
                .Select(row => Convert.ToDateTime(row["DateRecorded"]))
                .ToList();

            if (dates.Count == 0)
            {
                plotModel.Title = "No valid dates in selected period";
                lineGraph.Model = plotModel;
                return;
            }

            DateTime minDate = dates.Min();
            DateTime maxDate = dates.Max();

            if (timePeriodCombo.SelectedItem != null)
            {
                switch (timePeriodCombo.SelectedItem.ToString())
                {
                    case "Weekly":
                        dateAxis.StringFormat = "ddd MMM dd";
                        dateAxis.IntervalType = DateTimeIntervalType.Days;
                        dateAxis.MajorStep = 1;
                        dateAxis.MinorStep = 1;
                        dateAxis.Minimum = DateTimeAxis.ToDouble(minDate.Date);
                        dateAxis.Maximum = DateTimeAxis.ToDouble(maxDate.Date.AddDays(1));
                        break;

                    case "Monthly":
                        dateAxis.StringFormat = "MMM dd";
                        dateAxis.IntervalType = DateTimeIntervalType.Days;
                        dateAxis.MajorStep = 7;
                        dateAxis.MinorStep = 1;
                        dateAxis.Minimum = DateTimeAxis.ToDouble(new DateTime(minDate.Year, minDate.Month, 1));
                        dateAxis.Maximum = DateTimeAxis.ToDouble(new DateTime(maxDate.Year, maxDate.Month, 1).AddMonths(1));
                        break;

                    case "Yearly":
                        dateAxis.StringFormat = "yyyy";
                        dateAxis.IntervalType = DateTimeIntervalType.Years;
                        dateAxis.Minimum = DateTimeAxis.ToDouble(new DateTime(minDate.Year, minDate.Month, 1));
                        dateAxis.Maximum = DateTimeAxis.ToDouble(new DateTime(maxDate.Year, maxDate.Month, 1).AddYears(1));
                        break;
                }
            }

            plotModel.Axes.Add(dateAxis);
            plotModel.Axes.Add(valueAxis);

            var lineSeries = new LineSeries
            {
                Title = "Total Emissions",
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                StrokeThickness = 2
            };

            if (timePeriodCombo.SelectedItem != null)
            {
                switch (timePeriodCombo.SelectedItem.ToString())
                {
                    case "Weekly":
                        lineSeries.Color = OxyColors.SteelBlue;
                        lineSeries.MarkerFill = OxyColors.SteelBlue;
                        break;
                    case "Monthly":
                        lineSeries.Color = OxyColors.DarkGreen;
                        lineSeries.MarkerFill = OxyColors.DarkGreen;
                        lineSeries.LineStyle = LineStyle.Dash;
                        break;
                }
            }

            foreach (DataRow row in filteredData.Rows)
            {
                try
                {
                    if (row["DateRecorded"] != DBNull.Value && row["TotalEmission"] != DBNull.Value)
                    {
                        lineSeries.Points.Add(new DataPoint(
                            DateTimeAxis.ToDouble(Convert.ToDateTime(row["DateRecorded"])),
                            Convert.ToDouble(row["TotalEmission"])
                        ));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding data point: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (lineSeries.Points.Count > 0)
            {
                plotModel.Series.Add(lineSeries);
            }
            else
            {
                plotModel.Title = "No data available for selected period";
            }

            lineGraph.Model = plotModel;

            //historical line chart

            var historicalPlotModel = new PlotModel
            {
                Title = "Carbon Footprint Trend",
                Subtitle = "Unfiltered complete dataset",
                DefaultFont = "Minecraft",
                DefaultFontSize = 10
            };

            var historicalDateAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Date",
                StringFormat = "yyyy-MM-dd",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Angle = 45
            };

            var historicalValueAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "lbs. CO₂",
                Minimum = 0
            };

            var allDates = _footprintData.AsEnumerable()
                .Where(row => row["DateRecorded"] != DBNull.Value)
                .Select(row => Convert.ToDateTime(row["DateRecorded"]))
                .OrderBy(d => d)
                .ToList();

            if (allDates.Any())
            {
                historicalDateAxis.Minimum = DateTimeAxis.ToDouble(allDates.First());
                historicalDateAxis.Maximum = DateTimeAxis.ToDouble(allDates.Last().AddDays(1));
            }

            if (allDates.Count > 0)
            {
                var timespan = allDates.Last() - allDates.First();
                historicalDateAxis.IntervalType = timespan.TotalDays > 365 ?
                    DateTimeIntervalType.Years :
                    DateTimeIntervalType.Months;
            }

            historicalPlotModel.Axes.Add(historicalDateAxis);
            historicalPlotModel.Axes.Add(historicalValueAxis);

            // Create historical series
            var historicalSeries = new LineSeries
            {
                Title = "Historical Emissions",
                Color = OxyColors.DarkSlateGray,
                MarkerType = MarkerType.Circle,
                MarkerSize = 3,
                MarkerFill = OxyColors.SlateGray,
                StrokeThickness = 1.5
            };

            // Add all data points
            foreach (DataRow row in _footprintData.Rows)
            {
                try
                {
                    if (row["DateRecorded"] != DBNull.Value && row["TotalEmission"] != DBNull.Value)
                    {
                        historicalSeries.Points.Add(new DataPoint(
                            DateTimeAxis.ToDouble(Convert.ToDateTime(row["DateRecorded"])),
                            Convert.ToDouble(row["TotalEmission"])
                        ));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding historical data point: " +
                        $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (historicalSeries.Points.Count >= 0)
            {
                historicalPlotModel.Series.Add(historicalSeries);

                // Calculate and add trendline
                var trendline = CalculateTrendline(
                    historicalSeries.Points.ToList(),
                    "Trend",
                    OxyColors.Red
                );

                if (trendline != null)
                {
                    historicalPlotModel.Series.Add(trendline);
                }

                // Optional: Add moving average (example with 7-period MA)
                var movingAvgSeries = CalculateMovingAverage(
                    historicalSeries.Points.ToList(),
                    "7-Day Moving Avg",
                    OxyColors.Green,
                    7
                );

                if (movingAvgSeries != null)
                {
                    historicalPlotModel.Series.Add(movingAvgSeries);
                }
            }
            else
            {
                historicalPlotModel.Title = "No valid historical data";
            }

            historicalLineChart.Model = historicalPlotModel;
        }

        private void UpdateBarChart()
        {
            var plotModel = new PlotModel
            {
                Title = "Emission Category Comparison (All Time)",
                DefaultFont = "Minecraft"
            };

            if (_footprintData == null || _footprintData.Rows.Count == 0)
            {
                barChart.Model = plotModel;
                return;
            }

            // No filtering - use all data
            double GetSafeDouble(DataRow row, string columnName)
            {
                return row[columnName] == DBNull.Value ? 0 : Convert.ToDouble(row[columnName]);
            }

            double vehicleTotal = 0;
            double homeEnergyTotal = 0;
            double appliancesTotal = 0;
            double wasteTotal = 0;

            foreach (DataRow row in _footprintData.Rows) // Use raw data instead of filtered
            {
                vehicleTotal += GetSafeDouble(row, "VehicularEmission");
                homeEnergyTotal += GetSafeDouble(row, "HomeEnergyEmission");
                appliancesTotal += GetSafeDouble(row, "AppliancesEmission");
                wasteTotal += GetSafeDouble(row, "WasteEmission");
            }

            var barSeries = new BarSeries
            {
                Title = "Total Emissions",
                FillColor = OxyColors.Brown,
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1,
                Font = "Minecraft"
            };

            if (vehicleTotal > 0) barSeries.Items.Add(new BarItem { Value = vehicleTotal });
            if (homeEnergyTotal > 0) barSeries.Items.Add(new BarItem { Value = homeEnergyTotal });
            if (appliancesTotal > 0) barSeries.Items.Add(new BarItem { Value = appliancesTotal });
            if (wasteTotal > 0) barSeries.Items.Add(new BarItem { Value = wasteTotal });

            if (barSeries.Items.Count > 0)
            {
                plotModel.Series.Add(barSeries);

                var categoryAxis = new CategoryAxis
                {
                    Position = AxisPosition.Left,
                    Title = "Categories",
                    Font = "Minecraft"
                };

                if (vehicleTotal > 0) categoryAxis.Labels.Add("Vehicle");
                if (homeEnergyTotal > 0) categoryAxis.Labels.Add("Home Energy");
                if (appliancesTotal > 0) categoryAxis.Labels.Add("Appliances");
                if (wasteTotal > 0) categoryAxis.Labels.Add("Waste");

                var valueAxis = new LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    Title = "lbs. CO₂",
                    Minimum = 0,
                    MinimumPadding = 0,
                    AbsoluteMinimum = 0
                };

                plotModel.Axes.Add(categoryAxis);
                plotModel.Axes.Add(valueAxis);
            }
            else
            {
                plotModel.Title = "No emission data available";
            }

            barChart.Model = plotModel;
        }

        private DataTable FilterDataByTimePeriod(DataTable data)
        {
            if (data == null || data.Rows.Count == 0 || timePeriodCombo.SelectedItem == null)
                return data;

            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today;
            string selectedPeriod = timePeriodCombo.SelectedItem.ToString();

            switch (selectedPeriod)
            {
                case "Weekly":
                    startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek); // Start of week (Sunday)
                    endDate = startDate.AddDays(6); // End of week (Saturday)
                    break;
                case "Monthly":
                    startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); // Start of month
                    endDate = startDate.AddMonths(1).AddDays(-1); // Last day of month
                    break;
                case "Yearly":
                    startDate = new DateTime(DateTime.Today.Year, 1, 1); // Start of year
                    endDate = new DateTime(DateTime.Today.Year, 12, 31); // End of year
                    break;
            }

            // For weekly/monthly/yearly, filter normally
            var filteredRows = data.AsEnumerable()
                .Where(row => row["DateRecorded"] != DBNull.Value &&
                       Convert.ToDateTime(row["DateRecorded"]).Date >= startDate.Date &&
                       Convert.ToDateTime(row["DateRecorded"]).Date <= endDate.Date)
                .ToArray();

            var result = data.Clone();
            foreach (var row in filteredRows)
            {
                result.ImportRow(row);
            }
            return result;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            ExitFX();
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void exitBtn2_Click(object sender, EventArgs e)
        {
            ExitFX();
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void exitBtn3_Click(object sender, EventArgs e)
        {
            ExitFX();
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void timePeriodCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (timePeriodCombo.SelectedItem == null) return;
            UpdateGraphs();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            if (emissionsDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = emissionsDataGrid.SelectedRows[0];
            int footprintId = Convert.ToInt32(selectedRow.Cells["FootprintID"].Value);
            double vehicleEmission = Convert.ToDouble(selectedRow.Cells["VehicularEmission"].Value);
            double homeEnergyEmission = Convert.ToDouble(selectedRow.Cells["HomeEnergyEmission"].Value);
            double applianceEmission = Convert.ToDouble(selectedRow.Cells["AppliancesEmission"].Value); // Note: "AppliancesEmission" matches your query
            double wasteEmission = Convert.ToDouble(selectedRow.Cells["WasteEmission"].Value);

            var editForm = new EditFootprintForm(
                footprintId,
                vehicleEmission,
                homeEnergyEmission,
                applianceEmission,
                wasteEmission
            );

            editForm.FormClosed += (s, result) =>
            {
                if (result == DialogResult.OK)
                {
                    try
                    {
                        bool success = _repository.UpdateFootprint(
                            editForm.FootprintId,
                            editForm.VehicleEmission,
                            editForm.HomeEnergyEmission,
                            editForm.ApplianceEmission,
                            editForm.WasteEmission
                        );

                        if (success)
                        {
                            MessageBox.Show("Record updated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update record.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating record: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            var hostForm = new Form
            {
                Size = new Size(800, 450),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.None,
                MaximizeBox = false,
                MinimizeBox = false
            };

            hostForm.Controls.Add(editForm);
            editForm.Dock = DockStyle.Fill;
            hostForm.ShowDialog(this);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            if (emissionsDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataGridViewRow selectedRow = emissionsDataGrid.SelectedRows[0];
            int footprintId = Convert.ToInt32(selectedRow.Cells["FootprintID"].Value);
            var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _repository.DeleteFootprint(footprintId);

                    if (success)
                    {
                        MessageBox.Show("Record deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete record.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting record: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                LoadData();
                MessageBox.Show("Data refreshed successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default; // Restore default cursor
            }
        }

        private void CalculateDisplayAverage()
        {
            if (_footprintData == null || _footprintData.Rows.Count == 0)
            {
                aveVehicleVal.Text = "0.00";
                aveHEVal.Text = "0.00";
                aveAppliancesVal.Text = "0.00";
                aveWasteVal.Text = "0.00";
                overallTotalVal.Text = "0.00";
                overallAveVal.Text = "0.00";
                return;
            }

            double SafeCalculate(string columnName, Func<IEnumerable<double>, double> operation)
            {
                var values = _footprintData.AsEnumerable()
                    .Where(row => !row.IsNull(columnName))
                    .Select(row => Convert.ToDouble(row[columnName]));

                return values.Any() ? operation(values) : 0.0;
            }

            this.avgVehicle = SafeCalculate("VehicularEmission", vals => vals.Average());
            this.avgHE = SafeCalculate("HomeEnergyEmission", vals => vals.Average());
            this.avgAppliances = SafeCalculate("AppliancesEmission", vals => vals.Average());
            this.avgWaste = SafeCalculate("WasteEmission", vals => vals.Average());

            double totalVehicle = SafeCalculate("VehicularEmission", vals => vals.Sum());
            double totalHE = SafeCalculate("HomeEnergyEmission", vals => vals.Sum());
            double totalAppliances = SafeCalculate("AppliancesEmission", vals => vals.Sum());
            double totalWaste = SafeCalculate("WasteEmission", vals => vals.Sum());

            double overallTotal = totalVehicle + totalHE + totalAppliances + totalWaste;
            double overallAve = (avgVehicle + avgHE + avgAppliances + avgWaste) / 4;
            totalAverage = avgVehicle + avgHE + avgAppliances + avgWaste;
            overallAverage = overallAve;

            aveVehicleVal.Text = avgVehicle.ToString("N2");
            aveHEVal.Text = avgHE.ToString("N2");
            aveAppliancesVal.Text = avgAppliances.ToString("N2");
            aveWasteVal.Text = avgWaste.ToString("N2");
            overallTotalVal.Text = overallTotal.ToString("N2");
            overallAveVal.Text = overallAve.ToString("N2");
        }

        private void priorityListBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            CalculateDisplayAverage();

            var emissionCategories = new Dictionary<string, double>
            {
                { "Vehicle Emissions", (avgVehicle / totalAverage) * 100 },
                { "Home Energy", (avgHE / totalAverage) * 100},
                { "Appliances", (avgAppliances / totalAverage) * 100 },
                { "Waste", (avgWaste / totalAverage) * 100 }
            };

            var priorityList = emissionCategories
                .OrderByDescending(kv => kv.Value)
                .ToList();

            DisplayPriorityList(priorityList);
        }

        private void barBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            UpdateBarBtnUI();
            barChart.Visible = true;
            lineGraph.Visible = false;
            historicalLineChart.Visible = false;
            timePeriodCombo.Visible = false;
            timePeriodLbl.Visible = false;
        }

        private void lineBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            UpdateLineBtnUI();
            lineGraph.Visible = true;
            barChart.Visible = false;
            historicalLineChart.Visible = false;
            timePeriodCombo.Visible = true;
            timePeriodLbl.Visible = true;
        }

        private void hLineBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            UpdateHLineBtnUI();
            historicalLineChart.Visible = true;
            lineGraph.Visible = false;
            barChart.Visible = false;
            timePeriodCombo.Visible = false;
            timePeriodLbl.Visible = false;
        }

        private void DisplayPriorityList(List<KeyValuePair<string, double>> priorityList)
        {
            if (priorityList == null || priorityList.Count == 0)
            {
                MessageBox.Show("No emission data available to display priorities.");
                return;
            }

            StringBuilder message = new StringBuilder();
            message.AppendLine("YOUR CARBON EMISSION PRIORITIES");
            message.AppendLine("=================================");
            message.AppendLine("(Sorted from highest to lowest impact)");
            message.AppendLine();

            for (int i = 0; i < priorityList.Count; i++)
            {
                message.AppendLine($"{i + 1}. {priorityList[i].Key.PadRight(20)} {priorityList[i].Value:N2} %");
            }

            message.AppendLine("\nRECOMMENDATIONS:");
            message.AppendLine("----------------");

            foreach (var item in priorityList)
            {
                message.AppendLine($"• {item.Key}: {GetRecommendation(item.Key)}");
            }

            MessageBox.Show(message.ToString(), "Your Emission Reduction Plan",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetRecommendation(string category)
        {
            return category switch
            {
                "Vehicle Emissions" => "Consider carpooling, public transport, or electric vehicles",
                "Home Energy" => "Improve insulation, switch to LED bulbs, use smart thermostats",
                "Appliances" => "Unplug devices when not in use, upgrade to energy-efficient models",
                "Waste" => "Recycle more, compost organic waste, reduce single-use plastics",
                _ => "Review your usage patterns in this area"
            };
        }

        private void deletePredictionBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            if (predictionsTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one prediction to delete.", "Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"Delete {predictionsTable.SelectedRows.Count} selected prediction(s)?",
                                       "Confirm Delete",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var repo = new CarbonFootprintRepository();
                var idsToDelete = new List<int>();

                foreach (DataGridViewRow row in predictionsTable.SelectedRows)
                {
                    if (row.Cells["PredictionID"].Value != null)
                    {
                        idsToDelete.Add(Convert.ToInt32(row.Cells["PredictionID"].Value));
                    }
                }

                if (idsToDelete.Count > 0)
                {
                    bool success = repo.DeletePredictions(idsToDelete);
                    if (success)
                    {
                        MessageBox.Show("Predictions deleted successfully.", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserPredictions(_username);
                    }
                }
            }
        }

        private void refreshPredictionBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            string currentUsername = _username; // Implement this based on your auth system
            LoadUserPredictions(currentUsername);
            MessageBox.Show("Data refreshed successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(exitBtn,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, true);
        }

        private void exitBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(exitBtn,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, false);
        }

        private void exitBtn2_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(exitBtn2,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, true);
        }

        private void exitBtn2_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(exitBtn2,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, false);
        }

        private void exitBtn3_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityGeneral.ApplyHoverEffect(exitBtn3,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, true);
        }

        private void exitBtn3_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityGeneral.ApplyHoverEffect(exitBtn3,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, false);
        }

        private void UpdateBarBtnUI()
        {
            barBtn.Image = Properties.Resources.sprite_fillBtn;
            lineBtn.Image = Properties.Resources.sprite_emptyBtn;
            hLineBtn.Image = Properties.Resources.sprite_emptyBtn;
        }
        private void UpdateLineBtnUI()
        {
            barBtn.Image = Properties.Resources.sprite_emptyBtn;
            lineBtn.Image = Properties.Resources.sprite_fillBtn;
            hLineBtn.Image = Properties.Resources.sprite_emptyBtn;
        }
        private void UpdateHLineBtnUI()
        {
            hLineBtn.Image = Properties.Resources.sprite_fillBtn;
            barBtn.Image = Properties.Resources.sprite_emptyBtn;
            lineBtn.Image = Properties.Resources.sprite_emptyBtn;
        }

        private float NormalizeInput(float value)
        {
            return Math.Clamp(value, 0, 100);
        }

        private void priorityListBtn_MouseEnter(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(priorityListBtn, priorityLbl,
                Properties.Resources.sprite_priorityBtnAlt, _originalPriority, true);
        }

        private void priorityListBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(priorityListBtn, priorityLbl,
                Properties.Resources.sprite_priorityBtnAlt, _originalPriority, false);
        }
    }
}
