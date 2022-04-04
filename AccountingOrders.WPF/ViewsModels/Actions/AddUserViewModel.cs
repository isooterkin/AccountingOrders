using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using AccountingOrders.WPF.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOrders.WPF.ViewsModels.Actions
{
    public class AddUserViewModel: ViewModelBase
    {
        public ObservableCollectionImproved<UserModel>? AllUsers;

        public AddUserViewModel(IUserService userService, IDepartmentService departmentService, ObservableCollectionImproved<UserModel> observableUser)
        {

        }
    }
}