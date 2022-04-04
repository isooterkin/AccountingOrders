using AccountingOrders.Domain.Models;

namespace AccountingOrders.WPF.ViewsModels.Actions
{
    public class ViewUserViewModel: ViewModelBase
    {
        #region Конструктор

        public ViewUserViewModel(UserModel userModel)
        {
            #region Модель

            _userModel = userModel;

            #endregion
        }

        #endregion

        #region Модель для визуализации

        private readonly UserModel _userModel;

        #endregion

        #region Переменные

        public string Surname => _userModel.Surname;
        public string Name => _userModel.Name;
        public string? Patronymic => _userModel.Patronymic;
        public string DateOfBirth => _userModel.DateOfBirth.ToString();
        public string GenderType => _userModel.Gender.ToString();
        public string? Department => _userModel.DepartmentModel?.Name;

        #endregion
    }
}