using System;
using System.Collections.Generic;
using System.Linq;
using DbMigrations.Data;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Helpers
{
    public class EventHelper : IApplicationHelper
    {

        private AppDbContext _dbContext;

        private readonly List<EventEntityModel> events = new()
        {
            new EventEntityModel
            {
                                         Summary="Free Time",
                                            Description = "Free Time Description",
                                            Type = DbMigrations.EntityModels.DataTypes.EventType.FREE,
                                            StartTime = new DateTime(2021, 12, 9, 9, 0, 0),
                                            EndTime = new DateTime(2021, 12, 9, 9, 30, 0)
                                        },
            
                new EventEntityModel
                {
                    Summary = "Free Time",
                    Description = "Free Time Description",
                    Type = DbMigrations.EntityModels.DataTypes.EventType.FREE,
                    StartTime = new DateTime(2021, 12, 8, 9, 0, 0),
                    EndTime = new DateTime(2021, 12, 8, 9, 30, 0)
                },
                new EventEntityModel
                {
                    Summary = "Free Time",
                    Description = "Free Time Description",
                    Type = DbMigrations.EntityModels.DataTypes.EventType.GOOGLE,
                    StartTime = new DateTime(2021, 12, 8, 10, 0, 0),
                    EndTime = new DateTime(2021, 12, 8, 10, 30, 0)
                },
                new EventEntityModel
                {
                    Summary = "Free Time",
                    Description = "Free Time Description",
                    Type = DbMigrations.EntityModels.DataTypes.EventType.GOOGLE,
                    StartTime = new DateTime(2021, 12, 8, 12, 0, 0),
                    EndTime = new DateTime(2021, 12, 8, 12, 30, 0)
                },
                new EventEntityModel
                {
                    Summary = "Free Time",
                    Description = "Free Time Description",
                    Type = DbMigrations.EntityModels.DataTypes.EventType.INTERVIEW,
                    StartTime = new DateTime(2021, 12, 9, 13, 0, 0),
                    EndTime = new DateTime(2021, 12, 9, 13, 30, 0)
                }
            
        };
        public EventHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateTestData()
        {
            foreach (var dic in events)
            {
                var user = _dbContext.Users.Where(x => x.Email == "interviewer.sapex.2021@gmail.com").FirstOrDefault();
                dic.OwnerId = user.Id;
                dic.CandidateSandboxId = null;
                _dbContext.Events.Add(dic);

            }
            _dbContext.SaveChanges();
        }

            public void ClearTestData()
        {
            throw new NotImplementedException();
        }
    }
}
