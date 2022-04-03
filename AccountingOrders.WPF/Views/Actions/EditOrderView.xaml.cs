using System.Windows;

namespace AccountingOrders.WPF.Views.Actions
{
    public partial class EditOrderView : Window
    {
        public EditOrderView(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}