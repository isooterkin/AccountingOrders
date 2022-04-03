using System.Windows;

namespace AccountingOrders.WPF.Views.Actions
{
    public partial class ViewDepartmentView : Window
    {
        public ViewDepartmentView(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}