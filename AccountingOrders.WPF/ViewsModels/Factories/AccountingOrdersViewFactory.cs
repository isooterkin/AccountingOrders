using AccountingOrders.Domain.Models;
using AccountingOrders.WPF.State.Navigators;
using AccountingOrders.WPF.Tools;
using AccountingOrders.WPF.Views.Actions;
using AccountingOrders.WPF.ViewsModels.Actions;
using System;
using System.Windows;

namespace AccountingOrders.WPF.ViewsModels.Factories
{
    public class AccountingOrdersViewFactory : IAccountingOrdersViewFactory
    {
        private readonly IAccountingOrdersViewModelFactory _viewModelFactory;

        public AccountingOrdersViewFactory(IAccountingOrdersViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }


        public Window CreateView<T>(ViewType viewType, T? tableList = null) where T : class
        {
            switch (viewType)
            {
                case ViewType.AddDepartment:
                    AddDepartmentViewModel addDepartmentViewModel = (AddDepartmentViewModel)_viewModelFactory.CreateViewModel(viewType);
                    addDepartmentViewModel.AllDepartments = tableList as ObservableCollectionImproved<DepartmentModel>;
                    return new AddDepartmentView(addDepartmentViewModel);
                case ViewType.AddOrder:
                    AddOrderViewModel addOrderViewModel = (AddOrderViewModel)_viewModelFactory.CreateViewModel(viewType);
                    addOrderViewModel.AllOrders = tableList as ObservableCollectionImproved<OrderModel>;
                    return new AddOrderView(addOrderViewModel);
                case ViewType.AddUser:
                    AddUserViewModel addUserViewModel = (AddUserViewModel)_viewModelFactory.CreateViewModel(viewType);
                    addUserViewModel.AllUsers = tableList as ObservableCollectionImproved<UserModel>;
                    return new AddUserView(addUserViewModel);
                case ViewType.EditDepartment:
                    EditDepartmentViewModel viewModel = (EditDepartmentViewModel)_viewModelFactory.CreateViewModel(viewType);
                    viewModel.AllDepartments = tableList as ObservableCollectionImproved<DepartmentModel>;
                    return new AddDepartmentView(viewModel);
                case ViewType.EditOrder:
                    EditOrderViewModel editOrderViewModel = (EditOrderViewModel)_viewModelFactory.CreateViewModel(viewType);
                    editOrderViewModel.AllOrders = tableList as ObservableCollectionImproved<OrderModel>;
                    return new AddOrderView(editOrderViewModel);
                case ViewType.EditUser:
                    EditUserViewModel editUserViewModel = (EditUserViewModel)_viewModelFactory.CreateViewModel(viewType);
                    editUserViewModel.AllUsers = tableList as ObservableCollectionImproved<UserModel>;
                    return new EditUserView(editUserViewModel);
                default: throw new ArgumentException("ViewType не имеет данной ViewModel.", nameof(viewType));
            }
        }

        public Window CreateView(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.ViewDepartment => new ViewDepartmentView(_viewModelFactory.CreateViewModel(viewType)),
                ViewType.ViewOrder => new ViewOrderView(_viewModelFactory.CreateViewModel(viewType)),
                ViewType.ViewUser => new ViewUserView(_viewModelFactory.CreateViewModel(viewType)),
                _ => throw new ArgumentException("ViewType не имеет данной ViewModel.", nameof(viewType)),
            };
        }
    }
}