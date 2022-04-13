using System;
using testMvcProject.Models.Resources.ImplementedResources;

namespace testMvcProject.Models.Products
{
    public abstract class product 
    {
        private double height;
        private double width;

        private Furniture furniture;
        private Profile profile;

        public product() { }

        public product(double height, double width,
            Furniture furniture, Profile profile)
        {
            this.height = height;
            this.width = width;
            this.furniture = furniture;
            this.profile = profile;
        }

        public void setHeight(double height) { this.height = height; }
        public void setWidth(double width) { this.width = width; }
        public void setFurniture(Furniture furniture) { this.furniture = furniture; }
        public void setProfile(Profile profile) { this.profile = profile; }

        public double getHeight() => height;
        public double getWidth() => width;
        public Furniture getFurniture() => furniture;
        public Profile getProfile() => profile;



    }
}
