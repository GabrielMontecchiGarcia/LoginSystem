using LoginSystem.Context;
using LoginSystem.Forms;
using LoginSystem.Models;

namespace LoginSystem
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
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var db = new AppDBcontext())
            {
                db.Database.EnsureCreated();
            }
            while (true)
            {
                using (var LoginForm = new LoginForm())
                {
                    var result = LoginForm.ShowDialog();
                    if(result == DialogResult.OK && Session.LoggedUser != null)
                    {
                        Application.Run(new MainForm());
                    }
                    else
                    {
                        break;
                    }
                }
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());

        }
    }
}