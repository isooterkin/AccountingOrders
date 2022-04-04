using AccountingOrders.Domain.Models;

namespace AccountingOrders.WPF.ViewsModels.Actions
{
    public class ViewOrderViewModel: ViewModelBase
    {
        #region Конструктор

        public ViewOrderViewModel(OrderModel orderModel)
        {
            #region Модель

            _orderModel = orderModel;

            #endregion
        }

        #endregion

        #region Модель для визуализации

        private readonly OrderModel _orderModel;

        #endregion

        #region Переменные

        public int Number => _orderModel.Number;
        public string Name => _orderModel.Name;
        public string FIO => _orderModel.UserModel != null ? _orderModel.UserModel.GetFIO : "";

        #endregion
    }
}