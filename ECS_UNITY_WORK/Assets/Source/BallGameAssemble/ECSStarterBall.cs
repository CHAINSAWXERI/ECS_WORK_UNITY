using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.EcsLite;
using Voody.UniLeo.Lite;
using BallGameAssemble.Components;
using BallGameAssemble.Systems;

namespace BallGameAssemble
{
    public class ECSStarterBall : MonoBehaviour
    {
        private EcsWorld _world;
        private IEcsSystems _systems;

        void Start()
        {
            _world = new();
            _systems = new EcsSystems(_world);
            _systems
                .ConvertScene()
                .Add(new BallMovementSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .Init();
            CreateBalls(1000);
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

        private void CreateBalls(int count)
        {
            for (int i = 0; i < count; i++)
            {
                // Создаем новую сущность
                var entity = _world.NewEntity();

                // Получаем пул компонентов BallMovement
                var ballMovementPool = _world.GetPool<BallMovement>();

                // Инициализируем BallMovement
                ref var ballMovement = ref ballMovementPool.Add(entity);
                ballMovement.Speed = Random.Range(1f, 5f); // Пример: случайная скорость
                ballMovement.Amplitude = Random.Range(0.5f, 2f); // Пример: случайная амплитуда
                ballMovement.Frequency = Random.Range(1f, 3f); // Пример: случайная частота
                ballMovement.Time = 0f;

                // Создаем новый GameObject для мяча и присваиваем его трансформ
                GameObject ballObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                ballObject.transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)); // Случайная позиция

                ballMovement.BallTransform = ballObject.transform; // Присваиваем трансформ мяча
            }
        }
    }
}