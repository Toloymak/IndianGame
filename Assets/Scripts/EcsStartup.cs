using System.Collections;
using Systems;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;
        
        [SerializeField] EcsUiEmitter _uiEmitter = null;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new ResourceSystem())
                .Add (new StructureInitSystem())
                .Add(new StructureRunSystem())
                .Add(new BuildingMenuSystem())
                .Add(new ClickManagerSystem())
                .Add(new StabilitySystem())
                .Add(new DangerSystem())
                .Add(new ActionSystem())
                .InjectUi(_uiEmitter)

                
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}