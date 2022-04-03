using AccountingOrders.WPF.State.Navigators;

namespace AccountingOrders.WPF.ViewsModels.Factories
{
    public interface IAccountingOrdersViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}