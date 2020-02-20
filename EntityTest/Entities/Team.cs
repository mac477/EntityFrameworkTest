using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest.Entities
{
    public class Team
    {
        public Team(int id)
        {
            Id = id;
            PersonColl = new HashSet<Person>();
        }

        public int Id { get; set; }
        public ICollection<Person> PersonColl { get; set; }
    }
}
