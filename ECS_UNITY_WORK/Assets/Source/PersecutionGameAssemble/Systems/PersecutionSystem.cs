using Leopotam.EcsLite;
using PersecutionGameAssemble.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace PersecutionGameAssemble.Systems
{
    public class PersecutionSystem : IEcsInitSystem, IEcsRunSystem
    {
        public EcsPool<Persecution> Persecutions;
        public EcsFilter PersecutionFilter;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            Persecutions = world.GetPool<Persecution>();
            PersecutionFilter = world.Filter<Persecution>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in PersecutionFilter)
            {
                ref var persecutions = ref Persecutions.Get(entity);
                //
                if (persecutions.target != null)
                {
                    Debug.Log("000");
                    //persecutions.OurTransform = persecutions.transform;
                    Vector3 direction = persecutions.target.position - persecutions.OurTransform.position;
                    direction.Normalize();

                    persecutions.OurTransform.position += direction * persecutions.speed * Time.deltaTime;
                }
                //
            }
        }
    }
}