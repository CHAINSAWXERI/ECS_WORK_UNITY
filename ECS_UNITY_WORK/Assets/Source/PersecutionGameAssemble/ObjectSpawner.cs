using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections.Generic;
using PersecutionGameAssemble.Providers;
using PersecutionGameAssemble.Components;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] public GameObject objectToSpawn; // ������ �������, ������� ����� ��������
    [SerializeField] public GameObject Target;
    [HideInInspector] public int numberOfObjects = 100; // ���������� �������� ��� ������
    [HideInInspector] public Vector3 spawnAreaSize = new Vector3(10, 0, 10); // ������ ������� ������

    private HashSet<Vector3> spawnedPositions = new HashSet<Vector3>(); // ��� �������� ���������� �������

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
                spawnedPositions.Add(randomPosition); // ��������� ������� � ���������
                GameObject ObjectPerSpawn = Instantiate(objectToSpawn, randomPosition, Quaternion.identity); // ������� ������
                var provider = ObjectPerSpawn.GetComponent<PersecutionsProvider>();
                if (provider != null)
                {
                    Persecution persecution = provider.PersecutionData; // �������� ������ � ������������� 
                    persecution.target = Target.transform; // ������������� ���� 
                    provider.PersecutionData = persecution; // ��������� ��������� �������
                }
            }
        }
    }
}
