using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using AccountingOrders.EntityFramework;
using AccountingOrders.EntityFramework.Services;
using AccountingOrders.WPF.Tools;
using AccountingOrders.WPF.Views.Actions;
using AccountingOrders.WPF.ViewsModels.Actions;
using System;
using System.Windows;

namespace AccountingOrders.WPF.ViewsModels.Factories
{
    public class AccountingOrdersViewFactory: IAccountingOrdersViewFactory
    {
        private readonly AccountingOrdersDbContextFactory _accountingOrdersDbContextFactory;

        public AccountingOrdersViewFactory(AccountingOrdersDbContextFactory accountingOrdersDbContextFactory)
        {
            _accountingOrdersDbContextFactory = accountingOrdersDbContextFactory;
        }

        public Window CreateViewAdd<Observable>(ViewWindowType viewWindowType, Observable observableCollectionImproved) where Observable : class
        {
            IUserService userService = new UserDataService(_accountingOrdersDbContextFactory);
            IOrderService orderService = new OrderDataService(_accountingOrdersDbContextFactory);
            IDepartmentService departmentService = new DepartmentDataService(_accountingOrdersDbContextFactory);

            switch (viewWindowType)
            {
                case ViewWindowType.AddDepartment:
                    if (observableCollectionImproved is not ObservableCollectionImproved<DepartmentModel> observableCollectionDepartment) 
                        throw new ArgumentException("Observable указан не правильно", nameof(viewWindowType));
                    return new AddDepartmentView(new AddDepartmentViewModel(departmentService, userService, observableCollectionDepartment));
                case ViewWindowType.AddOrder:
                    if (observableCollectionImproved is not ObservableCollectionImproved<OrderModel> observableCollectionOrder) 
                        throw new ArgumentException("Observable указан не правильно", nameof(viewWindowType));
                    return new AddOrderView(new AddOrderViewModel(orderService, userService, observableCollectionOrder));
                case ViewWindowType.AddUser:
                    if (observableCollectionImproved is not ObservableCollectionImproved<UserModel> observableCollectionUser) 
                        throw new ArgumentException("Observable указан не правильно", nameof(viewWindowType));
                    return new AddUserView(new AddUserViewModel(userService, departmentService, observableCollectionUser));
                default: throw new ArgumentException("ViewWindowType не имеет данной View.", nameof(viewWindowType));
            }
        }

        public Window CreateViewEdit<Observable, Model>(ViewWindowType viewWindowType, Observable observableCollectionImproved, Model model) where Observable : class where Model : class
        {
            IUserService userService = new UserDataService(_accountingOrdersDbContextFactory);
            IOrderService orderService = new OrderDataService(_accountingOrdersDbContextFactory);
            IDepartmentService departmentService = new DepartmentDataService(_accountingOrdersDbContextFactory);

            switch (viewWindowType)
            {
                case ViewWindowType.EditDepartment:
                    if (observableCollectionImproved is not ObservableCollectionImproved<DepartmentModel> observableCollectionDepartment)
                        throw new ArgumentException("Observable указан не правильно", nameof(viewWindowType));
                    if (model is not DepartmentModel modelDepartment)
                        throw new ArgumentException("Model указан не правильно", nameof(viewWindowType));
                    return new EditDepartmentView(new EditDepartmentViewModel(departmentService, userService, observableCollectionDepartment, modelDepartment));
                case ViewWindowType.EditOrder:
                    if (observableCollectionImproved is not ObservableCollectionImproved<OrderModel> observableCollectionOrder)
                        throw new ArgumentException("Observable указан не правильно", nameof(viewWindowType));
                    if (model is not OrderModel modelOrder)
                        throw new ArgumentException("Model указан не правильно", nameof(viewWindowType));
                    return new EditOrderView(new EditOrderViewModel(orderService, userService, observableCollectionOrder, modelOrder));
                case ViewWindowType.EditUser:
                    if (observableCollectionImproved is not ObservableCollectionImproved<UserModel> observableCollectionUser)
                        throw new ArgumentException("Observable указан не правильно", nameof(viewWindowType));
                    if (model is not UserModel modelUser)
                        throw new ArgumentException("Model указан не правильно", nameof(viewWindowType));
                    return new EditUserView(new EditUserViewModel(userService, departmentService, observableCollectionUser, modelUser));
                default: throw new ArgumentException("ViewWindowType не имеет данной View.", nameof(viewWindowType));
            }
        }

        public Window CreateViewView<Model>(ViewWindowType viewWindowType, Model model) where Model : class
        {
            switch (viewWindowType)
            {
                case ViewWindowType.ViewDepartment:
                    if (model is not DepartmentModel modelDepartment)
                        throw new ArgumentException("Model указан не правильно", nameof(viewWindowType));
                    return new ViewDepartmentView(new ViewDepartmentViewModel(modelDepartment));
                case ViewWindowType.ViewOrder:
                    if (model is not OrderModel modelOrder)
                        throw new ArgumentException("Model указан не правильно", nameof(viewWindowType));
                    return new ViewOrderView(new ViewOrderViewModel(modelOrder));
                case ViewWindowType.ViewUser:
                    if (model is not UserModel modelUser)
                        throw new ArgumentException("Model указан не правильно", nameof(viewWindowType));
                    return new ViewUserView(new ViewUserViewModel(modelUser));
                default: throw new ArgumentException("ViewWindowType не имеет данной View.", nameof(viewWindowType));
            }
        }
    }
}