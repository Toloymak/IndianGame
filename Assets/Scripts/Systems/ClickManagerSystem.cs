using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class ClickManagerSystem : IEcsRunSystem
    {
        private EcsFilter<ClickableComponent> _filter = null;

        public void Run()
        {
            foreach (var id in _filter)
            {
                var clickableComponent = _filter.Get1[id];

                if (!clickableComponent.IsClicked && clickableComponent.IsActionCompleted)
                    clickableComponent.IsActionCompleted = false;
            }
        }
    }
}