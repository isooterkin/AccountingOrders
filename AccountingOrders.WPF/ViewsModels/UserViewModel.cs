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
    public class UserViewModel: ViewModelBase
    {
        #region Конструктор

        public UserViewModel(IUserService userService, IDepartmentService departmentService, IAccountingOrdersViewFactory viewFactory)
        {
            #region Получение завода для создания окон

            _viewFactory = viewFactory;

            #endregion

            #region Получение сервисов для взаимодействия с БД

            _userService = userService;
            _departmentService = departmentService;

            #endregion

            #region Получение данных с БД

            GetData();

            #endregion

            #region Регистрация команд

            AddCommand = new RelayCommand(_ => AddUser(), _ => true);
            ViewCommand = new RelayCommand(_ => ViewUser(), _ => true);
            EditCommand = new RelayCommand(_ => EditUser(), _ => true);
            DeleteCommand = new RelayCommand(_ => DeleteUser(), _ => true);

            #endregion
        }

        #endregion

        #region Завод окон

        private readonly IAccountingOrdersViewFactory _viewFactory;

        #endregion

        #region Взаимодействие с БД

        #region Сервисы
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Методы
        private readonly ObservableCollectionImproved<UserModel> _allUsers = new ();
        public IEnumerable<UserModel> AllUsers => _allUsers;
        public async Task GetDataAsync() => _allUsers.AddRange(await _userService.GetAll());
        public void GetData() => _ = GetDataAsync();
        private List<UserModel> GetSelectedItems() => AllUsers.Where(x => x.IsSelected).ToList();
        #endregion

        #endregion

        #region Команды

        #region Команда добавления записи

        public ICommand AddCommand { get; }
        public void AddUser() => _viewFactory.CreateViewAdd(ViewWindowType.AddUser, _allUsers).Show();

        #endregion

        #region Команда просмотра записи

        public ICommand ViewCommand { get; }
        public void ViewUser()
        {
            List<UserModel> selectedItems = GetSelectedItems();
            foreach (var selectedItem in selectedItems)
                _viewFactory.CreateViewView(ViewWindowType.ViewUser, selectedItem).Show();
        }

        #endregion

        #region Команда редактирования записи

        public ICommand EditCommand { get; }
        public void EditUser()
        {
            List<UserModel> selectedItems = GetSelectedItems();
            foreach (var selectedItem in selectedItems)
                _viewFactory.CreateViewEdit(ViewWindowType.EditUser, _allUsers, selectedItem).Show();
        }

        #endregion

        #region Команда удаления записи

        public ICommand DeleteCommand { get; }
        public void DeleteUser() => _ = DeleteUserAsync();
        public async Task DeleteUserAsync()
        {
            List<UserModel> selectedItems = GetSelectedItems();
            if (selectedItems.Count > 0)
            {
                int[] selectedItemsArray = selectedItems.Select(e => e.Id).ToArray();
                await _departmentService.UpdateUserIdToNull(selectedItemsArray);
                await _userService.Deletes(selectedItemsArray);
                _allUsers.Clear();
                await GetDataAsync();
            }
        }

        #endregion

        #endregion
    }
}