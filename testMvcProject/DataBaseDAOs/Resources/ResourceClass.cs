using System;
using System.Collections.Generic;
using testMvcProject.DataBaseDAOs.Resources.Profile;
using testMvcProject.DataBaseDAOs.Resources.Furniture;


namespace testMvcProject.DataBaseDAOs.Resources
{
    public class ResourceClass
    {
        public readonly IFurnitureManager furnitureManager;
        public readonly IProfileManager profileManager;

        public ResourceClass(IFurnitureManager furnitureManager, IProfileManager profileManager)
        {
            this.furnitureManager = furnitureManager;
            this.profileManager = profileManager;
        }
    }
}
