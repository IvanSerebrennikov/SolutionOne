using System;
using System.Collections.Generic;
using System.Text;
using SO.DataAccess.Interfaces.Entity;

namespace SO.DataAccess.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public UserAdditionalInfo AdditionalInfo { get; set; }

        public List<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}
