using System.Windows;

namespace AccountingOrders.WPF.Views.Actions
{
    public partial class EditDepartmentView : Window
    {
        public EditDepartmentView(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}