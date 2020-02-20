class Person
{
	public Person(string name)
	{
		Name = name;
	}
	
	int Id{get;set;}
	string Name{get;set;}
	Team TeamRel{get;set;}
}

class Team
{
	int Id{get;set;}
	ICollection<Person> PersonColl{get;set;}
}

class CreateEntityAndCheckRelatedCollectionStateAlgorithm : AlgorithmBase
{
	public void EntityIsNullAfterCreate(Dto dataObject)
	{
		Person p = new Person("person1");
		//team with id 1 already exists
		p.TeamRel = GetEntity<Team>(1);
		
		
		(...)
		
		Team team = GetEntity<Team>(1);
		Person p2 = team.PersonColl.FirstOrDefault(f => f.Name.Equals("person1"));
		//p2 equals null;
		
		
		SaveChanges();
	}
	
	public void EntityIsNotNullAfterDelete(Dto dataObject)
	{
		Person p = new Person("person1");
		//team with id 1 already exists
		p.TeamRel = GetEntity<Team>(1);
		SaveChanges();
		
		(...)
		
		Team team = GetEntity<Team>(1);
		Person p2 = team.PersonColl.FirstOrDefault(f => f.Name.Equals("person1"));
		//p2 is not null because of above SaveChanges
		Delete(p2);
		p2 = team.PersonColl.FirstOrDefault(f => f.Name.Equals("person1"));
		//p2 still is not null
		
		SaveChanges();
		
		p2 = team.PersonColl.FirstOrDefault(f => f.Name.Equals("person1"));
		//Now p2 is null
	}
}