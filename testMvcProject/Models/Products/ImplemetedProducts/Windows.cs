using System;
using testMvcProject.Models.Products;
using testMvcProject.Models.Resources.ImplementedResources;

namespace testMvcProject.Models
{
    public class Window : product, ICalculating
    {

        private int howManyCameras;
        private double[] camerasCoef = { 1, 1.4, 1.7, 1.9, 2.15, 2.35 };
        private bool neewWindowInstallation;


        public Window() { }

        public Window(double height, double width,
            Furniture furniture, Profile profile,
            int howManyCameras, bool neewWindowInstallation)
            : base(height, width, furniture, profile)
        {
            this.howManyCameras = howManyCameras;
            this.neewWindowInstallation = neewWindowInstallation;
        }

        public double getPerimeter() => 2 * (base.getWidth() + base.getHeight());

        public double calculate()
        {
            double price = 0;
            price += getPerimeter() / 100.0 * base.getProfile().storeMargin;
            price += base.getFurniture().storeMargin;
            price += (neewWindowInstallation ? 1000 : 0);
            price = price * camerasCoef[howManyCameras - 2];
            return price;
        }

        public int getHowManyCameras() => howManyCameras;
        public bool getNeewWindowInstallation() => neewWindowInstallation;

        public void setHowManyCameras(int howManyCameras) { this.howManyCameras = howManyCameras; }
        public void setHowManyCameras(bool nWI) {this.neewWindowInstallation = nWI; }

    }
}
