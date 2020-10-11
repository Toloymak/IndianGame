using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace Systems
{
    public class DangerSystem : IEcsInitSystem, IEcsRunSystem
    {
        readonly EcsWorld _world = null;
        
        private EcsFilter<DangerComponent, LabelComponent> _label = null;

        public void Init()
        {
            var entity = _world.NewEntity();
            var dangerComponent = entity.Set<DangerComponent>();
            var label = entity.Set<LabelComponent>();

            dangerComponent.Value = 0;
            dangerComponent.Items = new List<DangerItem>();
            dangerComponent.Items.Add(new DangerItem("Alien lands", 1));
                
            label.NameObject = GameObject.Find("DangerName");
            label.ValueObject = GameObject.Find("DangerValue");
        }

        public void Run()
        {
            UpdateUi();
        }

        private void UpdateUi()
        {
            var danger = _label.Get1.First();
            var label = _label.Get2.First();

            label.ValueObject.GetComponent<Text>().text = danger.Value.ToString();
        }
    }
}