using EntityTest.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityTest
{
    public class AlgorithmBase
    {
        protected MyContext DbContext;

        public AlgorithmBase(MyContext ctx)
        {
            DbContext = ctx;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Remove(entity);
        }
    }

    public class EntityOps : AlgorithmBase
    {
        public EntityOps(MyContext ctx) : base(ctx)
        {

        }

        public Person CreatePerson()
        {
            Person person = new Person(DbContext.NextIdPerson, "person1");
            person.TeamRel = DbContext.Teams.Find(1);
            return person;
        }

        public Person CreateAndSavePerson()
        {
            Person person = CreatePerson();
            DbContext.PersonColl.Add(person);
            SaveChanges();
            return person;
        }

        public Person CreateAndGetPersoFromRelatedCollection(bool saveChanges = false)
        {
            Person p = null;
            if (saveChanges)
                p = CreateAndSavePerson();
            else
                p = CreatePerson();
            Team team = DbContext.Teams.Find(1);
            Person p2 = team.PersonColl.FirstOrDefault(f => f.Id == p.Id);
            return p2;
        }

        public Person DeleteAndGetPersonFromRelatedCollection(int personId, bool saveChanges = false)
        {
            Team team = DbContext.Teams.Find(1);
            Person person = team.PersonColl.FirstOrDefault(f => f.Id == personId);
            Delete(person);
            if (saveChanges)
                SaveChanges();
            return team.PersonColl.FirstOrDefault(f => f.Id == personId);
        }
    }
}
