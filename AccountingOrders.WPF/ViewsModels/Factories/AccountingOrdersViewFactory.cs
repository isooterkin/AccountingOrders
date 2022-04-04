using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using AccountingOrders.EntityFramework;
using AccountingOrders.EntityFramework.Services;
using AccountingOrders.WPF.Tools;
using AccountingOrders.WPF.Views.Actions;
using AccountingOrders.WPF.ViewsModels.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                default: throw new ArgumentException("ViewType не имеет данной ViewModel.", nameof(viewWindowType));
            }
        }

        public Window CreateViewEdit<Observable, Model>(ViewWindowType viewWindowType, Observable observableCollectionImproved, Model model) where Observable : class where Model : class
        {
            return new Window();
        }

        public Window CreateViewView<Model>(ViewWindowType viewWindowType, Model model) where Model : class
        {
            return new Window();
        }
    }
}