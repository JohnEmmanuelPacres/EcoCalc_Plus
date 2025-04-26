using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoCalc_Plus.UtilityClass;
using EcoCalc_Plus.CarbonFootrpintCalculator;
using System.Globalization;
using System.Configuration;
using System.Runtime.InteropServices;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Data.OleDb;

namespace EcoCalc_Plus
{
    public partial class CFCalculator : Form
    {
        private Image _originalContinue, _originalExit, _originalPrevious, _originalSave;
        private Label[] vehicleLabels, vehicleOutputLbl, vehicleResultLbl, heResultLbl;
        private TextBox[] vehicleTextBoxes, applianceTextBoxes;
        private NumericUpDown[] applianceNumeric;
        private ComboBox[] applianceComboBox;
        private EmissionPeriod _emissionPeriod;
        private double _totalVehicle, _totalHomeEnergy, _totalAppliance, 
            _totalWaste, _displayOverallTotal;
        private string _username;
        private bool _saveData;
        private SoundManager _soundManager = new SoundManager();

        public CFCalculator(string username, bool saveData)
        {
            InitializeComponent();
            InitializeChart(username);
            showSaveBtn(saveData);
            InitializeHouseholdMembers();
            this.BackColor = Color.FromArgb(163, 18, 133);
            _username = username;
            _saveData = saveData;

            heEmissionPanel.Visible = false;
            appEmissionPanel.Visible = false;
            wasteEmissionPanel.Visible = false;
            overallPanel.Visible = false;
            saveLbl.Visible = false;

            InitializeArrays();
            Vehicle2To10Hide();
            InitializeDevices();

            DashboardHelper.SetParent(exitLbl1, vehicularEmissionPanel);
            DashboardHelper.SetParent(continueLbl1, vehicularEmissionPanel);
            DashboardHelper.SetParent(panel1, vehicularEmissionPanel);
            DashboardHelper.SetParent(panel2, vehicularEmissionPanel);

            _originalContinue = continueBtn1.Image;
            _originalExit = exitBtn1.Image;
            _originalPrevious = previousBtn1.Image;
            _originalSave = saveBtn.Image;

            continueLbl1.Visible = false;
            exitLbl1.Visible = false;
            exitLbl2.Visible = false;
            exitLbl3.Visible = false;
            exitLbl4.Visible = false;
            previous1Lbl.Visible = false;
            previousLbl2.Visible = false;
            previousLbl3.Visible = false;
            previousLbl4.Visible = false;
            continue2Lbl.Visible = false;
            continueLbl3.Visible = false;
            continueLbl4.Visible = false;
            exitLbl5.Visible = false;

            storedVehicleTotal.Visible = false;
            storedHomeEnergyTotal.Visible = false;
            storedAppTotal.Visible = false;
            storedWasteTotal.Visible = false;

            v1Txt.KeyPress += textBox_KeyPress;
            v2Txt.KeyPress += textBox_KeyPress;
            v3Txt.KeyPress += textBox_KeyPress;
            v4Txt.KeyPress += textBox_KeyPress;
            v5Txt.KeyPress += textBox_KeyPress;
            v6Txt.KeyPress += textBox_KeyPress;
            v7Txt.KeyPress += textBox_KeyPress;
            v8Txt.KeyPress += textBox_KeyPress;
            v9Txt.KeyPress += textBox_KeyPress;
            v10Txt.KeyPress += textBox_KeyPress;

            NGTbx.KeyPress += textBox_KeyPress;
            FOTbx.KeyPress += textBox_KeyPress;
            ProTbx.KeyPress += textBox_KeyPress;
            ElecTbx.KeyPress += textBox_KeyPress;

            spTbx.KeyPress += textBox_KeyPress;
            fpTbx.KeyPress += textBox_KeyPress;
            tabTbx.KeyPress += textBox_KeyPress;
            laptopTbx.KeyPress += textBox_KeyPress;
            dpcTbx.KeyPress += textBox_KeyPress;
            pcdTbx.KeyPress += textBox_KeyPress;
            cpeTbx.KeyPress += textBox_KeyPress;
            tvTbx.KeyPress += textBox_KeyPress;
            acTbx.KeyPress += textBox_KeyPress;
            efTbx.KeyPress += textBox_KeyPress;
            wmTbx.KeyPress += textBox_KeyPress;
            heatTbx.KeyPress += textBox_KeyPress;
            refTbx.KeyPress += textBox_KeyPress;
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

        //VEHICLE EMISSION ELEMENTS
        private void InitializeArrays()
        {
            vehicleLabels = new Label[] { v1Lbl, v2Lbl, v3Lbl, v4Lbl, v5Lbl, v6Lbl, v7Lbl, v8Lbl, v9Lbl, v10Lbl };
            vehicleTextBoxes = new TextBox[] { v1Txt, v2Txt, v3Txt, v4Txt, v5Txt, v6Txt, v7Txt, v8Txt, v9Txt, v10Txt };
            vehicleOutputLbl = new Label[] { tv1Lbl, tv2Lbl, tv3Lbl, tv4Lbl, tv5Lbl, tv6Lbl, tv7Lbl, tv8Lbl, tv9Lbl, tv10Lbl };
            vehicleResultLbl = new Label[] { v1ResultLbl, v2ResultLbl, v3ResultLbl, v4ResultLbl, v5ResultLbl, v6ResultLbl, v7ResultLbl, v8ResultLbl, v9ResultLbl, v10ResultLbl };
            heResultLbl = new Label[] { NGResultLbl, FOResultLbl, ProResultLbl, ElecResultLbl };
            applianceNumeric = new NumericUpDown[] { spNumeric, fpNumeric, tabNumeric, laptopNumeric, dpcNumeric, pcdNumeric, cpeNumeric, tvNumeric, acNumeric, efNumeric, wmNumeric, heatNumeric, refNumeric };
            applianceComboBox = new ComboBox[] { spUF, fpUF, tabUF, laptopUF, dpcUF, pcdUF, cpeUF, tvUF, acUF, efUF, wmUF, heatUF, refUF };
            applianceTextBoxes = new TextBox[] { spTbx, fpTbx, tabTbx, laptopTbx, dpcTbx, pcdTbx, cpeTbx, tvTbx, acTbx, efTbx, wmTbx, heatTbx, refTbx };
        }

        private void Vehicle2To10Hide()
        {
            for (int i = 1; i < vehicleLabels.Length; i++)
            {
                vehicleLabels[i].Visible = false;
                vehicleOutputLbl[i].Visible = false;
                vehicleTextBoxes[i].Visible = false;
                vehicleResultLbl[i].Visible = false;
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            ExitFX();
            DialogResult result = MessageBox.Show("Are you sure you want to exit the calculator?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && (txt.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }
        private void maxVehicles_ValueChanged(object sender, EventArgs e)
        {
            int selectedVehicles = (int)maxVehicles.Value;

            for (int i = 0; i < vehicleLabels.Length; i++)
            {
                bool isVisible = (i < selectedVehicles);
                vehicleLabels[i].Visible = isVisible;
                vehicleOutputLbl[i].Visible = isVisible;
                vehicleTextBoxes[i].Visible = isVisible;
                vehicleResultLbl[i].Visible = isVisible;

                if (!isVisible)
                {
                    vehicleTextBoxes[i].Text = "";
                }
            }
        }
        //choices time period
        private void weekRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _emissionPeriod = EmissionPeriod.Weekly;
            UpdateVehicleEmissions();
            weekRadioBtn.Image = Properties.Resources.sprite_fillBtn;
            monthRadioBtn.Image = Properties.Resources.sprite_emptyBtn;
            yearRadioBtn.Image = Properties.Resources.sprite_emptyBtn;
            distanceLbl.Text = "DISTANCE (mi.) DRIVEN PER WEEK";
        }

        private void monthRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _emissionPeriod = EmissionPeriod.Monthly;
            UpdateVehicleEmissions();
            monthRadioBtn.Image = Properties.Resources.sprite_fillBtn;
            weekRadioBtn.Image = Properties.Resources.sprite_emptyBtn;
            yearRadioBtn.Image = Properties.Resources.sprite_emptyBtn;
            distanceLbl.Text = "DISTANCE (mi.) DRIVEN PER MONTH";
        }

        private void yearRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _emissionPeriod = EmissionPeriod.Yearly;
            UpdateVehicleEmissions();
            yearRadioBtn.Image = Properties.Resources.sprite_fillBtn;
            weekRadioBtn.Image = Properties.Resources.sprite_emptyBtn;
            monthRadioBtn.Image = Properties.Resources.sprite_emptyBtn;
            distanceLbl.Text = "DISTANCE (mi.) DRIVEN PER YEAR";
        }

        private void UpdateVehicleEmission(TextBox textBox, Label resultLabel)
        {
            double miles;
            if (!double.TryParse(textBox.Text, out miles) || miles < 0)
            {
                miles = 0;
            }
            HouseholdVehicle vehicle = new HouseholdVehicle(miles);
            double emission = vehicle.CalculateHV(miles, _emissionPeriod);
            resultLabel.Text = $"{emission:F2}";
        }

        private void v1Txt_TextChanged(object sender, EventArgs e)
        {
            UpdateVehicleEmission(v1Txt, v1ResultLbl);
            UpdateVehicleEmissions();
        }

        private void v2Txt_TextChanged(object sender, EventArgs e)
        {
            UpdateVehicleEmission(v2Txt, v2ResultLbl);
            UpdateVehicleEmissions();
        }

        private void v3Txt_TextChanged(object sender, EventArgs e)
        {
            UpdateVehicleEmission(v3Txt, v3ResultLbl);
            UpdateVehicleEmissions();
        }

        private void v4Txt_TextChanged(object sender, EventArgs e)
        {
            UpdateVehicleEmission(v4Txt, v4ResultLbl);
            UpdateVehicleEmissions();
        }

        private void v5Txt_TextChanged(object sender, EventArgs e)
        {
            UpdateVehicleEmission(v5Txt, v5ResultLbl);
            UpdateVehicleEmissions();
        }

        private void v6Txt_TextChanged(object sender, EventArgs e)
        {
            UpdateVehicleEmission(v6Txt, v6ResultLbl);
            UpdateVehicleEmissions();
        }

        private void v7Txt_TextChanged(object sender, EventArgs e)
        {
            UpdateVehicleEmission(v7Txt, v7ResultLbl);
            UpdateVehicleEmissions();
        }

        private void v8Txt_TextChanged(object sender, EventArgs e)
        {
            UpdateVehicleEmission(v8Txt, v8ResultLbl);
            UpdateVehicleEmissions();
        }

        private void v9Txt_TextChanged(object sender, EventArgs e)
        {
            UpdateVehicleEmission(v9Txt, v9ResultLbl);
            UpdateVehicleEmissions();
        }
        private void v10Txt_TextChanged(object sender, EventArgs e)
        {
            UpdateVehicleEmission(v10Txt, v10ResultLbl);
            UpdateVehicleEmissions();
        }

        private void UpdateVehicleEmissions()
        {
            UpdateChartData();
            double totalEmissions = 0;

            for (int i = 0; i < vehicleResultLbl.Length; i++)
            {
                double miles;
                if (!double.TryParse(vehicleTextBoxes[i].Text, out miles) || miles < 0)
                {
                    miles = 0;
                }

                HouseholdVehicle vehicle = new HouseholdVehicle(miles);
                double emission = vehicle.CalculateHV(miles, _emissionPeriod);
                vehicleResultLbl[i].Text = $"{emission:F2}";

                totalEmissions += emission;
            }

            vehicleEmissionOutputLbl.Text = $"Total Emission: {totalEmissions:F2} lb. CO₂";
            storedVehicleTotal.Text = $"{totalEmissions:F2}";
            _totalVehicle = ParseEmissionToDouble(storedVehicleTotal.Text);

            if (totalEmissions < 10484)
            {
                vehicleEmissionOutputLbl.ForeColor = Color.Green;
            }
            else
            {
                vehicleEmissionOutputLbl.ForeColor = Color.Red;
            }
        }

        private void continueBtn1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(100, 255, 218);
            heEmissionPanel.Visible = true;
            vehicularEmissionPanel.Visible = false;
            appEmissionPanel.Visible = false;
            wasteEmissionPanel.Visible = false;
            overallPanel.Visible = false;
        }

