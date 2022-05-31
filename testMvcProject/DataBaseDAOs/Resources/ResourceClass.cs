﻿using System;
using System.Collections.Generic;
using testMvcProject.DataBaseDAOs.Resources.Profile;
using testMvcProject.DataBaseDAOs.Resources.Furniture;
using testMvcProject.DataBaseDAOs.Balance;


namespace testMvcProject.DataBaseDAOs.Resources
{
    public class ResourceClass
    {
        public readonly IFurnitureManager furnitureManager;
        public readonly IProfileManager profileManager;
        public readonly IBalanceManager balanceManager;

        public ResourceClass(IFurnitureManager furnitureManager,
            IProfileManager profileManager, IBalanceManager balanceManager)
        {
            this.furnitureManager = furnitureManager;
            this.profileManager = profileManager;
            this.balanceManager = balanceManager;
        }
    }
}
