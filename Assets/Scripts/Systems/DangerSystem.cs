using System.Linq;
using Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    public class DangerSystem : IEcsInitSystem, IEcsRunSystem
    {
        readonly EcsWorld _world = null;
        
        private EcsFilter<DangerComponent, LabelComponent> _label = null;
        private EcsFilter<ResourceComponent> _resources = null;

        public void Init()
        {
            var entity = _world.NewEntity();
            entity.Set<DangerComponent>();
            
            var label = entity.Set<LabelComponent>();
            
            label.NameObject = GameObject.Find("DangerName");
            label.ValueObject = GameObject.Find("DangerValue");
        }

        public void Run()
        {
            UpdateUi();
        }

        private void UpdateUi()
        {
            var resourceComponent = _resources.Get1.First();
            var label = _label.Get2.First();

            label.ValueObject.GetComponent<Text>().text = resourceComponent.GetDanger().ToString();
        }
    }
}