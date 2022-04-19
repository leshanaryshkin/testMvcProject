using System;
namespace testMvcProject.Models.Users
{
    public class Person
    {
        protected static int PersonCount = 1;
        public int PersonID { get; set; } = PersonCount;

        public String Name { get; set; }
        public String Telephone { get; set; }
        public Adress adress;

        public string Password { get; set; }
        public bool IsAdmin { get; set; }


        public Adress getAdress()
        {
            return adress;
        }


        public void setAdress (String City,
            String StreetName, String HouseNumber)
        {
            this.adress.City = City;
            this.adress.StreetName = StreetName;
            this.adress.HouseNumber = HouseNumber;
        }

        public Person(String Name, String Telephone = null,
            Adress adress = null, bool IsAdmin = false)
        {
            PersonCount++;
            this.Name = Name;
            this.Telephone = Telephone;
            this.adress = adress;
            this.Password = (IsAdmin == true) ? Convert.ToString(Name): "Admin";
        }

        public Person()
        {
            PersonCount++;
        }

        public Person(Person person)
            : this(person.Name, person.Telephone, person.getAdress())
        {
        }

    }
}
