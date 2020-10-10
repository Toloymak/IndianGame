using Components;
using Extensions;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class StructureRunSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        
        private EcsFilter<StructureComponent, ClickableComponent> _filter = null;

        public void Run()
        {
            foreach (var id in _filter)
            {
                var structureComponent = _filter.Get1[id];
                var clickableComponent = _filter.Get2[id];

                clickableComponent.IsClicked = structureComponent.Object.IsClicked(0);
            }
        }
    }
}