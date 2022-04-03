using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace AccountingOrders.WPF.Views.Actions
{
    public partial class AddOrderView : Window
    {
        public AddOrderView(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}