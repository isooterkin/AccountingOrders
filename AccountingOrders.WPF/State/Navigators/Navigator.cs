using AccountingOrders.WPF.Commands;
using AccountingOrders.WPF.ViewsModels;
using System;
using System.Windows.Input;

namespace AccountingOrders.WPF.State.Navigators
{
    public class Navigator : INavigator
    {

        private ViewModelBase? _currentViewModel;


        public ViewModelBase CurrentViewModel
        {
            #pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            get => _currentViewModel;
            #pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }

        public event Action? StateChanged;

        // public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}