using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using AccountingOrders.WPF.Commands.RelayCommand;
using AccountingOrders.WPF.ViewsModels.Factories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountingOrders.WPF.Tools;
using System.Linq;

namespace AccountingOrders.WPF.ViewsModels
{
    public class DepartmentViewModel : ViewModelBase
    {
        #region Конструктор

        public DepartmentViewModel(IDepartmentService departmentService, IUserService userService, IAccountingOrdersViewFactory viewFactory)
        {
            #region Получение завода для создания окон

            _viewFactory = viewFactory;

            #endregion

            #region Получение сервисов для взаимодействия с БД

            _departmentService = departmentService;
            _userService = userService;

            #endregion

            #region Получение данных с БД

            GetData();

            #endregion

            #region Регистрация команд

            AddCommand = new RelayCommand(_ => AddDepartment(), _ => true);
            ViewCommand = new RelayCommand(_ => ViewDepartment(), _ => true);
            EditCommand = new RelayCommand(_ => EditDepartment(), _ => true);
            DeleteCommand = new RelayCommand(_ => DeleteDepartment(), _ => true);

            #endregion
        }

        #endregion

        #region Завод окон

        private readonly IAccountingOrdersViewFactory _viewFactory;

        #endregion

        #region Взаимодействие с БД

        #region Сервисы
        private readonly IDepartmentService _departmentService;
        private readonly IUserService _userService;
        #endregion

        #region Методы
        private readonly ObservableCollectionImproved<DepartmentModel> _allDepartments = new();
        public IEnumerable<DepartmentModel> AllDepartments => _allDepartments;
        public async Task GetDataAsync() => _allDepartments.AddRange(await _departmentService.GetAll());
        public void GetData() => _ = GetDataAsync();
        private List<DepartmentModel> GetSelectedItems() => AllDepartments.Where(x => x.IsSelected).ToList();
        #endregion

        #endregion

        #region Команды

        #region Команда добавления записи

        public ICommand AddCommand { get; }
        public void AddDepartment() => _viewFactory.CreateViewAdd(ViewWindowType.AddDepartment, _allDepartments).Show();

        #endregion

        #region Команда просмотра записи

        public ICommand ViewCommand { get; }
        public void ViewDepartment()
        {
            List<DepartmentModel> selectedItems = GetSelectedItems();
            foreach (var selectedItem in selectedItems)
               _viewFactory.CreateViewView(ViewWindowType.ViewDepartment, selectedItem).Show();
        }

        #endregion

        #region Команда редактирования записи

        public ICommand EditCommand { get; }
        public void EditDepartment()
        {
            List<DepartmentModel> selectedItems = GetSelectedItems();
            foreach (var selectedItem in selectedItems)
                _viewFactory.CreateViewEdit(ViewWindowType.EditDepartment, _allDepartments, selectedItem).Show();
        }

        #endregion

        #region Команда удаления записи

        public ICommand DeleteCommand { get; }
        public void DeleteDepartment() => _ = DeleteDepartmentAsync();
        public async Task DeleteDepartmentAsync()
        {
            List<DepartmentModel> selectedItems = GetSelectedItems();
            if (selectedItems.Count > 0)
            {
                int[] selectedItemsArray = selectedItems.Select(e => e.Id).ToArray();
                await _userService.UpdateDepartmentIdToNull(selectedItemsArray);
                await _departmentService.Deletes(selectedItemsArray);
                _allDepartments.Clear();
                await GetDataAsync();
            }
        }

        #endregion

        #endregion
    }
}