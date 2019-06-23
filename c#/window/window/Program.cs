﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace window
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Login());
            } catch(Exception ec) {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
