using AccountingOrders.WPF.State.Navigators;
using AccountingOrders.WPF.ViewsModels.Actions;
using System;

namespace AccountingOrders.WPF.ViewsModels.Factories
{
    public class AccountingOrdersViewModelFactory: IAccountingOrdersViewModelFactory
    {
        private readonly CreateViewModel<DepartmentViewModel> _createDepartmentViewModel;
        private readonly CreateViewModel<OrderViewModel> _createOrderViewModel;
        private readonly CreateViewModel<UserViewModel> _createUserViewModel;

        private readonly CreateViewModel<AddDepartmentViewModel> _createAddDepartmentViewModel;
        private readonly CreateViewModel<AddOrderViewModel> _createAddOrderViewModel;
        private readonly CreateViewModel<AddUserViewModel> _createAddUserViewModel;
        private readonly CreateViewModel<EditDepartmentViewModel> _createEditDepartmentViewModel;
        private readonly CreateViewModel<EditOrderViewModel> _createEditOrderViewModel;
        private readonly CreateViewModel<EditUserViewModel> _createEditUserViewModel;
        private readonly CreateViewModel<ViewDepartmentViewModel> _createViewDepartmentViewModel;
        private readonly CreateViewModel<ViewOrderViewModel> _createViewOrderViewModel;
        private readonly CreateViewModel<ViewUserViewModel> _createViewUserViewModel;

        public AccountingOrdersViewModelFactory(CreateViewModel<DepartmentViewModel> createDepartmentViewModel,
            CreateViewModel<OrderViewModel> createOrderViewModel,
            CreateViewModel<UserViewModel> createUserViewModel,
            CreateViewModel<AddDepartmentViewModel> createAddDepartmentViewModel,
            CreateViewModel<AddOrderViewModel> createAddOrderViewModel,
            CreateViewModel<AddUserViewModel> createAddUserViewModel,
            CreateViewModel<EditDepartmentViewModel> createEditDepartmentViewModel,
            CreateViewModel<EditOrderViewModel> createEditOrderViewModel,
            CreateViewModel<EditUserViewModel> createEditUserViewModel,
            CreateViewModel<ViewDepartmentViewModel> createViewDepartmentViewModel,
            CreateViewModel<ViewOrderViewModel> createViewOrderViewModel,
            CreateViewModel<ViewUserViewModel> createViewUserViewModel)
        {
            _createDepartmentViewModel = createDepartmentViewModel;
            _createOrderViewModel = createOrderViewModel;
            _createUserViewModel = createUserViewModel;

            _createAddDepartmentViewModel = createAddDepartmentViewModel;
            _createAddOrderViewModel = createAddOrderViewModel;
            _createAddUserViewModel = createAddUserViewModel;
            _createEditDepartmentViewModel = createEditDepartmentViewModel;
            _createEditOrderViewModel = createEditOrderViewModel;
            _createEditUserViewModel = createEditUserViewModel;
            _createViewDepartmentViewModel = createViewDepartmentViewModel;
            _createViewOrderViewModel = createViewOrderViewModel;
            _createViewUserViewModel = createViewUserViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Department => _createDepartmentViewModel(),
                ViewType.Order => _createOrderViewModel(),
                ViewType.User => _createUserViewModel(),

                ViewType.AddDepartment => _createAddDepartmentViewModel(),
                ViewType.AddOrder => _createAddOrderViewModel(),
                ViewType.AddUser => _createAddUserViewModel(),
                ViewType.EditDepartment => _createEditDepartmentViewModel(),
                ViewType.EditOrder => _createEditOrderViewModel(),
                ViewType.EditUser => _createEditUserViewModel(),
                ViewType.ViewDepartment => _createViewDepartmentViewModel(),
                ViewType.ViewOrder => _createViewOrderViewModel(),
                ViewType.ViewUser => _createViewUserViewModel(),
                _ => throw new ArgumentException("ViewType не имеет данной ViewModel.", nameof(viewType)),
            };
        }
    }
}