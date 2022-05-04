using System;
namespace testMvcProject.Models.Users
{
    public class Adress
    {
        public String City { get; set; }
        public String StreetName { get; set; }
        public String HouseNumber { get; set; }

        public Adress() { }

        public Adress(string city, string streetName, string houseNumber)
        {
            City = city;
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return City + " " +
                   StreetName + " " +
                   HouseNumber;
        }
    }
}
