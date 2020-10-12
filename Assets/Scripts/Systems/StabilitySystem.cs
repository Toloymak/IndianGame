using System;
using System.Collections.Generic;
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


        private const long DefaultStability = 10000;
        
        public void Init()
        {
            var entity = _world.NewEntity();
            var stabilityComponent = entity.Set<StabilityComponent>();
            stabilityComponent.Value = DefaultStability;
            
            var label = entity.Set<LabelComponent>();
            label.NameObject = GameObject.Find("StabilityName");
            label.ValueObject = GameObject.Find("StabilityValue");
        }

        public void Run()
        {
            RecalculateDangerValue();
            UpdateStabilityUi();
        }

        private void UpdateStabilityUi()
        {
            var stability = _stabilityComponents.Get1.First();
            var label = _stabilityComponents.Get2.First();

            label.ValueObject.GetComponent<Text>().text = stability.Value.ToString();
        }
        
        
        private DateTime lastCall;
        private TimeSpan period = new TimeSpan(0, 0, 1);
        
        private void RecalculateDangerValue()
        {
            if (lastCall == default)
                lastCall = DateTime.Now;

            if (DateTime.Now - lastCall > period)
            {
                lastCall = DateTime.Now;
                var resourceComponent = _resources.Get1.First();
                var stabilityComponent = _stabilityComponents.Get1.First();
                stabilityComponent.Value -= resourceComponent.GetDanger();
                stabilityComponent.Value += resourceComponent.GetStability();
            }
        }
    }
}