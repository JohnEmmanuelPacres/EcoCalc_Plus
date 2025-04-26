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
    public partial class LoadingScreen: Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
            panel2.Parent = loadBG;
        }
    }
}
