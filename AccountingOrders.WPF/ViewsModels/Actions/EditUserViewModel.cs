using AccountingOrders.Domain.Models;
using AccountingOrders.WPF.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOrders.WPF.ViewsModels.Actions
{
    public class EditUserViewModel: ViewModelBase
    {
        public ObservableCollectionImproved<UserModel>? AllUsers;
    }
}