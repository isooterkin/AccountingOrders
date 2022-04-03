using AccountingOrders.WPF.State.Navigators;
using AccountingOrders.WPF.Tools;
using System.Windows;

namespace AccountingOrders.WPF.ViewsModels.Factories
{
    public interface IAccountingOrdersViewFactory
    {
        Window CreateView<T>(ViewType viewType, T? tableList = null) where T : class;

        Window CreateView(ViewType viewType);
    }
}