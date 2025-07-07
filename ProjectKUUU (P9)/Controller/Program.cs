using System;
using System.Windows.Forms;
using ProjectKUUU.View;


namespace ProjectKUUU.Controller
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (LoginForm loginForm = new LoginForm())
            {
                var result = loginForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Application.Run(new MainForm());
                }
                else
                {
                    // User menutup form login atau klik Cancel → keluar
                    Application.Exit();
                }
            }
        }
    }
}
