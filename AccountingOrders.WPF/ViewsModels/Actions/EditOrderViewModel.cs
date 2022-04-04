using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using AccountingOrders.WPF.Commands.RelayCommand;
using AccountingOrders.WPF.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingOrders.WPF.ViewsModels.Actions
{
    public class EditOrderViewModel: ViewModelBaseValidate
    {
        #region Конструктор

        public EditOrderViewModel(IOrderService orderService, IUserService userService, ObservableCollectionImproved<OrderModel> observableOrder, OrderModel orderModel)
        {
            #region Получение Observable для обновления таблицы

            _observableOrder = observableOrder;

            #endregion

            #region Получение сервисов для взаимодействия с БД

            _userService = userService;
            _orderService = orderService;

            #endregion

            #region Получение данных с БД

            GetData();

            #endregion

            #region Регистрация команд

            AddCommand = new RelayCommand(_ => EditOrder(), _ => true);

            #endregion

            #region Первоначальные данные

            _orderModel = orderModel;

            #endregion
        }

        #endregion

        #region Взаимодействие с БД

        #region Сервисы
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        #endregion

        #region Методы
        private readonly ObservableCollectionImproved<UserModel> _allUsers = new();
        public IEnumerable<UserModel> AllUsers => _allUsers;
        public async Task GetDataAsync() => _allUsers.AddRange(await _userService.GetAll());
        public void GetData() => _ = GetDataAsync();
        #endregion

        #endregion

        #region Взаимодействоие с VM

        private readonly ObservableCollectionImproved<OrderModel> _observableOrder;

        #endregion

        #region Переменные

        private readonly OrderModel _orderModel;
        public int Number
        {
            get => _orderModel.Number;
            set
            {
                _orderModel.Number = value;
                ValidateModelProperty(value, nameof(Number), _orderModel);
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Name
        {
            get => _orderModel.Name;
            set
            {
                _orderModel.Name = value;
                ValidateModelProperty(value, nameof(Name), _orderModel);
                OnPropertyChanged(nameof(Name));
            }
        }
        public UserModel? UserModel
        {
            get => _orderModel.UserModel;
            set
            {
                _orderModel.UserModel = value;
                if (value != null) _orderModel.UserId = value.Id;
                ValidateModelProperty(value, nameof(UserModel), _orderModel);
                OnPropertyChanged(nameof(UserModel));
            }
        }

        #endregion

        #region Команды

        public ICommand AddCommand { get; }
        public void EditOrder() => _ = EditOrderAsync();
        public async Task EditOrderAsync()
        {
            if (!HasErrors)
            {
                OrderModel? orderModel = UserModel == null ?
                    await _orderService.Update(_orderModel.Id, new OrderModel { Name = Name, Number = Number }) :
                    await _orderService.Update(_orderModel.Id, new OrderModel { Name = Name, Number = Number, UserId = UserModel.Id });

                if (orderModel != null)
                {
                    orderModel.UserModel = UserModel;
                    _observableOrder.Remove(_orderModel);
                    _observableOrder.Add(orderModel);
                }

                CloseWindow();
            }
        }

        #endregion
    }
}