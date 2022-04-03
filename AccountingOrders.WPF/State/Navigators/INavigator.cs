using AccountingOrders.WPF.ViewsModels;
using System;

namespace AccountingOrders.WPF.State.Navigators
{
    public enum ViewType
    {
        Department,
        Order,
        User,
        AddDepartment,
        AddUser,
        AddOrder,
        EditDepartment,
        EditUser,
        EditOrder,
        ViewDepartment,
        ViewUser,
        ViewOrder,
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}