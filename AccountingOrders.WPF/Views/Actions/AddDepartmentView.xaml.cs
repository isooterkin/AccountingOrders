using System.Windows;

namespace AccountingOrders.WPF.Views.Actions
{
    public partial class AddDepartmentView: Window
    {
        public AddDepartmentView(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}