using System.Windows;

namespace AccountingOrders.WPF.Views.Actions
{
    public partial class ViewUserView : Window
    {
        public ViewUserView(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}