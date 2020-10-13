using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Components;
using Leopotam.Ecs;
using ResourceCollections;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Systems
{
    public class ActionSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        
        private readonly EcsFilter<ActionComponent, LabelComponent> _actions = null;
        private readonly EcsFilter<ResourceComponent> _resources = null;



        public void Init()
        {
            var entity = _world.NewEntity();
            entity.Set<ActionComponent>();
            
            var labelComponent = entity.Set<LabelComponent>();
            labelComponent.ValueObject = GameObject.Find("ActionList");
        }
        
        private TimeSpan period = new TimeSpan(0, 0, 10);
        private Random rnd = new Random();
        
        public void Run()
        {
            var actions = _actions.Get1.First();

            if (actions.ActionModels.Count == 0 
                || DateTime.Now - actions.ActionModels.OrderByDescending(x => x.DateTime).FirstOrDefault()?.DateTime > period)
            {
                var newAction = ActionCollection.ActionModels[rnd.Next(0, ActionCollection.ActionModels.Length - 1)];
                newAction.DateTime = DateTime.Now;
                actions.ActionModels.Add(newAction);

                var resourceComponent = _resources.Get1.First();
                resourceComponent.Food += newAction.FoodEffect;
                resourceComponent.Gold += newAction.GoldEffect;
                resourceComponent.Materials += newAction.MaterialEffect;

                if (newAction.MoraleEffect != 0)
                {
                    resourceComponent.EffectItems.Add(new EffectItem(newAction.Name)
                    {
                         Stability = (int)newAction.MoraleEffect
                    });
                }
            }
            
            _actions.Get2.First().ValueObject.GetComponent<Text>().text =
                string.Join("\n",
                    actions
                        .ActionModels
                        .OrderByDescending(x => x.DateTime)
                        .Select(x => $"{x.DateTime.ToString(CultureInfo.InvariantCulture)} | {x.Name} - " +
                                     $"{x.Description}. Effect: " +
                                     $"{x.FoodEffect}F, {x.GoldEffect}G, {x.MaterialEffect}M, {x.MoraleEffect}S " +
                                     $"{x.NeedReactionString}"));
        }
    }
}