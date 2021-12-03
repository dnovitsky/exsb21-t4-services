using System;
namespace DbMigrations.EntityModels.DataTypes
{
    public enum EmailStatusType
    {
        None = 0,
        ReadyForSend = 1,
        InProcess = 2,
        Sent = 3,
        Fail = 4
    }
}
