using System;
namespace testMvcProject.Models.Users
{
    public class Person
    {
        protected static int PersonCount = 1;
        public int PersonID { get; set; } = PersonCount;

        public String Name { get; set; }
        public String Telephone { get; set; }
        
        public String Password { get; set; }

        public string Adress { get; set; }



        public Person(String Name, String Telephone,
            String Adress , bool IsAdmin = false)
        {
            PersonCount++;
            this.Name = Name;
            this.Telephone = Telephone;
            this.Adress = Adress;
            this.Password = (IsAdmin == true) ? Convert.ToString(Name): "Admin";
        }

        public Person()
        {
            PersonCount++;
        }

        public Person(Person person)
            : this(person.Name, person.Telephone, person.Adress)
        {
        }

        public override string ToString()
        {
            return Name + " " + Telephone + " " + Adress;
        }
    }
}
