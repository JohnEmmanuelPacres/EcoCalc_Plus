namespace EcoCalc_Plus.UtilityClass
{
    public static class MouseEventsUtilityDashboard
    {
        public static void ApplyHoverEffect(PictureBox button, Label label, Image hoverImage, Image originalImage, bool isMouseEnter)
        {
            if (isMouseEnter)
            {
                button.Cursor = Cursors.Hand;
                if (button.Image != hoverImage)
                {
                    button.Image = hoverImage;
                    label.Visible = true;
                }
            }
            else
            {
                button.Cursor = Cursors.Default;
                if (button.Image != originalImage)
                {
                    button.Image = originalImage;
                    label.Visible = false;
                }
            }
        }
    }
}
