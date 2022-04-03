using AccountingOrders.ViewsModels;
using System.Windows;

namespace AccountingOrders.Views
{
    public partial class AddNewUserWindow : Window
    {
        public AddNewUserWindow()
        {
            InitializeComponent();

            DataContext = new DataManageVM();
        }
    }
}