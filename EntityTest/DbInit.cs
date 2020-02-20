using EntityTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityTest
{
    public class DbInit
    {
        public MyContext Context;

        static DbInit dbInit;
        private DbInit()
        {
            DbContextOptions<MyContext> options = new DbContextOptionsBuilder<MyContext>()
                  .UseInMemoryDatabase(databaseName: "Test")
                  .Options;

            Context = new MyContext(options);
            Team team = new Team(Context.NextIdTeam);
            Context.Teams.Add(team);
            Context.SaveChanges();
        }

        public static DbInit DBInit()
        {
            if (dbInit == null)
            {
                dbInit = new DbInit();
            }
            return dbInit;

        }

        public void DbDispose()
        {
            Context.Dispose();
        }
    }
}
