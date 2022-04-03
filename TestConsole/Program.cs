using AccountingOrders.Domain.Models;
using AccountingOrders.Domain.Services;
using AccountingOrders.EntityFramework;
using AccountingOrders.EntityFramework.Services;

Console.WriteLine("Hello, World!");

IDataService<UserModel> userService = new GenericDataService<UserModel>(new AccountingOrdersDbContextFactory());

userService.Create(new UserModel 
{ 
    Surname = "Пархом",
    Name = "Кирилл",
    Patronymic = "Александрович",
    DateOfBirth = DateTime.Now,
    Gender = AccountingOrders.Domain.Tools.GenderType.Мужчина,
    DepartmentId = null
}).Wait();


Console.WriteLine("Количество");
int count = userService.GetAll().Result.Count();
Console.WriteLine(count);

Console.WriteLine("Взял 1");
Console.WriteLine(userService.Get(Int32.MaxValue).Result);

Console.WriteLine("Взял 2");
Console.WriteLine(userService.Get(count).Result);

Console.WriteLine("Обновил 1");
Console.WriteLine(userService.Update(0, new UserModel
{
    Surname = "Пархом Новый",
    Name = "Кирилл",
    Patronymic = "Александрович",
    DateOfBirth = DateTime.Now,
    Gender = AccountingOrders.Domain.Tools.GenderType.Мужчина,
    DepartmentId = null
}).Result);

Console.WriteLine("Обновил 2");
Console.WriteLine(userService.Update(count, new UserModel
{
    Surname = "Пархом Новый",
    Name = "Кирилл",
    Patronymic = "Александрович",
    DateOfBirth = DateTime.Now,
    Gender = AccountingOrders.Domain.Tools.GenderType.Мужчина,
    DepartmentId = null
}).Result);

Console.WriteLine("Удалил 1");
Console.WriteLine(userService.Delete(Int32.MaxValue).Result);

Console.WriteLine("Удалил 2");
Console.WriteLine(userService.Delete(count).Result);