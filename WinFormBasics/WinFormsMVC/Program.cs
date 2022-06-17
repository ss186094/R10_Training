namespace WinFormsMVC
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // ApplicationConfiguration.Initialize();

            UserInfo info = new UserInfo();
            
            var f1 = new btnnext();
            f1.UserInfo = info;
            f1.ShowDialog();

            var f2 = new View.SecondForm();
            f2.UserInfo = info;
            f2.ShowDialog();
            //Application.Run(new Form1());
        }
    }
}