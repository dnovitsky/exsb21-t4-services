using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_plus_Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
                // создаем два объекта User
                User user1 = new User { FirstName= "Nikita", LastName="Shakhnovich", Login="Shakh", Password="1sttry" , Email="Shakh@gmail.com"};

                // добавляем их в бд
                db.Users.Add(user1);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Users;
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.LastName, u.FirstName);
                }
            }
            Console.Read();
        }
    }
}
