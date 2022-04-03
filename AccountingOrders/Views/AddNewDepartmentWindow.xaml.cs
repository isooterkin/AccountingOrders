using AccountingOrders.ViewsModels;
using System.Windows;

namespace AccountingOrders.Views
{
    public partial class AddNewDepartmentWindow : Window
    {
        public AddNewDepartmentWindow()
        {
            InitializeComponent();

            DataContext = new DataManageVM();
        }
    }
}