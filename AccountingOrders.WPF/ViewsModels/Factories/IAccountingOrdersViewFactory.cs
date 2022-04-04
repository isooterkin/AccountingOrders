using AccountingOrders.WPF.State.Navigators;
using AccountingOrders.WPF.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountingOrders.WPF.ViewsModels.Factories
{
    public enum ViewWindowType
    {
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

    public interface IAccountingOrdersViewFactory
    {
        public Window CreateViewAdd<Observable>(ViewWindowType viewWindowType, Observable observableCollectionImproved) where Observable : class;

        public Window CreateViewEdit<Observable, Model>(ViewWindowType viewWindowType, Observable observableCollectionImproved, Model model) where Observable : class where Model : class;

        public Window CreateViewView<Model>(ViewWindowType viewWindowType, Model model) where Model : class;
    }
}