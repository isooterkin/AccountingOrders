using AccountingOrders.Domain.Models;

namespace AccountingOrders.WPF.ViewsModels.Actions
{
    public class ViewDepartmentViewModel: ViewModelBase
    {
        #region Конструктор

        public ViewDepartmentViewModel(DepartmentModel departmentModel)
        {
            #region Модель

            _departmentModel = departmentModel;

            #endregion
        }

        #endregion

        #region Модель для визуализации

        private readonly DepartmentModel _departmentModel;

        #endregion

        #region Переменные

        public string Name => _departmentModel.Name;
        public string FIO => _departmentModel.UserModel != null ? _departmentModel.UserModel.GetFIO : "";

        #endregion
    }
}