using System.Collections.Generic;
using System.Linq;
using Leopotam.Ecs;

namespace Components
{
    public class ResourceComponent
    {
        [EcsIgnoreNullCheck]
        public IList<ResourceItem> ResourceItems;

        public int GetDanger() 
            => ResourceItems.Sum(x => x.Danger);
        
        public int GetStability() 
            => ResourceItems.Sum(x => x.Stability);
    }
}