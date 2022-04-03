using AccountingOrders.Models;
using AccountingOrders.Views;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AccountingOrders.Tools
{
    public class UpdateViewWindows
    {
        #region Обновление таблиц
        public static void UpdateAllDataView()
        {
            UpdateView(MainWindow.AllDepartmentsView, DataWorker.GetAllDepartments());
            UpdateView(MainWindow.AllOrdersView, DataWorker.GetAllOrders());
            UpdateView(MainWindow.AllUsersView, DataWorker.GetAllUsers());
        }
        private static void UpdateView<T>(ListView? listview, List<T>? Model)
        {
            if (listview == null) return;
            listview.ItemsSource = null;
            listview.Items.Clear();
            listview.ItemsSource = Model;
            listview.Items.Refresh();
        }
        #endregion
    }
}
