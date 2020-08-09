using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    public class ViewModel
    {
        public ICommand MyCommand { get; set; }

        public ViewModel()
        {
            MyCommand = new CommandTemp(executeMethod, canexecuteMethod);
        }

        private bool canexecuteMethod(object arg)
        {
            return true;
        }

        private void executeMethod(object obj)
        {
            MessageBox.Show("코드 비하인드가 아닌 Command ExecuteMethod");
        }
    }
}
