﻿using System;
using System.Windows.Forms;

namespace WebsiteConnectivityChecker
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var applicationContext = new SystemTray();
            Application.Run(applicationContext);
        }
    }
}