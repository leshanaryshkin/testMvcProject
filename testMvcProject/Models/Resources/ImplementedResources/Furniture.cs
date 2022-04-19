using System;
namespace testMvcProject.Models.Resources.ImplementedResources
{
    public class Furniture : resource
    {
        public double storeMargin { get; set; }


        public Furniture() { }

        public Furniture(string name,
                        int costPrice, double storeMargin)
            : base(name, costPrice)
        {
            this.storeMargin = storeMargin;
            this.ResourceType = ResourceType.FURNITURE;
        }

        



    }
}
