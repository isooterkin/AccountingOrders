using AccountingOrders.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountingOrders.Tools
{
    public static class OpeningWindows
    {
        #region Методы открытия окон
        public static void OpenAddNewDepartmentWindowMethod()
        {
            SetCenterPositionAndOpen(new AddNewDepartmentWindow());
        }
        public static void OpenAddNewOrderWindowMethod()
        {
            SetCenterPositionAndOpen(new AddNewOrderWindow());
        }
        public static void OpenAddNewUserWindowMethod()
        {
            SetCenterPositionAndOpen(new AddNewUserWindow());
        }
        public static void OpenEditDepartmentWindowMethod()
        {
            SetCenterPositionAndOpen(new EditDepartmentWindow());
        }
        public static void OpenEditOrderWindowMethod()
        {
            SetCenterPositionAndOpen(new EditOrderWindow());
        }
        public static void OpenEditUserWindowMethod()
        {
            SetCenterPositionAndOpen(new EditUserWindow());
        }
        public static void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion
    }
}