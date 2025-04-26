namespace EcoCalc_Plus.UtilityClass
{
    public class MouseEventsUtilityGeneral
    {
        public static void ApplyHoverEffect(PictureBox button, Image hoverImage, Image originalImage, bool isMouseEnter)
        {
            if (isMouseEnter)
            {
                button.Cursor = Cursors.Hand;
                if (button.Image != hoverImage)
                {
                    button.Image = hoverImage;
                }
            }
            else
            {
                button.Cursor = Cursors.Default;
                if (button.Image != originalImage)
                {
                    button.Image = originalImage;
                }
            }
        }
    }
}
