using System.Windows;

namespace AccountingOrders.WPF.Views.Actions
{
    public partial class ViewOrderView : Window
    {
        public ViewOrderView(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}