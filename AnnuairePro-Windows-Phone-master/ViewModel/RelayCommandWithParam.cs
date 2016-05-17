using System;
using System.Windows.Input;

namespace AnnuairePro.ViewModel
{
    public class RelayCommandWithParam<T> : ICommand
    {
        private readonly Action<T> _actionAExecuter = null;
        public event EventHandler CanExecuteChanged;

        public RelayCommandWithParam(Action<T> action)
        {
            _actionAExecuter = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            T myParam;
            if (parameter is T)
                myParam = (T)parameter;
            else
            {
                try
                {
                    myParam = (T)Convert.ChangeType(parameter, typeof(T));
                }
                catch (InvalidCastException)
                {
                    myParam = default(T);
                }
            }
            _actionAExecuter(myParam);
        }
    }
}
