using System.Globalization;
using System.Linq;
using Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    public class StabilitySystem : IEcsInitSystem, IEcsRunSystem
    {
        readonly EcsWorld _world = null;
        private EcsFilter<StabilityComponent, LabelComponent> _stabilityComponents = null;
        private EcsFilter<DangerComponent> _dangerComponent = null;
        private EcsFilter<ResourceComponent> _resources = null;


        private const long DefaultStability = 0;
        
        public void Init()
        {
            var entity = _world.NewEntity();
            var stabilityComponent = entity.Set<StabilityComponent>();
            
            var label = entity.Set<LabelComponent>();
            label.NameObject = GameObject.Find("StabilityName");
            label.ValueObject = GameObject.Find("StabilityValue");
        }

        public void Run()
        {
            UpdateStabilityUi();
        }

        private void UpdateStabilityUi()
        {
            var resource = _resources.Get1.First();
            var label = _stabilityComponents.Get2.First();

            label.ValueObject.GetComponent<Text>().text = resource
                .GetStability()
                .ToString(CultureInfo.InvariantCulture);
        }
    }
}