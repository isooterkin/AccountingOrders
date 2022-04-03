using AccountingOrders.WPF.Commands;
using AccountingOrders.WPF.Commands.RelayCommand;
using AccountingOrders.WPF.State.Navigators;
using AccountingOrders.WPF.ViewsModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AccountingOrders.WPF.ViewsModels
{
    public class MainViewModel: ViewModelBase
    {
        private readonly IAccountingOrdersViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, IAccountingOrdersViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;

            _navigator.StateChanged += NavigatorStateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Department);
        }

        private void NavigatorStateChanged() => OnPropertyChanged(nameof(CurrentViewModel));

        public override void Dispose()
        {
            _navigator.StateChanged -= NavigatorStateChanged;

            base.Dispose();
        }
    }
}