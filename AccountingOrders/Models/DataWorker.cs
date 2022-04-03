using AccountingOrders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AccountingOrders.Models
{
    public static class DataWorker
    {
        #region Получить все записи + связанные объекты
        public static List<DepartmentModel>? GetAllDepartments()
        {
            using ApplicationContext DB = new();
            if (DB.Department != null) return DB.Department.Include(c => c.UserModel).ToList();
            return null;
        }
        public static List<OrderModel>? GetAllOrders()
        {
            using ApplicationContext DB = new();
            if (DB.Order != null) return DB.Order.Include(c => c.UserModel).ToList();
            return null;
        }
        public static List<UserModel>? GetAllUsers()
        {
            using ApplicationContext DB = new();
            if (DB.User != null) return DB.User.Include(c => c.DepartmentModel).ToList();
            return null;
        }
        #endregion

        #region Добавить новую запись
        public static void AddNewDepartment(DepartmentModel Department)
        {
            using ApplicationContext DB = new();
            if (DB.Department == null) return;
            DB.Department.Add(Department);
            DB.SaveChanges();
        }
        public static void AddNewOrder(OrderModel Order)
        {
            using ApplicationContext DB = new();
            if (DB.Order == null) return;
            DB.Order.Add(Order);
            DB.SaveChanges();
        }
        public static void AddNewUser(UserModel User)
        {
            using ApplicationContext DB = new();
            if (DB.User == null) return;
            DB.User.Add(User);
            DB.SaveChanges();
        }
        #endregion
    }
}