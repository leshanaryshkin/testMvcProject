using System;
namespace testMvcProject.Models.Resources.ImplementedResources
{
    public class Furniture : resource
    {
        private double storeMargin;


        public Furniture() { }

        public Furniture(string name,
                        int costPrice, double storeMargin)
            : base(name, costPrice)
        {
            this.storeMargin = storeMargin;
            this.ResourceType = ResourceType.FURNITURE;

        }

        public override double getStorePrice() => storeMargin;

        public void setStoreMarginCoef(double storeMarginCoef)
        {
            this.storeMargin = storeMarginCoef;
        }


    }
}
