﻿using System;
namespace testMvcProject.Models.Resources.ImplementedResources
{
    public class Furniture : resource
    {
        public double storeMargin { get; set; }
        public int onStock { get; set; }

        public bool activePosition { get; set; } = true;
        public Furniture() { }

        public Furniture(string name,
                        double costPrice, double storeMargin, int onStock = 0)
            : base(name, costPrice)
        {
            this.storeMargin = storeMargin;
            this.ResourceType = ResourceType.FURNITURE;
            this.onStock = onStock;
        }


        public override string ToString()
        {
            return($"Name:{Name}" + " " +
                   $"costPrice:{CostPrice}" + " " +
                   $"storeMargin:{storeMargin}" + " " +
                   $"onStock:{onStock}");
        }
    }
}
