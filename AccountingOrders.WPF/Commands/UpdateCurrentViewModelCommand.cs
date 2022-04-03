using AccountingOrders.WPF.State.Navigators;
using AccountingOrders.WPF.ViewsModels.Factories;
using System;
using System.Windows.Input;

namespace AccountingOrders.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly INavigator _navigator;

        private readonly IAccountingOrdersViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IAccountingOrdersViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public event EventHandler? CanExecuteChanged 
        {
            add { }
            remove { }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType viewType) 
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
        }
    }
}