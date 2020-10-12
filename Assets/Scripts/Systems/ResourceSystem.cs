using System.Collections;
using System.Collections.Generic;
using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class ResourceSystem : IEcsInitSystem
    {
        readonly EcsWorld _world = null;

        private readonly IList<ResourceItem> _defaultResources = new List<ResourceItem>()
        {
            new ResourceItem("Alien lands")
            {
                Danger = 5,
            }
        };
        
        public void Init()
        {
            var entity = _world.NewEntity();
            var resources = entity.Set<ResourceComponent>();
            resources.ResourceItems = _defaultResources;
        }
    }
}