using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections.Generic;
using PersecutionGameAssemble.Providers;
using PersecutionGameAssemble.Components;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] public GameObject objectToSpawn; // Префаб объекта, который нужно спавнить
    [SerializeField] public GameObject Target;
    [HideInInspector] public int numberOfObjects = 100; // Количество объектов для спавна
    [HideInInspector] public Vector3 spawnAreaSize = new Vector3(10, 0, 10); // Размер области спавна

    private HashSet<Vector3> spawnedPositions = new HashSet<Vector3>(); // Для хранения уникальных позиций

    void Awake()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        while (spawnedPositions.Count < numberOfObjects)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                0,
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );

            if (!spawnedPositions.Contains(randomPosition))
            {
                spawnedPositions.Add(randomPosition); // Добавляем позицию в множество
                GameObject ObjectPerSpawn = Instantiate(objectToSpawn, randomPosition, Quaternion.identity); // Спавним объект
                var provider = ObjectPerSpawn.GetComponent<PersecutionsProvider>();
                if (provider != null)
                {
                    Persecution persecution = provider.PersecutionData; // Получаем данные о преследовании 
                    persecution.target = Target.transform; // Устанавливаем цель 
                    provider.PersecutionData = persecution; // Сохраняем изменения обратно
                }
            }
        }
    }
}
