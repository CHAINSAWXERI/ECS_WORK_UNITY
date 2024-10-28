using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;
using Voody.UniLeo.Lite;
using BallGameAssemble.Components;
using BallGameAssemble.Systems;
using PersecutionGameAssemble.Systems;

namespace PersecutionGameAssemble
{
    public class ECSStarterPersecution : MonoBehaviour
    {
        private EcsWorld _world;
        private IEcsSystems _systems;

        void Start()
        {
            _world = new();
            _systems = new EcsSystems(_world);
            _systems
                .ConvertScene()
                .Add(new PersecutionSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
            }
            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}