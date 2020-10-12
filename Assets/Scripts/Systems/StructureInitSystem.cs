using System;
using Client.Enums;
using Components;
using Leopotam.Ecs;
using ResourceCollections;
using UnityEngine;
using Object = UnityEngine.Object;

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
            entity.Set<ClickableComponent>();
            
            var structureComponent = entity.Set<StructureComponent>();
            structureComponent.Status = StructureStatus.Empty;
            structureComponent.Object = Object.Instantiate(emptyStructurePrefab) as GameObject;
            structureComponent.Id = Guid.NewGuid();

            if (!(structureComponent.Object is null))
                structureComponent.Object.transform.position = structureTemplate.transform.position;
        }
    }
}