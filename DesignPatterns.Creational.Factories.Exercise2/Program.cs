namespace DesignPatterns.Creational.Factories.Exercise2
{
	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class PersonFactory
	{
		private static int _id;

		public Person CreatePerson(string name)
		{
			return new Person()
			{
				Name = name,
				Id = _id++
			};
		}
	}


	internal class Program
	{
		static void Main()
		{
			PersonFactory factory = new PersonFactory();
			Person fred = factory.CreatePerson("Fred");
			Person sally = factory.CreatePerson("Sally");

			Console.WriteLine($"{fred.Name} {fred.Id}");
			Console.WriteLine($"{sally.Name} {sally.Id}");
		}
	}
}