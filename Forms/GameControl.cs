using System;
using System.Drawing;
using System.Windows.Forms;
using EcoCalc_Plus.UtilityClass;

namespace EcoCalc_Plus
{
    public partial class GameControl : UserControl
    {
        private Image _originalExit;
        private GameControl()
        {
            InitializeComponent();
            exitBtn.Image = _originalExit;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
