using BallGameAssemble.Components;
using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallGameAssemble.Systems
{
    public class BallMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        public EcsPool<BallMovement> BallMovements;
        public EcsFilter BallFilter;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            BallMovements = world.GetPool<BallMovement>();
            BallFilter = world.Filter<BallMovement>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in BallFilter)
            {
                ref var ballMovement = ref BallMovements.Get(entity);

                ballMovement.Time += Time.deltaTime;

                float xOffset = Mathf.Sin(ballMovement.Time * ballMovement.Frequency) * ballMovement.Amplitude;
            }
        }
    }
}
