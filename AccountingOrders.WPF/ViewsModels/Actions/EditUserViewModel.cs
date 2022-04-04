using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using AccountingOrders.Domain.Tools;
using AccountingOrders.WPF.Commands.RelayCommand;
using AccountingOrders.WPF.Tools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;


namespace AccountingOrders.WPF.ViewsModels.Actions
{
    public class EditUserViewModel: ViewModelBaseValidate
    {
        #region Конструктор

        public EditUserViewModel(IUserService userService, IDepartmentService departmentService, ObservableCollectionImproved<UserModel> observableUser, UserModel userModel)
        {
            #region Получение Observable для обновления таблицы

            _observableUser = observableUser;

            #endregion

            #region Получение сервисов для взаимодействия с БД

            _userService = userService;
            _departmentService = departmentService;

            #endregion

            #region Получение данных с БД

            GetData();

            #endregion

            #region Регистрация команд

            AddCommand = new RelayCommand(_ => EditUser(), _ => true);

            #endregion

            #region Первоначальные данные

            _userModel = userModel;

            #endregion
        }

        #endregion

        #region Взаимодействие с БД

        #region Сервисы
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        #endregion

        #region Методы
        private readonly ObservableCollectionImproved<DepartmentModel> _allDepartments = new();
        public IEnumerable<DepartmentModel> AllDepartments => _allDepartments;
        public async Task GetDataAsync() => _allDepartments.AddRange(await _departmentService.GetAll());
        public void GetData() => _ = GetDataAsync();
        #endregion

        #endregion

        #region Взаимодействоие с VM

        private readonly ObservableCollectionImproved<UserModel> _observableUser;

        #endregion

        #region Переменные

        private readonly UserModel _userModel;
        public string Surname
        {
            get => _userModel.Surname;
            set
            {
                _userModel.Surname = value;
                ValidateModelProperty(value, nameof(Surname), _userModel);
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string Name
        {
            get => _userModel.Name;
            set
            {
                _userModel.Name = value;
                ValidateModelProperty(value, nameof(Name), _userModel);
                OnPropertyChanged(nameof(Name));
            }
        }
        public string? Patronymic
        {
            get => _userModel.Patronymic;
            set
            {
                _userModel.Patronymic = value;
                ValidateModelProperty(value, nameof(Patronymic), _userModel);
                OnPropertyChanged(nameof(Patronymic));
            }
        }
        public DateOnly DateOfBirthDateOnly
        {
            get => _userModel.DateOfBirth;
            set
            {
                _userModel.DateOfBirth = value;
                ValidateModelProperty(value, nameof(DateOfBirth), _userModel);
            }
        }
        public DateTime DateOfBirth
        {
            get => DateOfBirthDateOnly.ToDateTime(TimeOnly.MinValue);
            set
            {
                DateOfBirthDateOnly = DateOnly.FromDateTime(value);
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }
        public GenderType Gender
        {
            get => _userModel.Gender;
            set
            {
                _userModel.Gender = value;
                ValidateModelProperty(value, nameof(Gender), _userModel);
                OnPropertyChanged(nameof(Gender));
            }
        }
        public DepartmentModel? DepartmentModel
        {
            get => _userModel.DepartmentModel;
            set
            {
                _userModel.DepartmentModel = value;
                if (value != null) _userModel.DepartmentId = value.Id;
                ValidateModelProperty(value, nameof(DepartmentModel), _userModel);
                OnPropertyChanged(nameof(DepartmentModel));
            }
        }

        #endregion

        #region Команды

        public ICommand AddCommand { get; }
        public void EditUser() => _ = EditUserAsync();
        public async Task EditUserAsync()
        {
            if (!HasErrors)
            {
                UserModel? userModel = DepartmentModel == null ?
                    await _userService.Update(_userModel.Id, new UserModel { Name = Name, Surname = Surname, Patronymic = Patronymic, Gender = Gender, DateOfBirth = DateOfBirthDateOnly }) :
                    await _userService.Update(_userModel.Id, new UserModel { Name = Name, Surname = Surname, Patronymic = Patronymic, Gender = Gender, DateOfBirth = DateOfBirthDateOnly, DepartmentId = DepartmentModel.Id });

                if (userModel != null)
                {
                    userModel.DepartmentModel = DepartmentModel;
                    _observableUser.Remove(_userModel);
                    _observableUser.Add(userModel);
                }

                CloseWindow();
            }
        }

        #endregion
    }
}