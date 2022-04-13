using System;
using System.Collections.Generic;
using testMvcProject.Models.Resources.ImplementedResources;

namespace testMvcProject.Models.DAOs.ProductsDAO
{
    public class WindowsDAOClass
    {
        List<Window> windowsArray = new List<Window>();

        public WindowsDAOClass()
        {
            Furniture furniture1 = new Furniture("deshevaya", 1500, 2500);
            Furniture furniture2 = new Furniture("dorogaya", 2500, 3700);

            Profile profile1 = new Profile("desheviy", 3000, 3900);
            Profile profile2 = new Profile("dorogoi", 6000, 10400);
            Window window1 = new Window(190, 90, furniture1, profile1, 3, true);
            Window window2 = new Window(240, 90, furniture2, profile2, 3, false);
            Window window3 = new Window(160, 90, furniture1, profile2, 3, true);

            windowsArray.Add(window1);
            windowsArray.Add(window2);
            windowsArray.Add(window3);

        }

        public List<Window> getList() => windowsArray;

        public int a() => 500;
    }
}
