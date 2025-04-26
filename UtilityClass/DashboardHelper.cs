using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCalc_Plus.UtilityClass
{
    class DashboardHelper
    {
        public static void SetParent(Control child, Control parent)
        {
            child.Parent = parent;
        }

        public static void StoreOriginalImages(Dictionary<PictureBox, Image> imageDictionary, params PictureBox[] buttons)
        {
            foreach (var button in buttons)
            {
                if (!imageDictionary.ContainsKey(button))
                    imageDictionary[button] = button.Image;
            }
        }
    }
}
