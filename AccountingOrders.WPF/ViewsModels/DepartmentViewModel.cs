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
        public ICommand AddCommand { get; }
        public void AddDepartment() => _viewFactory.CreateView(ViewType.AddDepartment, _allDepartments).Show();

        public ICommand ViewCommand { get; }
        public void ViewDepartment()
        {
            var selectedItems = GetSelectedItems();
            foreach (var selectedItem in selectedItems)
            {
                // selectedItem нужно закинуть в окно!
                _viewFactory.CreateView(ViewType.ViewDepartment).Show();
            }
        }

        public ICommand EditCommand { get; }
        public void EditDepartment() => _viewFactory.CreateView(ViewType.EditDepartment, _allDepartments).Show();

        public ICommand DeleteCommand { get; }
        public void DeleteDepartment() => _ = DeleteDepartmentAsync();

        public async Task DeleteDepartmentAsync()
        {
            // Реализовать DeleteRange
            List<DepartmentModel> selectedItems = GetSelectedItems();
            if (selectedItems.Count > 0)
            {
                for (int i = 0; i < selectedItems.Count; i++)
                    await _departmentService.Delete(selectedItems[i].Id);
                _allDepartments.Clear();
                await GetDataAsync();
            }
        }
        #endregion
    }
}