using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using AccountingOrders.WPF.Commands.RelayCommand;
using AccountingOrders.WPF.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AccountingOrders.WPF.ViewsModels.Actions
{
    public class AddDepartmentViewModel: ViewModelBaseValidate
    {
        #region Конструктор

        public AddDepartmentViewModel(IUserService userService, IDepartmentService departmentService)
        {
            #region Получение сервисов для взаимодействия с БД

            _userService = userService;
            _departmentService = departmentService;

            #endregion

            #region Получение данных с БД

            GetData();

            #endregion

            #region Регистрация команд

            AddCommand = new RelayCommand(_ => AddDepartment(), _ => true);

            #endregion

            #region Первоначальные данные

            Name = "";

            #endregion
        }

        #endregion

        #region Взаимодействие с БД

        #region Сервисы
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Методы
        private readonly ObservableCollectionImproved<UserModel> _allUsers = new();
        public IEnumerable<UserModel> AllUsers => _allUsers;
        public async Task GetDataAsync() => _allUsers.AddRange(await _userService.GetAll());
        public void GetData() => _ = GetDataAsync();
        #endregion

        #endregion

        #region Взаимодействоие с VM

        public ObservableCollectionImproved<DepartmentModel>? AllDepartments;

        #endregion

        #region Переменные
        private readonly DepartmentModel _departmentModel = new();
        public string Name
        {
            get => _departmentModel.Name;
            set
            {
                _departmentModel.Name = value;
                ValidateModelProperty(value, nameof(Name), _departmentModel);
                OnPropertyChanged(nameof(Name));
            }
        }
        public UserModel? UserModel
        {
            get => _departmentModel.UserModel;
            set
            {
                _departmentModel.UserModel = value;
                if (value != null) _departmentModel.UserId = value.Id;
                ValidateModelProperty(value, nameof(UserModel), _departmentModel);
                OnPropertyChanged(nameof(UserModel));
            }
        }
        #endregion

        #region Команды

        public ICommand AddCommand { get; }
        public void AddDepartment() => _ = AddDepartmentAsync();
        public async Task AddDepartmentAsync() 
        {
            if (!HasErrors)
            {
                DepartmentModel departmentModel;

                if (UserModel == null) departmentModel = await _departmentService.Create(new DepartmentModel { Name = Name });
                else departmentModel = await _departmentService.Create(new DepartmentModel { Name = Name, UserId = UserModel.Id });
 
                AllDepartments?.Add(departmentModel);
                CloseWindow();
            }
        }
        
        #endregion
    }
}