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
        public void EntityIsNullAfterCreateNotExpectedBehaviour()
        {
            EntityOps entityOps = new EntityOps(DbInit.DBInit().Context);
            Person person = entityOps.CreateAndGetPersoFromRelatedCollection();
            string error = @"Person received from collection of team is null. We need it not null.
                SaveChanges or DetectChagnes helps but frequent execution of save make app slow";
            Assert.IsNotNull(person, error);
        }

        [Test]
        public void EntityIsNotNullAfterDeleteNotExpectedBehaviour()
        {
            EntityOps entityOps = new EntityOps(DbInit.DBInit().Context);
            Person newPerson = entityOps.CreateAndSavePerson();
            Person deletedPerson = entityOps.DeleteAndGetPersonFromRelatedCollection(newPerson.Id);
            string error = @"Person received from collection of team is not null after delete. We need it null.
                SaveChanges helps but frequent execution of save make app slow";
            Assert.IsNull(deletedPerson, error);

        }

        [Test]
        public void EntityIsNotNullAfterCreate()
        {
            EntityOps entityOps = new EntityOps(DbInit.DBInit().Context);
            Person person = entityOps.CreateAndGetPersoFromRelatedCollection(saveChanges: true);
            Assert.IsNotNull(person);
        }

        [Test]
        public void EntityIsNullAfterDelete()
        {
            EntityOps entityOps = new EntityOps(DbInit.DBInit().Context);
            Person newPerson = entityOps.CreateAndSavePerson();
            Person deletedPerson = entityOps.DeleteAndGetPersonFromRelatedCollection(newPerson.Id, saveChanges: true);
            Assert.IsNull(deletedPerson);

        }
    }
}