using System;

namespace EF_Plus_Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            ControllerDB dbController = new ControllerDB();
            dbController.setUserToDB(new User { Name = "Tom", Surname = "Jo", PrimarySkill = "Java", Location = "Minsk" });
            dbController.setUserToDB(new User { Name = "Rom", Surname = "JoJo", PrimarySkill = "C#", Location = "Grodno" });
            dbController.setUserToDB(new User { Name = "Pom", Surname = "RoJo", PrimarySkill = "JS", Location = "NY" });
            dbController.setUserToDB(new User { Name = "Vom", Surname = "FoJo", PrimarySkill = "COBOL", Location = "London" });
            dbController.showAllUsersFromDB();
        }
    }
}
