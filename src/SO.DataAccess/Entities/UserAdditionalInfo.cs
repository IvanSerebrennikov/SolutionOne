using System;
using System.Collections.Generic;
using System.Text;
using SO.DataAccess.Interfaces.Entity;

namespace SO.DataAccess.Entities
{
    public class UserAdditionalInfo : IEntity
    {
        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public int Gender { get; set; }
    }
}
