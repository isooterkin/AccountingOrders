using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using AccountingOrders.WPF.Commands.RelayCommand;
using AccountingOrders.WPF.State.Navigators;
using AccountingOrders.WPF.Views.Actions;
using AccountingOrders.WPF.ViewsModels.Actions;
using AccountingOrders.WPF.ViewsModels.Factories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountingOrders.WPF.Tools;
using System.Linq;
using System.Threading;

namespace AccountingOrders.WPF.ViewsModels
{
    public class DepartmentViewModel : ViewModelBase
    {
        private readonly IAccountingOrdersViewFactory _viewFactory;

        private readonly IDepartmentService _departmentService;

        private readonly ObservableCollectionImproved<DepartmentModel> _allDepartments = new();
        public IEnumerable<DepartmentModel> AllDepartments => _allDepartments;

        public DepartmentViewModel(IDepartmentService departmentService, IAccountingOrdersViewFactory viewFactory)
        {
            _viewFactory = viewFactory;

            _departmentService = departmentService;

            GetData();

            AddCommand = new RelayCommand(_ => AddDepartment(), _ => true);
            ViewCommand = new RelayCommand(_ => ViewDepartment(), _ => true);
            EditCommand = new RelayCommand(_ => EditDepartment(), _ => true);
            DeleteCommand = new RelayCommand(_ => DeleteDepartment(), _ => true);
        }

        public void GetData() => _ = GetDataAsync();
        public async Task GetDataAsync() => _allDepartments.AddRange(await _departmentService.GetAll());

        private List<DepartmentModel> GetSelectedItems() => AllDepartments.Where(x => x.IsSelected).ToList();

        #region Команды

        #region Команда добавления записи

        public ICommand AddCommand { get; }
        public void AddDepartment() => _viewFactory.CreateViewAdd(ViewWindowType.AddDepartment, _allDepartments).Show();

        #endregion

        #region Команда просмотра записи

        public ICommand ViewCommand { get; }
        public void ViewDepartment()
        {
            var selectedItems = GetSelectedItems();
            foreach (var selectedItem in selectedItems)
               _viewFactory.CreateViewView(ViewWindowType.ViewDepartment, selectedItem).Show();
        }

        #endregion

        public ICommand EditCommand { get; }
        public void EditDepartment() { } //=> _viewFactory.CreateView(ViewType.EditDepartment, _allDepartments).Show();

        #region Команда удаления записи

        public ICommand DeleteCommand { get; }
        public void DeleteDepartment() => _ = DeleteDepartmentAsync();
        public async Task DeleteDepartmentAsync()
        {
            List<DepartmentModel> selectedItems = GetSelectedItems();
            if (selectedItems.Count > 0)
            {
                await _departmentService.Deletes(selectedItems.Select(e => e.Id).ToArray());
                _allDepartments.Clear();
                await GetDataAsync();
            }
        }

        #endregion

        #endregion
    }
}