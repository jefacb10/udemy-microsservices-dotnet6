using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 10; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person() { 
                Id = IncrementAndGet(), 
                FirstName = "Person Name" +i, 
                LastName = "Person Last Name"+i,
                Address = "Same Address",
                Gender="Masc"
            };
            
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return MockPerson(Convert.ToInt32(id));
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
