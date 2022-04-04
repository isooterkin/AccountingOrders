using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using AccountingOrders.WPF.Commands.RelayCommand;
using AccountingOrders.WPF.Tools;
using AccountingOrders.WPF.ViewsModels.Factories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingOrders.WPF.ViewsModels
{
    public class OrderViewModel: ViewModelBase
    {
        #region Конструктор

        public OrderViewModel(IOrderService orderService, IAccountingOrdersViewFactory viewFactory)
        {
            #region Получение завода для создания окон

            _viewFactory = viewFactory;

            #endregion

            #region Получение сервисов для взаимодействия с БД

            _orderService = orderService;

            #endregion

            #region Получение данных с БД

            GetData();

            #endregion

            #region Регистрация команд

            AddCommand = new RelayCommand(_ => AddOrder(), _ => true);
            ViewCommand = new RelayCommand(_ => ViewOrder(), _ => true);
            EditCommand = new RelayCommand(_ => EditOrder(), _ => true);
            DeleteCommand = new RelayCommand(_ => DeleteOrder(), _ => true);

            #endregion
        }

        #endregion

        #region Завод окон

        private readonly IAccountingOrdersViewFactory _viewFactory;

        #endregion

        #region Взаимодействие с БД

        #region Сервисы
        private readonly IOrderService _orderService;
        #endregion

        #region Методы
        private readonly ObservableCollectionImproved<OrderModel> _allOrders = new();
        public IEnumerable<OrderModel> AllOrders => _allOrders;
        public async Task GetDataAsync() => _allOrders.AddRange(await _orderService.GetAll());
        public void GetData() => _ = GetDataAsync();
        private List<OrderModel> GetSelectedItems() => AllOrders.Where(x => x.IsSelected).ToList();
        #endregion

        #endregion

        #region Команды

        #region Команда добавления записи

        public ICommand AddCommand { get; }
        public void AddOrder() => _viewFactory.CreateViewAdd(ViewWindowType.AddOrder, _allOrders).Show();

        #endregion

        #region Команда просмотра записи

        public ICommand ViewCommand { get; }
        public void ViewOrder()
        {
            List<OrderModel> selectedItems = GetSelectedItems();
            foreach (var selectedItem in selectedItems)
                _viewFactory.CreateViewView(ViewWindowType.ViewOrder, selectedItem).Show();
        }

        #endregion

        #region Команда редактирования записи

        public ICommand EditCommand { get; }
        public void EditOrder()
        {
            List<OrderModel> selectedItems = GetSelectedItems();
            foreach (var selectedItem in selectedItems)
                _viewFactory.CreateViewEdit(ViewWindowType.EditOrder, _allOrders, selectedItem).Show();
        }

        #endregion

        #region Команда удаления записи

        public ICommand DeleteCommand { get; }
        public void DeleteOrder() => _ = DeleteOrderAsync();
        public async Task DeleteOrderAsync()
        {
            List<OrderModel> selectedItems = GetSelectedItems();
            if (selectedItems.Count > 0)
            {
                await _orderService.Deletes(selectedItems.Select(e => e.Id).ToArray());
                _allOrders.Clear();
                await GetDataAsync();
            }
        }

        #endregion

        #endregion
    }
}