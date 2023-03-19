using System;
using System.Windows.Input;

namespace DiseñoAppModerno.Core
{
    internal class RelayCommand : ICommand
    {

        private Action<object> _execute;
        private Func<object,bool> _canExecute; /* Esto significa que _canExecute es una referencia a una función que toma un objeto como parámetro y devuelve un bool.*/


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
      
        public bool CanExecute(object parameter)
        {
            return  _canExecute==null ||  _canExecute(parameter); 
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

    }
}

