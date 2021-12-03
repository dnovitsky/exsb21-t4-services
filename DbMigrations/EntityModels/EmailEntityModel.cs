﻿using System;
using DbMigrations.EntityModels.DataTypes;

namespace DbMigrations.EntityModels
{
    public class EmailEntityModel
    {
        public Guid Id { get; set; }
        public string EmailFrom { get; set; }
        public string Head { get; set; }
        public string Message { get; set; }
        public string EmailTo { get; set; }
        public EmailStatusType Status { get; set; }
    }
}