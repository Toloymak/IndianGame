using System;
using System.Linq;
using Client.Enums;
using Components;
using Enums;
using Extensions;
using Helpers;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Actions;
using Leopotam.Ecs.Ui.Components;
using Leopotam.Ecs.Ui.Systems;
using ResourceCollections;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Systems
{
    public class BuildingMenuSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsUiEmitter _uiEmitter = null;

        private readonly EcsFilter<StructureComponent, ClickableComponent> _filter = null;
        private readonly EcsFilter<BuildMenuComponent> _buildMenuComponent = null;
        private readonly EcsFilter<EcsUiClickEvent> _clickEvents = null;
        private readonly EcsFilter<StabilityComponent> _stabilityComponents = null;
        private readonly EcsFilter<ResourceComponent> _sourceComponent = null;
        
        public void Init()
        {
            var buildCanvas = _world.NewEntity();
            var menu = buildCanvas.Set<BuildMenuComponent>();
            menu.Menu = GameObject.Find("BuildingCanvas");
            menu.Menu.SetActive(false);

            FillBuildMenu(menu);
        }

        public void Run()
        {
            OpenMenu();
            
            var buildMenuComponent = _buildMenuComponent.Get1.First();
            if (buildMenuComponent.Menu.activeSelf)
            {
                CloseMenu();
                Build();
            }
        }

        private void Build()
        {
            for (var i = 0; i < _clickEvents.GetEntitiesCount(); i++)
            {
                var clickEvent = _clickEvents.Get1[i];

                foreach (var buildItemType in EnumHelper.GetValues<BuildItemType>())
                {
                    if (buildItemType.ToString() == clickEvent.WidgetName)
                    {
                        var buildMenu = _buildMenuComponent.Get1.First();
                        buildMenu.StructureComponent.Status = StructureStatus.ConstructionProcess;
                        buildMenu.StructureComponent.Type = buildItemType;
                        
                        _sourceComponent.Get1.First().ResourceItems.Add(buildItemType.GetResources());
                        
                        buildMenu.Menu.SetActive(false);

                        return;
                    }
                }
            }
        }

        private static void FillBuildMenu(BuildMenuComponent menu)
        {
            var itemList = menu.Menu.transform.Find("List");

            var buildItem = Resources.Load(BuildingPrefabs.BuildItem);

            foreach (var item in EnumHelper.GetValues<BuildItemType>())
            {
                var gameObjectItem = (GameObject) Object.Instantiate(buildItem, itemList.transform);
                gameObjectItem.GetComponent<Text>().text = item.ToString();

                EcsUiActionBase.AddAction<EcsUiClickAction>(gameObjectItem, item.ToString());
            }
        }

        private void OpenMenu()
        {
            for (var i = 0; i < _filter.GetEntitiesCount(); i++)
            {
                var clickableComponent = _filter.Get2[i];

                if (clickableComponent.IsClicked && !clickableComponent.IsActionCompleted)
                {
                    var buildMenuComponent = _buildMenuComponent.Get1.First();
                    if (!buildMenuComponent.Menu.activeSelf)
                    {
                        buildMenuComponent.StructureComponent = _filter.Get1[i];
                        buildMenuComponent.Menu.SetActive(true);
                    }

                    clickableComponent.IsActionCompleted = true;
                }
            }
        }

        private void CloseMenu()
        {
            for (var i = 0; i < _clickEvents.GetEntitiesCount(); i++)
            {
                var clickEvent = _clickEvents.Get1[i];
                if (clickEvent.WidgetName == "CloseBuildMenu")
                {
                    var buildMenuComponent = _buildMenuComponent.Get1.First();
                    buildMenuComponent.Menu.SetActive(false);
                }
            }
        }
    }
}