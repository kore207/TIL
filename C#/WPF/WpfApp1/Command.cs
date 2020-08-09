using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfApp1
{
    public class CommandTemp : ICommand
    {
        Action<object> _executeMethod; //버튼 클릭시 수행할 action
        Func<object, bool> _canexecuteMethod; // Action 수행전 필요한 조건을 검사하는 Func

        public CommandTemp(Action<object> executeMethod, Func<object, bool> canexecuteMethod)
        {
            this._executeMethod = executeMethod;
            this._canexecuteMethod = canexecuteMethod;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; //따로 조건을 두지 않는다. 
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }
    }
}
