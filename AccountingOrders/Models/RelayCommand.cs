using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingOrders.Models
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        #pragma warning disable CS8612 // Допустимость значения NULL для ссылочных типов в типе не совпадает с явно реализованным членом.
        public event EventHandler CanExecuteChanged
        #pragma warning restore CS8612 // Допустимость значения NULL для ссылочных типов в типе не совпадает с явно реализованным членом.
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        #pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
            this.execute = execute;
            #pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            this.canExecute = canExecute;
            #pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
        }

        #pragma warning disable CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        public bool CanExecute(object parameter)
        #pragma warning restore CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        #pragma warning disable CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        public void Execute(object parameter)
        #pragma warning restore CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        {
            this.execute(parameter);
        }
    }
}