using System.Collections.Generic;
using System.Linq;
using Leopotam.Ecs;

namespace Components
{
    public class ResourceComponent
    {
        public float Food { get; set; }
        public float Gold { get; set; }
        public float Materials { get; set; }
        public IList<PersonModel> Persons { get; set; } = new List<PersonModel>();
        public IList<EffectItem> EffectItems { get; set; } = new List<EffectItem>();
        
        // todo: need splitting
        public LabelComponent FoodLabel { get; set; }
        public LabelComponent GoldLabel { get; set; }
        public LabelComponent MaterialsLabel { get; set; }
        
        public LabelComponent PersonLabel { get; set; }
        public LabelComponent EffectLabel { get; set; }

        public float GetDanger()
            => EffectItems.Sum(x => x.Danger);

        public float GetStability()
            => EffectItems.Sum(x => x.Stability)
               + Persons.Sum(x => x.Supplementation / 10)
               + Food / 100
               + Gold / 100;
    }
}