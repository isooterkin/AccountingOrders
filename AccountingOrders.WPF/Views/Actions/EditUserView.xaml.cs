using System.Windows;

namespace AccountingOrders.WPF.Views.Actions
{
    public partial class EditUserView : Window
    {
        public EditUserView(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}