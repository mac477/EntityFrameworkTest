using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest.Entities
{
    public class Person
    {
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Team TeamRel { get; set; }
    }
}
