using AccountingOrders.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using AccountingOrders.Views;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AccountingOrders.Tools;
using static AccountingOrders.Tools.OpeningWindows;
using static AccountingOrders.Tools.UpdateViewWindows;

namespace AccountingOrders.ViewsModels
{
    public class DataManageVM: INotifyPropertyChanged
    {
        #region Получить все записи
        #region Получить все записи Departments
        private List<DepartmentModel>? __AllDepartments = DataWorker.GetAllDepartments();
        public List<DepartmentModel>? AllDepartments
        {
            get => __AllDepartments; 
            set
            {
                __AllDepartments = value;
                NotifyPropertyChanged("AllDepartments");
            }
        }
        #endregion

        #region Получить все записи Orders
        private List<OrderModel>? __AllOrders = DataWorker.GetAllOrders();
        public List<OrderModel>? AllOrders
        {
            get => __AllOrders;
            set
            {
                __AllOrders = value;
                NotifyPropertyChanged("AllOrders");
            }
        }
        #endregion

        #region Получить все записи Users
        private List<UserModel>? __AllUsers = DataWorker.GetAllUsers();
        public List<UserModel>? AllUsers
        {
            get => __AllUsers;
            set
            {
                __AllUsers = value;
                NotifyPropertyChanged("AllUsers");
            }
        }
        #endregion
        #endregion

        #region Свойства
        public string? NewDepartmentName { get; set; }
        public UserModel? NewDepartmentUserModel { get; set; }

        public string? NewOrderName { get;set; }
        public int? NewOrderNumber { get; set; }
        public UserModel? NewOrderUserModel { get; set; } // !!!
        public string? NewUserSurname { get; set; }

        public string? NewUserName { get; set; }
        public string? NewUserPatronymic { get; set; }
        public DateTime? NewUserDateOfBirth { get; set; }
        public GenderType? NewUserGender { get; set; }
        public DepartmentModel? NewUserDepartmentModel { get; set; } // !!!
        #endregion

        #region Обновление таблиц
        private void SetNullValuesProperties()
        {
            NewDepartmentName = null;
            NewDepartmentUserModel = null;
            NewOrderName = null;
            NewOrderName = null;
            NewOrderNumber = null;
            NewOrderUserModel = null;
            NewUserSurname = null;
            NewUserName = null;
            NewUserPatronymic = null;
            NewUserDateOfBirth = null;
            NewUserGender = null;
            NewUserDepartmentModel = null;
        }
        #endregion

        #region Команды добавления
        public readonly RelayCommand? __addNewDepartment;
        public RelayCommand AddNewDepartment
        {
            get
            {
                return __addNewDepartment ?? new RelayCommand(obj =>
                {
                    DepartmentModel Department = new() { Name = NewDepartmentName, UserId = NewDepartmentUserModel.Id };
                    DataWorker.AddNewDepartment(Department);
                    UpdateAllDataView();
                    SetNullValuesProperties();
                    if (obj is Window wnd) wnd.Close();
                });
            }
        }

        private readonly RelayCommand? __addNewOrder;
        public RelayCommand AddNewOrder
        {
            get
            {
                return __addNewOrder ?? new RelayCommand(obj =>
                {
                    OrderModel Order = new() { Name = NewOrderName, Number = NewOrderNumber, UserId = NewOrderUserModel.Id };
                    DataWorker.AddNewOrder(Order);
                    UpdateAllDataView();
                    SetNullValuesProperties();
                    if (obj is Window wnd) wnd.Close();
                });
            }
        }

        private readonly RelayCommand? __addNewUser;
        public RelayCommand AddNewUser
        {
            get
            {
                return __addNewUser ?? new RelayCommand(obj =>
                {
                    NewUserDateOfBirth = new DateTime();



                    UserModel User = new() { Surname = NewUserSurname, Name = NewUserName, Patronymic = NewUserPatronymic, DateOfBirth = NewUserDateOfBirth, Gender = NewUserGender, DepartmentId = NewUserDepartmentModel.Id };
                    DataWorker.AddNewUser(User);
                    UpdateAllDataView();
                    SetNullValuesProperties();
                    if (obj is Window wnd) wnd.Close();
                });
            }
        }
        #endregion

        #region Команды открытия окон
        private readonly RelayCommand? __openAddNewDepartmentWindowCommand;
        public RelayCommand OpenAddNewDepartmentWindowCommand
        {
            get
            {
                return __openAddNewDepartmentWindowCommand ?? new RelayCommand(obj =>
                {
                    OpenAddNewDepartmentWindowMethod();
                });
            }
        }


        private readonly RelayCommand? __openAddNewOrderWindowCommand;
        public RelayCommand OpenAddNewOrderWindowCommand
        {
            get 
            { 
                return __openAddNewOrderWindowCommand ?? new RelayCommand(obj => 
                {
                    OpenAddNewOrderWindowMethod(); 
                }); 
            }
        }
        private readonly RelayCommand? __openAddNewUserWindowCommand;
        public RelayCommand OpenAddNewUserWindowCommand
        {
            get 
            { 
                return __openAddNewUserWindowCommand ?? new RelayCommand(obj => 
                { 
                    OpenAddNewUserWindowMethod(); 
                }); 
            }
        }
        #endregion

        #region Обработчик событий
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion
    }
}