namespace EcoCalc_Plus
{
    internal static class Program
    {
        public static TitleScreen titleScreen;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // Initialize application configuration (DPI, font, etc.)
            ApplicationConfiguration.Initialize();

            // UI thread
            LoadingScreen loadingScreen = new LoadingScreen();
            loadingScreen.Show();
            Application.DoEvents(); // Ensure loading screen is displayed

            // 2. Perform loading tasks (in a background thread)
            Task.Run(() =>
            {
                // Simulate loading (replace with your actual initialization)
                Thread.Sleep(3000);

                // **Important:**actual initialization code here!
                //  - Database connection
                //  - Loading large data
                //  - Initializing ML models

                // 3. Close loading screen and show main form (on the UI thread)
                loadingScreen.Invoke((MethodInvoker)delegate
                {
                    titleScreen = new TitleScreen(); // Create TitleScreen
                    titleScreen.Show(); // Show the main form
                    loadingScreen.Close(); // Close the loading screen
                });
            });
            Application.Run();
        }
        public static void RestartApplication()
        {
            foreach (Form form in Application.OpenForms.OfType<Form>().ToList())
            {
                form.Close();
            }
            Application.Restart();
            Environment.Exit(0); 
        }
    }
}