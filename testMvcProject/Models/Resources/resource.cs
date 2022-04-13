using System;
namespace testMvcProject.Models.Resources
{
    public abstract class resource
    {
        private ResourceType resourceType;
        private string name;
        private double costPrice;

        public resource() { }

        public resource(string name, int costPrice)
        {
            this.name = name;
            this.costPrice = costPrice;
        }

        protected ResourceType GetResourceType()
        {
            return resourceType;
        }

        protected string getName()
        {
            return name;
        }

        protected double getCostPrice()
        {
            return costPrice;
        }

        protected void setResourceType(ResourceType ResourceType)
        {
            this.resourceType = ResourceType;
        }

        protected void setName(string name)
        {
            this.name = name;
        }

        protected void setCostPrice(int costPrice)
        {
            this.costPrice = costPrice;
        }

        public abstract double getStorePrice();

    }
}
