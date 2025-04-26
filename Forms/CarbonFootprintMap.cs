using System.Data;
using EcoCalc_Plus.UtilityClass;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;
using EcoCalc_Plus.CarbonFootrpintCalculator;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace EcoCalc_Plus
{
    public partial class CarbonFootprintMap : UserControl
    {
        private string _username;
        private readonly int _userId;
        private readonly CarbonFootprintRepository _repository;

        private DataTable _footprintData;

        public event EventHandler RequestClose;
        public Image _originalExit;
        private SoundManager _soundManager = new SoundManager();

        public CarbonFootprintMap(string username)
        {
            InitializeComponent();
            InitializeDataGridForCF();
            _originalExit = exitBtn.Image;
            _username = username;
            _repository = new CarbonFootprintRepository();
            _userId = _repository.GetUserId(username);

            globalFootprintData.SendToBack();
            globalFootprintData.Visible = false;
            closeGrid.SendToBack();

            if (_userId == 0)
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                return;
            }

            try
            {
                LoadData();
                userLbl.Text = $"User: {_username}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                _footprintData = _repository.GetUserFootprintHistory(_userId);
                CalculateConvertTotalEmissionToTons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChooseFX()
        {
            string soundPath = Path.Combine(Application.StartupPath, "assets", "Audio", "audio_choose.wav");
            _soundManager.PlaySoundEffect(soundPath);
        }

        private void ExitFX()
        {
            string soundPath = Path.Combine(Application.StartupPath, "assets", "Audio", "audio_selected.wav");
            _soundManager.PlaySoundEffect(soundPath);
        }

        private void SelectFX()
        {
            string soundPath = Path.Combine(Application.StartupPath, "assets", "Audio", "audio_selectLand.wav");
            _soundManager.PlaySoundEffect(soundPath);
        }

        private void CalculateConvertTotalEmissionToTons()
        {
            if (_footprintData == null || _footprintData.Rows.Count == 0)
            {
                totalCarbonVal.Text = "0.00";
                totalCarbonValPounds.Text = "0.00";
                return;
            }

            double SafeCalculate(string columnName, Func<IEnumerable<double>, double> operation)
            {
                var values = _footprintData.AsEnumerable()
                    .Where(row => !row.IsNull(columnName))
                    .Select(row => Convert.ToDouble(row[columnName]));

                return values.Any() ? operation(values) : 0.0;
            }

            double totalVehicle = SafeCalculate("VehicularEmission", vals => vals.Sum());
            double totalHE = SafeCalculate("HomeEnergyEmission", vals => vals.Sum());
            double totalAppliances = SafeCalculate("AppliancesEmission", vals => vals.Sum());
            double totalWaste = SafeCalculate("WasteEmission", vals => vals.Sum());
            double overallLbs = totalVehicle + totalHE + totalAppliances + totalWaste;
            double overallMetricTon = overallLbs / 2205;

            totalCarbonValPounds.Text = overallLbs.ToString("0.00");
            totalCarbonVal.Text = overallMetricTon.ToString("0.00");
        }

        public async Task InitializeAsync()
        {
            try
            {
                mapView = new WebView2
                {
                    Dock = DockStyle.Fill,
                    CreationProperties = new CoreWebView2CreationProperties
                    {
                        UserDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EcoCalc_Plus")
                    }
                };

                this.Controls.Add(mapView);
                this.Controls.SetChildIndex(mapView, 0);
                this.Controls.SetChildIndex(exitBtn, 1);
                this.Controls.SetChildIndex(labelsPanel, 1);
                this.Controls.SetChildIndex(openGrid, 1);
                this.Controls.SetChildIndex(globalFootprintData, 1);
                this.Controls.SetChildIndex(closeGrid, 1);

                exitBtn.BringToFront();
                labelsPanel.BringToFront();
                openGrid.BringToFront();

                var env = await CoreWebView2Environment.CreateAsync();
                await mapView.EnsureCoreWebView2Async(env);
                mapView.CoreWebView2.Settings.IsZoomControlEnabled = true;
                mapView.ZoomFactor = 1.0f;

                mapView.CoreWebView2.Settings.AreDevToolsEnabled = true;
                mapView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = true;

                mapView.CoreWebView2.WebMessageReceived += (sender, e) =>
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        try
                        {
                            var json = e.TryGetWebMessageAsString();
                            if (string.IsNullOrWhiteSpace(json))
                            {
                                MessageBox.Show("No data received from the map.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            var countryData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                            if (countryData == null)
                            {
                                MessageBox.Show("Invalid data format received from the map.", 
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            string id = countryData.TryGetValue("id", out var idValue) ? idValue : "N/A";
                            string name = countryData.TryGetValue("name", out var nameValue) ? nameValue : "Unnamed Country";

                            double mtCO2e = 0.0;
                            if (countryData.TryGetValue("emission", out var emissionValue))
                            {
                                if (!double.TryParse(emissionValue, out mtCO2e))
                                {
                                    MessageBox.Show("Invalid emission data received.", "Error", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    mtCO2e = 0.0;
                                }
                            }

                            string countryEmission;

                            if (mtCO2e == 0)
                            {
                                countryEmission = "No data available";
                            }
                            else
                            {
                                countryEmission = $"CO₂ Emissions: {mtCO2e:F2} million tonnes";
                            }

                            var message = new StringBuilder()
                                .AppendLine($"Country: {name}")
                                .AppendLine($"ID: {id}")
                                .AppendLine(countryEmission)
                                .AppendLine()
                                .AppendLine($"(Data received at {DateTime.Now:HH:mm:ss})")
                                .ToString();

                            // Show message box with custom caption and icon
                            SelectFX();
                            MessageBox.Show(
                                message,
                                "Carbon Footprint Data",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        catch (JsonException jsonEx)
                        {
                            MessageBox.Show($"JSON Error: {jsonEx.Message}", "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(
                                "The received data format is invalid.",
                                "Data Format Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                $"An error occurred while processing country data:\n{ex.Message}",
                                "Processing Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    });
                };

                string htmlPath = Path.Combine(Application.StartupPath, "Resources", "world.html");

                if (!File.Exists(htmlPath))
                {
                    MessageBox.Show($"HTML file not found at: {htmlPath}");
                    return;
                }

                mapView.CoreWebView2.Navigate(htmlPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"WebView2 Error: {ex.Message}");
            }
        }

        private void mapView_Click(object sender, EventArgs e)
        {
            SelectFX();
        }

        public void InitializeDataGridForCF()
        {
            try
            {
                string query = @"
                    SELECT Country, 
                        [2023], [2022], [2021], [2020], [2019], [2018], [2017], 
                        [2016], [2015], [2014], [2013], [2012], [2011], [2010], 
                        [2009], [2008], [2007], [2006], [2005], [2004], [2003], 
                        [2002], [2001], [2000], [1999], [1998], [1997], [1996], 
                        [1995], [1994], [1993], [1992], [1991], [1990], [1989], 
                        [1988], [1987], [1986], [1985], [1984], [1983], [1982], 
                        [1981], [1980], [1979], [1978], [1977], [1976], [1975], 
                        [1974], [1973], [1972], [1971], [1970]
                    FROM CountryFootprint 
                    ORDER BY Country";

                DataTable countryData = DatabaseHelper.GetDataTable(query);

                foreach (DataColumn col in countryData.Columns)
                {
                    if (col.ColumnName != "Country" && col.DataType != typeof(string))
                    {
                        col.DataType = typeof(double);
                    }
                }

                globalFootprintData.DataSource = countryData;

                globalFootprintData.ReadOnly = true;
                globalFootprintData.AllowUserToAddRows = false;
                globalFootprintData.AllowUserToDeleteRows = false;
                globalFootprintData.AllowUserToOrderColumns = true;
                globalFootprintData.AllowUserToResizeColumns = true;

                globalFootprintData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                globalFootprintData.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                globalFootprintData.RowHeadersVisible = false;
                globalFootprintData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                globalFootprintData.Font = new Font("Minecraft", 12);
                

                foreach (DataGridViewColumn column in globalFootprintData.Columns)
                {
                    if (int.TryParse(column.HeaderText, out int year))
                    {
                        column.DefaultCellStyle.Format = "N4";
                        column.ValueType = typeof(double);
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        column.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    }
                    else
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                }

                globalFootprintData.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                globalFootprintData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                globalFootprintData.EnableHeadersVisualStyles = false;
                globalFootprintData.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
                globalFootprintData.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                globalFootprintData.ColumnHeadersDefaultCellStyle.Font = new Font("Minecraft", 12, FontStyle.Bold);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error initializing DataGridView: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"Error loading country footprint data:\n{e.Message}",
                               "Database Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);

                globalFootprintData.DataSource = new DataTable();
            }
            finally
            {
                globalFootprintData.ReadOnly = true;
            }
        }

        private void openGrid_Click(object sender, EventArgs e)
        {
            globalFootprintData.Visible = true;
            globalFootprintData.BringToFront();
            closeGrid.BringToFront();
            mapView.Visible = false;
        }

        private void closeGrid_Click(object sender, EventArgs e)
        {
            globalFootprintData.SendToBack();
            globalFootprintData.Visible = false;
            closeGrid.SendToBack();
            mapView.Visible = true;
        }


        private void exitBtn_Click(object sender, EventArgs e)
        {
            ExitFX();
            RequestClose?.Invoke(this, EventArgs.Empty);
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

        private void closeGrid_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void closeGrid_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void openGrid_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void openGrid_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
       
    }
}