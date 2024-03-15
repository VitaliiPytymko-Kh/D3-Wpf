using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.ViewModel
{
    public class RelayCommand:ICommand
    {
        private Action<object> _execute;
        private Func<object,bool> _canExecute;
    
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute=null)
        {
            _execute = execute?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

    }
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove {  CommandManager.RequerySuggested -= value;}
    }

    public bool CanExecute(object parametr)
    {
        _execute(parametr);
    }
}
