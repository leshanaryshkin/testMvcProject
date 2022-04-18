using System;
namespace testMvcProject.Models.Resources
{
    public abstract class resource
    {
        public ResourceType ResourceType { get; set; }
        public string Name { get; set; }
        public double CostPrice { get; set; }

        public resource() { }

        public resource(string name, int costPrice)
        {
            this.Name = name;
            this.CostPrice = costPrice;
        }
        
        public abstract double getStorePrice();
        
    }
}
