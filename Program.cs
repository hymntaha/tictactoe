﻿/**
 * Author: Taha Uygun
 * Mail Control TicTacToe
 */

using System;
using System.Windows.Forms;
using TicTacToe.Forms;

namespace TicTacToe
{
    static class Program
    {
        /**
         * Main pipeline
         */
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
