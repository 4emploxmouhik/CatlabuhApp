using CatlabuhApp.Data.Access;
using CatlabuhApp.Data.Models;
using CatlabuhApp.UI.Main.Forms;
using CatlabuhApp.UI.Support.Setups;
using CatlabuhApp.UI.Support.Dialogs;
using System;
using System.Windows.Forms;
using System.ComponentModel;
using CatlabuhAppSupportHelp.UI.Help;
using System.IO;

namespace CatlabuhApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (CatlabuhAppDBException) { }
        }
    }
}


