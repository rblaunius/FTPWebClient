namespace FTPWebClient
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
            ApplicationConfiguration.Initialize();
            string cs = XpoHelper.GetXmlConnectionString(1);
            XpoHelper.Connection conn = XpoHelper.Connect(cs);
            if (conn.IsSuccessful)
            {
                Application.Run(new Forms.Home());
            }
            else
            {
                MessageBox.Show(conn.ErrMsg);
            }
        }
    }
}