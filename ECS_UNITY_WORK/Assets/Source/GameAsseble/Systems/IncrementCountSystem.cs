using GameAsseble.Components;
using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameAsseble.Systems
{
    public class IncrementCountSystem : IEcsInitSystem, IEcsRunSystem
    {
        public EcsPool<FloatCounter> FloatCounters;
        public EcsFilter FloatCounterFilter;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            FloatCounters = world.GetPool<FloatCounter>();
            FloatCounterFilter = world.Filter<FloatCounter>().End(); //.Exc<T>;
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in FloatCounterFilter)
            {
                ref FloatCounter floatCounter = ref FloatCounters.Get(entity);
                floatCounter.Value++;
                Debug.Log(floatCounter.Value);
            }
        }
    }
}