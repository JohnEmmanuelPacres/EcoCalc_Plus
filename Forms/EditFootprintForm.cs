using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoCalc_Plus
{
    public partial class EditFootprintForm : UserControl
    {
        public int FootprintId { get; private set; }
        public double VehicleEmission { get; private set; }
        public double HomeEnergyEmission { get; private set; }
        public double ApplianceEmission { get; private set; }
        public double WasteEmission { get; private set; }

        public event EventHandler<DialogResult> FormClosed;

        public EditFootprintForm(int footprintId, double vehicle, double homeEnergy, double appliance, double waste)
        {
            InitializeComponent();
            FootprintId = footprintId;

            vehicleTxt.Text = vehicle.ToString("0.##");
            homeEnergyTxt.Text = homeEnergy.ToString("0.##");
            applianceTxt.Text = appliance.ToString("0.##");
            wasteTxt.Text = waste.ToString("0.##");

            SetupValidation();
            cancelBtn.Click += cancelBtn_Click;
        }

        private void SetupValidation()
        {
            vehicleTxt.KeyPress += NumericTextBox_KeyPress;
            homeEnergyTxt.KeyPress += NumericTextBox_KeyPress;
            applianceTxt.KeyPress += NumericTextBox_KeyPress;
            wasteTxt.KeyPress += NumericTextBox_KeyPress;
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as KryptonTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                VehicleEmission = double.Parse(vehicleTxt.Text);
                HomeEnergyEmission = double.Parse(homeEnergyTxt.Text);
                ApplianceEmission = double.Parse(applianceTxt.Text);
                WasteEmission = double.Parse(wasteTxt.Text);

                FormClosed?.Invoke(this, DialogResult.OK);
            }
        }

        private bool ValidateInputs()
        {
            if (!double.TryParse(vehicleTxt.Text, out double vehicle) || vehicle < 0)
            {
                MessageBox.Show("Please enter a valid positive number for Vehicle Emission.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                vehicleTxt.Focus();
                return false;
            }

            if (!double.TryParse(homeEnergyTxt.Text, out double homeEnergy) || homeEnergy < 0)
            {
                MessageBox.Show("Please enter a valid positive number for Home Energy Emission.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                homeEnergyTxt.Focus();
                return false;
            }

            if (!double.TryParse(applianceTxt.Text, out double appliance) || appliance < 0)
            {
                MessageBox.Show("Please enter a valid positive number for Appliance Emission.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                applianceTxt.Focus();
                return false;
            }

            if (!double.TryParse(wasteTxt.Text, out double waste) || waste < 0)
            {
                MessageBox.Show("Please enter a valid positive number for Waste Emission.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                wasteTxt.Focus();
                return false;
            }

            return true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            var hostForm = this.FindForm();
            if (hostForm != null)
            {
                hostForm.DialogResult = DialogResult.Cancel;
                hostForm.Close(); 
            }
        }
    }
}
