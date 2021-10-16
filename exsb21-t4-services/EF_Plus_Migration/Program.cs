using System;

namespace EF_Plus_Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            ControllerDB dbController = new ControllerDB();
            dbController.setUserToDB(new User { Name = "Tom", Surname = "Jo", PrimarySkill = "Java", Location = "Minsk", CourseName = "1" });
            dbController.setUserToDB(new User { Name = "Rom", Surname = "JoJo", PrimarySkill = "C#", Location = "Grodno", CourseName = "2" });
            dbController.setUserToDB(new User { Name = "Pom", Surname = "RoJo", PrimarySkill = "JS", Location = "NY", CourseName = "3" });
            dbController.setUserToDB(new User { Name = "Vom", Surname = "FoJo", PrimarySkill = "COBOL", Location = "London", CourseName = "4" });

            dbController.showAllUsersFromDB();
        }
    }
}
