using Client.Enums;
using Components;
using Enums;
using Leopotam.Ecs;
using ResourceCollections;
using UnityEngine;

namespace Systems {
    sealed class StructureInitSystem : IEcsInitSystem {
        readonly EcsWorld _world = null;
        
        public void Init ()
        {
            var structures = GameObject.FindGameObjectsWithTag("Structure");
            
            foreach (var structure in structures)
            {
                CreateEmptyStructure(structure);
                Object.Destroy(structure);
            }
            
            Debug.Log("All structures have been built");
        }

        private void CreateEmptyStructure(GameObject structureTemplate)
        {
            var emptyStructurePrefab = Resources.Load(BuildingPrefabs.EmptyStructure);

            var entity = _world.NewEntity();
            var clickableComponent = entity.Set<ClickableComponent>();
            clickableComponent.ActionType = ActionType.OpenBuildMenu;
            
            var structureComponent = entity.Set<StructureComponent>();
            structureComponent.Status = StructureStatus.Empty;
            structureComponent.Object = Object.Instantiate(emptyStructurePrefab) as GameObject;

            if (!(structureComponent.Object is null))
                structureComponent.Object.transform.position = structureTemplate.transform.position;
        }
    }
}