        //HOUSEHOLD EMISSION ELEMENTS
        private void exitBtn2_Click(object sender, EventArgs e)
        {
            ExitFX();
            DialogResult result = MessageBox.Show("Are you sure you want to exit the calculator?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void previousBtn1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(163, 18, 133);
            vehicularEmissionPanel.Visible = true;
            heEmissionPanel.Visible = false;
            appEmissionPanel.Visible = false;
            wasteEmissionPanel.Visible = false;
        }

        private UnitType _ngUnitType;
        private UnitType _foUnitType;
        private UnitType _proUnitType;
        private UnitType _elecUnitType;

        private void billNGRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _ngUnitType = UnitType.Bill;
            UpdateNaturalGasUI();
            CalculateNaturalGasEmissions();
            CalculateTotalHomeEnergy();
        }
        private void cubicNGRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _ngUnitType = UnitType.CubicFeet;
            UpdateNaturalGasUI();
            CalculateNaturalGasEmissions();
            CalculateTotalHomeEnergy();
        }
        private void thermNGRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _ngUnitType = UnitType.Therm;
            UpdateNaturalGasUI();
            CalculateNaturalGasEmissions();
            CalculateTotalHomeEnergy();
        }

        private void unapplicableNGRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _ngUnitType = UnitType.None;
            UpdateNaturalGasUI();
            CalculateNaturalGasEmissions();
            CalculateTotalHomeEnergy();
        }
        private void billFORadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _foUnitType = UnitType.Bill;
            UpdateFuelUI();
            CalculateFuelOilEmissions();
            CalculateTotalHomeEnergy();
        }
        private void galFORadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _foUnitType = UnitType.Gallons;
            UpdateFuelUI();
            CalculateFuelOilEmissions();
            CalculateTotalHomeEnergy();
        }
        private void unapplicableFORadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _foUnitType = UnitType.None;
            UpdateFuelUI();
            CalculateFuelOilEmissions();
            CalculateTotalHomeEnergy();
        }
        private void billProRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _proUnitType = UnitType.Bill;
            UpdatePropaneUI();
            CalculatePropaneEmissions();
            CalculateTotalHomeEnergy();
        }
        private void galProRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _proUnitType = UnitType.Gallons;
            UpdatePropaneUI();
            CalculatePropaneEmissions();
            CalculateTotalHomeEnergy();
        }
        private void unapplicableProRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _proUnitType = UnitType.None;
            UpdatePropaneUI();
            CalculatePropaneEmissions();
            CalculateTotalHomeEnergy();
        }
        private void billElecRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _elecUnitType = UnitType.Bill;
            UpdateElectrcityUI();
            CalculateElectricityEmissions();
            CalculateTotalHomeEnergy();
        }
        private void kwhElecRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _elecUnitType = UnitType.kWh;
            UpdateElectrcityUI();
            CalculateElectricityEmissions();
            CalculateTotalHomeEnergy();
        }
        private void unapplicableElecRadioBtn_Click(object sender, EventArgs e)
        {
            SelectFX();
            _elecUnitType = UnitType.None;
            UpdateElectrcityUI();
            CalculateElectricityEmissions();
            CalculateTotalHomeEnergy();
        }
        private void CalculateNaturalGasEmissions()
        {
            if (string.IsNullOrWhiteSpace(NGTbx.Text) || !double.TryParse(NGTbx.Text, out double inputValue))
            {
                NGResultLbl.Text = "0.00";
                return;
            }

            HouseholdHomeEnergy homeEnergyCalc = new HouseholdHomeEnergy(EnergyType.NaturalGas, _ngUnitType, inputValue);
            double result = homeEnergyCalc.CalculateHE(homeEnergyCalc.Energy, homeEnergyCalc.Unit, homeEnergyCalc.Input);
            NGResultLbl.Text = result.ToString("F2");
        }
        private void CalculateFuelOilEmissions()
        {
            if (string.IsNullOrWhiteSpace(FOTbx.Text) || !double.TryParse(FOTbx.Text, out double inputValue))
            {
                FOResultLbl.Text = "0.00";
                return;
            }
            HouseholdHomeEnergy homeEnergyCalc = new HouseholdHomeEnergy(EnergyType.FuelOil, _foUnitType, inputValue);
            double result = homeEnergyCalc.CalculateHE(homeEnergyCalc.Energy, homeEnergyCalc.Unit, homeEnergyCalc.Input);
            FOResultLbl.Text = result.ToString("F2");
        }
        private void CalculatePropaneEmissions()
        {
            if (string.IsNullOrWhiteSpace(ProTbx.Text) || !double.TryParse(ProTbx.Text, out double inputValue))
            {
                ProResultLbl.Text = "0.00";
                return;
            }
            HouseholdHomeEnergy homeEnergyCalc = new HouseholdHomeEnergy(EnergyType.Propane, _proUnitType, inputValue);
            double result = homeEnergyCalc.CalculateHE(homeEnergyCalc.Energy, homeEnergyCalc.Unit, homeEnergyCalc.Input);
            ProResultLbl.Text = result.ToString("F2");
        }
        private void CalculateElectricityEmissions()
        {
            if (string.IsNullOrWhiteSpace(ElecTbx.Text) || !double.TryParse(ElecTbx.Text, out double inputValue))
            {
                ElecResultLbl.Text = "0.00";
                return;
            }
            HouseholdHomeEnergy homeEnergyCalc = new HouseholdHomeEnergy(EnergyType.Electricity, _elecUnitType, inputValue);
            double result = homeEnergyCalc.CalculateHE(homeEnergyCalc.Energy, homeEnergyCalc.Unit, homeEnergyCalc.Input);
            ElecResultLbl.Text = result.ToString("F2");
        }
        private void NGTbx_TextChanged(object sender, EventArgs e)
        {
            CalculateNaturalGasEmissions();
            CalculateTotalHomeEnergy();
        }
        private void FOTbx_TextChanged(object sender, EventArgs e)
        {
            CalculateFuelOilEmissions();
            CalculateTotalHomeEnergy();
        }
        private void ProTbx_TextChanged(object sender, EventArgs e)
        {
            CalculatePropaneEmissions();
            CalculateTotalHomeEnergy();
        }
        private void ElecTbx_TextChanged(object sender, EventArgs e)
        {
            CalculateElectricityEmissions();
            CalculateTotalHomeEnergy();
        }
        private void UpdateNaturalGasUI()
        {
            billNGRadioBtn.Image = _ngUnitType == UnitType.Bill ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
            cubicNGRadioBtn.Image = _ngUnitType == UnitType.CubicFeet ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
            thermNGRadioBtn.Image = _ngUnitType == UnitType.Therm ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
            unapplicableNGRadioBtn.Image = _ngUnitType == UnitType.None ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
        }
        private void UpdateFuelUI()
        {
            billFORadioBtn.Image = _foUnitType == UnitType.Bill ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
            galFORadioBtn.Image = _foUnitType == UnitType.Gallons ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
            unapplicableFORadioBtn.Image = _foUnitType == UnitType.None ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
        }
        private void UpdatePropaneUI()
        {
            billProRadioBtn.Image = _proUnitType == UnitType.Bill ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
            galProRadioBtn.Image = _proUnitType == UnitType.Gallons ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
            unapplicableProRadioBtn.Image = _proUnitType == UnitType.None ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
        }
        private void UpdateElectrcityUI()
        {
            billElecRadioBtn.Image = _elecUnitType == UnitType.Bill ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
            kwhElecRadioBtn.Image = _elecUnitType == UnitType.kWh ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
            unapplicableElecRadioBtn.Image = _elecUnitType == UnitType.None ? Properties.Resources.sprite_fillBtn : Properties.Resources.sprite_emptyBtn;
        }
        private void CalculateTotalHomeEnergy()
        {
            UpdateChartData();
            double totalEmissions = 0;
            foreach (Label lbl in heResultLbl)
            {
                string labelText = lbl.Text;
                if (double.TryParse(labelText, NumberStyles.Any, CultureInfo.InvariantCulture, out double emission))
                {
                    totalEmissions += emission;
                }
            }
            heEmissionOutputLbl.Text = $"Total Emission: {totalEmissions:F2} lb. CO₂";
            storedHomeEnergyTotal.Text = $"{totalEmissions:F2}";
            _totalHomeEnergy = ParseEmissionToDouble(storedHomeEnergyTotal.Text);

            if (totalEmissions < 14020)
            {
                heEmissionOutputLbl.ForeColor = Color.Green;
            }
            else
            {
                heEmissionOutputLbl.ForeColor = Color.Red;
            }
        }
        //appliances
        private void continueBtn2_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 142, 236);
            appEmissionPanel.Visible = true;
            heEmissionPanel.Visible = false;
            vehicularEmissionPanel.Visible = false;
            wasteEmissionPanel.Visible = false;
            overallPanel.Visible = false;
        }
        private void previousBtn2_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(100, 255, 218);
            appEmissionPanel.Visible = false;
            heEmissionPanel.Visible = true;
            vehicularEmissionPanel.Visible = false;
            wasteEmissionPanel.Visible = false;
        }
        private void exitBtn3_Click(object sender, EventArgs e)
        {
            ExitFX();
            DialogResult result = MessageBox.Show("Are you sure you want to exit the calculator?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void InitializeDevices()
        {
            //numeric drop down
            for (int i = 0; i < applianceNumeric.Length; i++)
            {
                applianceNumeric[i].Enabled = false;
                applianceNumeric[i].ValueChanged += (sender, e) => CalculateAppliancesTotalEmission();
            }
            //combobox
            for (int i = 0; i < applianceComboBox.Length; i++)
            {
                applianceComboBox[i].Enabled = false;
                applianceComboBox[i].SelectedIndexChanged += (sender, e) => CalculateAppliancesTotalEmission();
            }
            //tbx
            for (int i = 0; i < applianceTextBoxes.Length; i++)
            {
                applianceTextBoxes[i].Enabled = false;
                applianceTextBoxes[i].TextChanged += (sender, e) => CalculateAppliancesTotalEmission();
            }
        }

        private HouseholdAppliances appliancesCalculator = new HouseholdAppliances();
        private void deviceCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index;
            if (e.NewValue == CheckState.Checked)
            {
                applianceNumeric[index].Enabled = true;
                applianceComboBox[index].Enabled = true;
                applianceTextBoxes[index].Enabled = true;
                majorDevLbl.Text = "None";
                majorDevLbl.ForeColor = Color.Gray;
                CalculateAppliancesTotalEmission();
            }
            else
            {
                applianceNumeric[index].Enabled = false;
                applianceComboBox[index].Enabled = false;
                applianceTextBoxes[index].Enabled = false;
                applianceNumeric[index].Value = 0;
                applianceComboBox[index].SelectedIndex = -1;
                applianceTextBoxes[index].Text = "";
                majorDevLbl.Text = "None";
                majorDevLbl.ForeColor = Color.Gray;
                CalculateAppliancesTotalEmission();
            }
        }

        private void CalculateAppliancesTotalEmission()
        {
            UpdateChartData();
            try
            {
                double totalEmission = 0;
                double maxEmission = 0;
                string majorDevice = "None";
                for (int i = 0; i < deviceCheckList.Items.Count; i++)
                {
                    if (deviceCheckList.GetItemChecked(i))
                    {
                        string deviceType = deviceCheckList.Items[i].ToString();
                        int numberOfDevices = (int)applianceNumeric[i].Value;
                        double powerConsumption = GetPowerConsumption(deviceType, i);
                        double usageTime = GetUsageTimeFromComboBox(i);
                        double carbonFootprint = appliancesCalculator.CalculateCarbonFootprint(
                            deviceType,
                            numberOfDevices,
                            powerConsumption,
                            usageTime,
                            "Per Day"
                        );
                        totalEmission += carbonFootprint;
                        if (carbonFootprint > maxEmission)
                        {
                            maxEmission = carbonFootprint;
                            majorDevice = deviceType;
                        }
                    }
                }

                appEmissionOutputLbl.Text = $"Total Emission: {totalEmission:F2} lb. CO₂";
                storedAppTotal.Text = $"{totalEmission:F2}";
                _totalAppliance = ParseEmissionToDouble(storedAppTotal.Text);

                if (appEmissionOutputLbl.Text == "Total Emission: 0.00 lb. CO₂")
                {
                    majorDevLbl.Text = "None";
                    majorDevLbl.ForeColor = Color.Gray;
                }
                else
                {
                    majorDevLbl.Text = $"{majorDevice}";
                    majorDevLbl.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                appEmissionOutputLbl.Text = "Error: Invalid input";
                majorDevLbl.Text = "None";
            }
        }
        private double GetPowerConsumption(string deviceType, int index)
        {
            if (double.TryParse(applianceTextBoxes[index].Text, out double powerConsumption) && powerConsumption > 0)
            {
                return powerConsumption;
            }
            else
            {
                return appliancesCalculator.GetDefaultPowerConsumption(deviceType);
            }
        }
        private double GetUsageTimeFromComboBox(int index)
        {
            string timePeriod = applianceComboBox[index].SelectedItem?.ToString();
            switch (timePeriod)
            {
                case "Per Day": return 365;
                case "Per Week": return 52;
                case "Per Month": return 12;
                case "Per Year": return 1;
                default: return 365;
            }
        }
        private void continueBtn3_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(188, 188, 188);
            wasteEmissionPanel.Visible = true;
            appEmissionPanel.Visible = false;
            heEmissionPanel.Visible = false;
            vehicularEmissionPanel.Visible = false;
            overallPanel.Visible = false;
        }

        //waste

        private void exitBtn4_Click(object sender, EventArgs e)
        {
            ExitFX();
            DialogResult result = MessageBox.Show("Are you sure you want to exit the calculator?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void previousBtn3_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 142, 236);
            wasteEmissionPanel.Visible = false;
            appEmissionPanel.Visible = true;
            heEmissionPanel.Visible = false;
            vehicularEmissionPanel.Visible = false;
        }

        private void InitializeHouseholdMembers()
        {
            numHouseholdMembers.Minimum = 1;
            numHouseholdMembers.Maximum = 20;
            numHouseholdMembers.Value = 1;
            CalculateWasteEmission();
        }
        private void CalculateWasteEmission()
        {
            UpdateChartData();
            try
            {
                int members = (int)numHouseholdMembers.Value;
                var recyclingOptions = new RecyclingOptions
                {
                    RecyclesMetal = recycleChecklist.CheckedItems.Contains("Metal"),
                    RecyclesPlastic = recycleChecklist.CheckedItems.Contains("Plastic"),
                    RecyclesGlass = recycleChecklist.CheckedItems.Contains("Glass"),
                    RecyclesNewspaper = recycleChecklist.CheckedItems.Contains("Newspaper"),
                    RecyclesMagazine = recycleChecklist.CheckedItems.Contains("Magazine")
                };

                var calculator = new HouseholdWasteCalculator();
                double emissions = calculator.CalculateWasteEmission(members, recyclingOptions);
                double averagePerHM = members * 692;

                wasteEmissionOutputLbl.Text = $"Total emission: {emissions:F2} lb. CO₂";
                storedWasteTotal.Text = $"{emissions:F2}";
                _totalWaste = ParseEmissionToDouble(storedWasteTotal.Text);
                averagePerPersonLbl.Text = $"Reminder: {averagePerHM:F2} pounds of carbon dioxide \r\nis the yearly average per household members.\r\n";

                double potentialSavings = calculator.GetPotentialSavings(new RecyclingOptions
                {
                    RecyclesMetal = true,
                    RecyclesPlastic = true,
                    RecyclesGlass = true,
                    RecyclesNewspaper = true,
                    RecyclesMagazine = true
                });

                double currentSavings = calculator.GetPotentialSavings(recyclingOptions);
                double savingsPercentage = potentialSavings > 0 ? (currentSavings / potentialSavings) * 100 : 0;
                lblSavings.Text = $"Recycling effectiveness: {savingsPercentage:F0}%";
            }
            catch (Exception ex)
            {
                wasteEmissionOutputLbl.Text = "Error";
                MessageBox.Show($"Error calculating waste: {ex.Message}");
            }
        }

        private void recycleChecklist_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                CalculateWasteEmission();
            });
        }

        private void numHouseholdMembers_ValueChanged(object sender, EventArgs e)
        {
            CalculateWasteEmission();
        }

        private void continueBtn4_Click(object sender, EventArgs e)
        {
            overallPanel.Visible = true;
            appEmissionPanel.Visible = false;
            heEmissionPanel.Visible = false;
            vehicularEmissionPanel.Visible = false;
            wasteEmissionPanel.Visible = false;
        }

        private void exitBtn5_Click(object sender, EventArgs e)
        {
            ExitFX();
            DialogResult result = MessageBox.Show("Are you sure you want to exit the calculator?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private double ParseEmissionToDouble(string text)
        {
            string clean = new string(text.Where(c => char.IsDigit(c) || c == '.').ToArray());
            return double.TryParse(clean, out double val) ? val : 0;
        }

        private void InitializeChart(string username)
        {
            var plotModel = new PlotModel
            {
                Title = $"{username}'s Carbon Footprint",
                Subtitle = "CO₂ Equivalent by Category",
                DefaultFont = "Minecraft",
                TitleFontSize = 50,
                SubtitleFontSize = 30,
                DefaultFontSize = 14,
            };

            // FIX: Move CategoryAxis to the Y-Axis (instead of X-Axis)
            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,  // MOVED TO LEFT (Y-Axis)
                Title = "Category",
                Key = "Categories"
            };
            categoryAxis.Labels.Add("Vehicle");
            categoryAxis.Labels.Add("Home Energy");
            categoryAxis.Labels.Add("Appliances");
            categoryAxis.Labels.Add("Waste");

            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,  // MOVED TO BOTTOM (X-Axis)
                Title = "lb. CO₂",
                Minimum = 0,
                MaximumPadding = 0.1,
                MajorGridlineStyle = LineStyle.Solid,
                MajorGridlineColor = OxyColor.FromArgb(128, 211, 211, 211)
            };

            plotModel.Axes.Add(categoryAxis);
            plotModel.Axes.Add(valueAxis);

            var barSeries = new BarSeries
            {
                Title = "Emissions (lb. CO₂)",
                FillColor = OxyColor.FromRgb(70, 130, 180),
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1,
                YAxisKey = "Categories"
            };

            barSeries.Items.Add(new BarItem { Value = _totalVehicle });
            barSeries.Items.Add(new BarItem { Value = _totalHomeEnergy });
            barSeries.Items.Add(new BarItem { Value = _totalAppliance });
            barSeries.Items.Add(new BarItem { Value = _totalWaste });

            plotModel.Series.Add(barSeries);

            emissionPlot.Model = plotModel;
        }

        public void UpdateChartData()
        {

            if (emissionPlot.Model is PlotModel model &&
                model.Series[0] is BarSeries series)
            {
                series.Items[0].Value = _totalVehicle;
                series.Items[1].Value = _totalHomeEnergy;
                series.Items[2].Value = _totalAppliance;
                series.Items[3].Value = _totalWaste;

                if (model.Series.Count > 1 && model.Series[1] is BarSeries labels)
                {
                    labels.Items[0].Value = _totalVehicle;
                    labels.Items[1].Value = _totalHomeEnergy;
                    labels.Items[2].Value = _totalAppliance;
                    labels.Items[3].Value = _totalWaste;

                    // Ensure label format includes lbs (if not already set)
                    labels.LabelFormatString = "{0:.0} lb.";
                }

                // Refresh the chart
                emissionPlot.InvalidatePlot(true);
                _displayOverallTotal = _totalVehicle + _totalHomeEnergy + _totalAppliance + _totalWaste;
                overallTotalLbl.Text = $"Overall Total Emission: {_displayOverallTotal:F2} lbs. CO₂";
            }
        }

        private void previousBtn4_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(188, 188, 188);
            wasteEmissionPanel.Visible = true;
            appEmissionPanel.Visible = false;
            heEmissionPanel.Visible = false;
            vehicularEmissionPanel.Visible = false;
            overallPanel.Visible = false;
        }

        private void showSaveBtn(bool saveData)
        {
            if (saveData == true)
            {
                saveLbl.Visible = true;
                saveBtn.Visible = true;
            }
            else
            {
                saveLbl.Visible = false;
                saveBtn.Visible = false;
            }
        }

        private void SelectSaveFX()
        {
            string soundPath = Path.Combine("assets", "Audio", "audio_selectSave.wav");
            _soundManager.PlaySoundEffect(soundPath);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SelectSaveFX();
            try
            {
                DialogResult result = MessageBox.Show(
                    "Do you want to save your calculated emission?",
                    "Confirm Save",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }

                if (string.IsNullOrEmpty(_username))
                {
                    MessageBox.Show("Invalid username!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CarbonFootprintRepository repository = new CarbonFootprintRepository();

                int userId = repository.GetUserId(_username);
                if (userId == 0)
                {
                    MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    bool isSaved = repository.SaveFootprint(userId, _totalVehicle, _totalHomeEnergy, _totalAppliance, _totalWaste);

                    if (isSaved)
                    {
                        MessageBox.Show("Emission data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save emission data.\n\nError Details:\n{ex.Message}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deviceCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateAppliancesTotalEmission();
        }

        //mousehover fx
        private void saveBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(saveBtn, saveLbl, 
                Properties.Resources.sprite_saveBtn, _originalSave, true);
        }

        private void saveBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(saveBtn, saveLbl,
                Properties.Resources.sprite_saveBtn, _originalSave, false);
        }

        private void previousBtn4_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(previousBtn4, previousLbl4,
                Properties.Resources.sprite_previousAlt, _originalPrevious, true);
        }

        private void previousBtn4_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(previousBtn4, previousLbl4,
                Properties.Resources.sprite_previousAlt, _originalPrevious, false);
        }
        private void exitBtn5_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(exitBtn5, exitLbl5,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, true);
        }

        private void exitBtn5_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(exitBtn5, exitLbl5,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, false);
        }

        private void exitBtn4_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(exitBtn4, exitLbl4,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, true);
        }

        private void exitBtn4_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(exitBtn4, exitLbl4,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, false);
        }

        private void previousBtn3_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(previousBtn3, previousLbl3,
                Properties.Resources.sprite_previousAlt, _originalPrevious, true);
        }

        private void previousBtn3_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(previousBtn3, previousLbl3,
                Properties.Resources.sprite_previousAlt, _originalPrevious, false);
        }

        private void continueBtn4_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(continueBtn4, continueLbl4,
                Properties.Resources.sprite_continueAltBtn, _originalContinue, true);
        }

        private void continueBtn4_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(continueBtn4, continueLbl4,
                Properties.Resources.sprite_continueAltBtn, _originalContinue, false);
        }

        private void exitBtn3_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(exitBtn3, exitLbl3,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, true);
        }
        private void exitBtn3_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(exitBtn3, exitLbl3,
                Properties.Resources.sprite_exitBtnLarge, _originalExit, false);
        }

        private void continueBtn3_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(continueBtn3, continueLbl3,
                Properties.Resources.sprite_continueAltBtn, _originalContinue, true);
        }
        private void continueBtn3_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(continueBtn3, continueLbl3,
                Properties.Resources.sprite_continueAltBtn, _originalContinue, false);
        }

        private void previousBtn2_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(previousBtn2, previousLbl2,
                Properties.Resources.sprite_previousAlt, _originalPrevious, true);
        }

        private void previousBtn2_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(previousBtn2, previousLbl2,
                Properties.Resources.sprite_previousAlt, _originalPrevious, false);
        }

        private void exitBtn2_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(exitBtn2, exitLbl2,
            Properties.Resources.sprite_exitBtnLarge, _originalExit, true);
        }

        private void exitBtn2_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(exitBtn2, exitLbl2,
            Properties.Resources.sprite_exitBtnLarge, _originalExit, false);
        }

        private void previousBtn1_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(previousBtn1, previous1Lbl,
                Properties.Resources.sprite_previousAlt, _originalPrevious, true);
        }

        private void previousBtn1_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(previousBtn1, previous1Lbl,
                Properties.Resources.sprite_previousAlt, _originalPrevious, false);
        }

        private void continueBtn2_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(continueBtn2, continue2Lbl,
                Properties.Resources.sprite_continueAltBtn, _originalContinue, true);
        }

        private void continueBtn2_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(continueBtn2, continue2Lbl,
                Properties.Resources.sprite_continueAltBtn, _originalContinue, false);
        }

        private void continueBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(continueBtn1, continueLbl1,
            Properties.Resources.sprite_continueAltBtn, _originalContinue, true);
        }

        private void continueBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(continueBtn1, continueLbl1,
            Properties.Resources.sprite_continueAltBtn, _originalContinue, false);
        }

        private void exitBtn_MouseEnter(object sender, EventArgs e)
        {
            ChooseFX();
            MouseEventsUtilityDashboard.ApplyHoverEffect(exitBtn1, exitLbl1,
            Properties.Resources.sprite_exitBtnLarge, _originalExit, true);
        }

        private void exitBtn_MouseLeave(object sender, EventArgs e)
        {
            MouseEventsUtilityDashboard.ApplyHoverEffect(exitBtn1, exitLbl1,
            Properties.Resources.sprite_exitBtnLarge, _originalExit, false);
        }
    }
}
