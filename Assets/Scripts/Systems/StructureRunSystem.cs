using Client.Enums;
using Components;
using Extensions;
using Leopotam.Ecs;
using ResourceCollections;
using UnityEngine;

namespace Systems
{
    public class StructureRunSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        
        private EcsFilter<StructureComponent, ClickableComponent> _filter = null;

        public void Run()
        {
            DetectClick();
            DrawBuildingType();
        }

        private void DrawBuildingType()
        {
            foreach (var id in _filter)
            {
                var structureComponent = _filter.Get1[id];

                if (structureComponent.Status == StructureStatus.ConstructionProcess)
                {
                    Debug.Log("Rebuild!");

                    var oldStructure = structureComponent.Object;
                    
                    // todo: add different pic for types
                    var emptyStructurePrefab = Resources.Load(BuildingPrefabs.NormalStructure);
                    var newStructure = (GameObject) Object.Instantiate(emptyStructurePrefab);

                    newStructure.transform.position = oldStructure.transform.position;
                    structureComponent.Object = newStructure;
                    structureComponent.Status = StructureStatus.Normal;
                    
                    Object.Destroy(oldStructure);
                    
                }
            }
        }

        private void DetectClick()
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