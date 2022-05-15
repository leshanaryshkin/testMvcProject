using System;
namespace testMvcProject.Models.Resources.ImplementedResources
{
    public class Profile : resource
    {
        public double storeMargin { get; set; }
        public int onStock { get; set; }

        public bool activePosition { get; set; } = true;

        public Profile() { }

        public Profile(string name,
                        int costPrice, double storeMargin, int onStock = 0)
            : base(name, costPrice)
        {
            this.storeMargin = storeMargin;
            this.ResourceType = ResourceType.PROFILE;
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
