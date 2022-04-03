using System.Windows;

namespace AccountingOrders.WPF.Views.Actions
{
    public partial class AddUserView : Window
    {
        public AddUserView(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}