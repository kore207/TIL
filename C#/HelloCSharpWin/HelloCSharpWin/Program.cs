﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HelloCSharpWin
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main() //프로그램의 시작점 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Calculator());
        }
    }
}
