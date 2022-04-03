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
    public class UserViewModel: ViewModelBase
    {
        private readonly IAccountingOrdersViewFactory _viewFactory;

        private readonly IUserService _userService;

        private readonly ObservableCollectionImproved<UserModel> _allUsers;
        public IEnumerable<UserModel> AllUsers => _allUsers;

        public UserViewModel(IUserService userService, IAccountingOrdersViewFactory viewFactory)
        {
            _viewFactory = viewFactory;

            _allUsers = new ObservableCollectionImproved<UserModel>();

            _userService = userService;

            _ = GetDataAsync();

            AddCommand = new RelayCommand(_ => AddUser(), _ => true);
            ViewCommand = new RelayCommand(_ => ViewUser(), _ => true);
            EditCommand = new RelayCommand(_ => EditUser(), _ => true);
        }

        public async Task GetDataAsync() => _allUsers.AddRange(await _userService.GetAll());

        #region Команды
        public ICommand AddCommand { get; }
        public void AddUser() => _viewFactory.CreateView(ViewType.AddUser, _allUsers).Show();

        public ICommand ViewCommand { get; }
        public void ViewUser() => _viewFactory.CreateView(ViewType.ViewUser).Show();

        public ICommand EditCommand { get; }
        public void EditUser() => _viewFactory.CreateView(ViewType.EditUser, _allUsers).Show();
        #endregion
    }
}