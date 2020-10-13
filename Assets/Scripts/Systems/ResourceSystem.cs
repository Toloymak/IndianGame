using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    public class ResourceSystem : IEcsInitSystem, IEcsRunSystem
    {
        readonly EcsWorld _world = null;
        private EcsFilter<ResourceComponent> _resources = null;
        
        public void Init()
        {
            var entity = _world.NewEntity();
            var resources = entity.Set<ResourceComponent>();
            resources.EffectItems = _defaultItems;
            resources.Gold = 100;
            resources.Food = 1000;
            CreateDefaultPersons(resources);
            
            resources.FoodLabel = new LabelComponent()
            {
                NameObject = GameObject.Find("FoodName"),
                ValueObject = GameObject.Find("FoodValue"),
            };
            resources.GoldLabel = new LabelComponent()
            {
                NameObject = GameObject.Find("GoldName"),
                ValueObject = GameObject.Find("GoldValue"),
            };
            resources.MaterialsLabel = new LabelComponent()
            {
                NameObject = GameObject.Find("MaterialsName"),
                ValueObject = GameObject.Find("MaterialsValue"),
            };
            resources.PersonLabel = new LabelComponent()
            {
                NameObject = GameObject.Find("PersonName"),
                ValueObject = GameObject.Find("PersonValue"),
            };
            resources.EffectLabel = new LabelComponent()
            {
                NameObject = GameObject.Find("EffectName"),
                ValueObject = GameObject.Find("EffectValue"),
            };
        }

        private void CreateDefaultPersons(ResourceComponent resourceComponent)
        {
            for (var i = 0; i < 10; i++)
            {
                resourceComponent.Persons.Add(new PersonModel{Power = 10, Supplementation = 50});
            }
        }

        private readonly IList<EffectItem> _defaultItems = new List<EffectItem>()
        {
            new EffectItem("Alien lands")
            {
                Danger = 5,
            },
            new EffectItem("Winter")
            {
                Danger = 0,
            },
            new EffectItem("Fresh meat")
            {
                Stability = 3,
            },
            new EffectItem("Our developers are awesome")
            {
                Stability = 10
            }
        };

        public void Run()
        {
            var resourceComponent = _resources.Get1.First();
            
            resourceComponent.FoodLabel.ValueObject.GetComponent<Text>().text = 
                resourceComponent.Food.ToString(CultureInfo.InvariantCulture);
            
            resourceComponent.GoldLabel.ValueObject.GetComponent<Text>().text = 
                resourceComponent.Gold.ToString(CultureInfo.InvariantCulture);
            
            resourceComponent.MaterialsLabel.ValueObject.GetComponent<Text>().text = 
                resourceComponent.Materials.ToString(CultureInfo.InvariantCulture);
            
            resourceComponent.PersonLabel.ValueObject.GetComponent<Text>().text = 
                resourceComponent.Persons.Count.ToString(CultureInfo.InvariantCulture);

            resourceComponent.EffectLabel.ValueObject.GetComponent<Text>().text =
                string.Join(";\n",
                    resourceComponent.EffectItems.Select(x => $"{x.Name}({x.Danger}D&{x.Stability}S)"));
        }
    }
}