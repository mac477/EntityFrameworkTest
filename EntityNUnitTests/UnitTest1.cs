using EntityTest;
using EntityTest.Entities;
using NUnit.Framework;

namespace EntityNUnitTests
{
    public class CreateEntityAndCheckRelatedCollectionStateAlgorithm
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EntityIsNotNullAfterCreate()
        {
            EntityOps entityOps = new EntityOps(DbInit.DBInit().Context);
            Person person = entityOps.CreateAndGetPersoFromRelatedCollectionn();
            string error = @"Person received from collection of team is null. We need it not null.
                SaveChanges or DetectChagnes helps but frequent execution of save make app slow";
            Assert.IsNotNull(person, error);
        }

        [Test]
        public void EntityIsNullAfterDelete()
        {
            EntityOps entityOps = new EntityOps(DbInit.DBInit().Context);
            int id = entityOps.CreateAndSavePerson();
            Person deletedPerson = entityOps.DeleteAndGetPersonFromRelatedCollection(id);
            string error = @"Person received from collection of team is not null after delete. We need it null.
                SaveChanges helps but frequent execution of save make app slow";
            Assert.IsNull(deletedPerson, error);

        }
    }
}