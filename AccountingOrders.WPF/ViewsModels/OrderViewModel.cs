using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using AccountingOrders.WPF.Commands.RelayCommand;
using AccountingOrders.WPF.State.Navigators;
using AccountingOrders.WPF.Tools;
using AccountingOrders.WPF.Views.Actions;
using AccountingOrders.WPF.ViewsModels.Factories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingOrders.WPF.ViewsModels
{
    public class OrderViewModel: ViewModelBase
    {
        private readonly IAccountingOrdersViewFactory _viewFactory;

        private readonly IOrderService _orderService;

        private readonly ObservableCollectionImproved<OrderModel> _allOrders;
        public IEnumerable<OrderModel> AllOrders => _allOrders;

        public OrderViewModel(IOrderService orderService, IAccountingOrdersViewFactory viewFactory)
        {
            _viewFactory = viewFactory;

            _allOrders = new ObservableCollectionImproved<OrderModel>();

            _orderService = orderService;

            _ = GetDataAsync();

            AddCommand = new RelayCommand(_ => AddOrder(), _ => true);
            ViewCommand = new RelayCommand(_ => ViewOrder(), _ => true);
            EditCommand = new RelayCommand(_ => EditOrder(), _ => true);
        }

        public async Task GetDataAsync() => _allOrders.AddRange(await _orderService.GetAll());

        #region Команды
        public ICommand AddCommand { get; }
        public void AddOrder() => _viewFactory.CreateViewAdd(ViewWindowType.AddOrder, _allOrders).Show();

        public ICommand ViewCommand { get; }
        public void ViewOrder() { }//=> _viewFactory.CreateView(ViewType.ViewOrder).Show();

        public ICommand EditCommand { get; }
        public void EditOrder() { }//=> _viewFactory.CreateView(ViewType.EditOrder, _allOrders).Show();
        #endregion
    }
}