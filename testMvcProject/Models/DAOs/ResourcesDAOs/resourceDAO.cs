using System;
using testMvcProject.Models.Resources.ImplementedResources;
using testMvcProject.Models.Resources;
using System.Collections.Generic;

namespace testMvcProject.Models.DAOs.ResourcesDAOs
{
    public class resourceDAO 
    {
        List<resource> list = new List<resource>();

        public resourceDAO()
        {
            list.Add(new Profile("Дешёвый", 400, 550));
            list.Add(new Profile("Средний", 600, 850));
            list.Add(new Profile("Дорогой", 900, 1250));
            list.Add(new Furniture("Дешёвая", 240, 1032));
        }

        

        public List<resource> getList() => list;

        
    }
}
