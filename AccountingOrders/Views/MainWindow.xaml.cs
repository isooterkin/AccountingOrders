using AccountingOrders.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingOrders.Views
{
    public partial class MainWindow : Window
    {
        public static ListView? AllDepartmentsView;
        public static ListView? AllOrdersView;
        public static ListView? AllUsersView;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new DataManageVM();

            AllDepartmentsView = ViewAllDepartments;
            AllOrdersView = ViewAllOrders;
            AllUsersView = ViewAllUsers;
        }
    }
}
