using System.Security.Principal;

namespace dns_changer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            if (isAdmin)
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("Please run the application as administrator.");
                Application.Exit();
            }
        }
    }
}