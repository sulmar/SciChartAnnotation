﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SciChartAnnotation.Commands
{
    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        #endregion // Fields

        #region Constructors


        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            CanExecuteChanged?.Invoke(this, e);
        }

        public event EventHandler CanExecuteChanged;


        #endregion // ICommand Members
    }
}
