using System;
using System.Windows.Forms;
using MathRushWinForms.forms;

namespace MathRushWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize(); // Untuk .NET 6 ke atas
            Application.Run(new Form1()); // Ganti ke ScoreForm jika ScoreForm adalah form utama
        }
    }
}