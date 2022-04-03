﻿using System;
using System.Windows.Input;

namespace AccountingOrders.WPF.Commands.RelayCommand
{
    public class RelayCommand: ICommand
    {
        private readonly Action<object> execute;

        private readonly Func<object, bool> canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        
        public bool CanExecute(object? parameter)
        {
            if (parameter == null) return false;
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            if (parameter != null) execute(parameter);
        }
    }
}