using AccountingOrders.WPF.Views.Actions;
using AccountingOrders.WPF.ViewsModels;
using System.Windows;

namespace AccountingOrders.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}