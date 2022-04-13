using System;
namespace testMvcProject.Models.Resources.ImplementedResources
{
    public class Profile : resource
    {
        private double storeMargin;


        public Profile() { }

        public Profile(string name,
                        int costPrice, double storeMargin)
            : base(name, costPrice)
        {
            this.storeMargin = storeMargin;
            this.setResourceType(ResourceType.PROFILE);
        }

        public override double getStorePrice() => storeMargin;

        public void setStoreMarginCoef(double storeMargin) {
            this.storeMargin = storeMargin;
        }
        
    }
}
