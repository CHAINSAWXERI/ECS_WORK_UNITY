using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public Transform[] positions; // Массив позиций для перемещения

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveObject(0); // Перемещение в первую позицию
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveObject(1); // Перемещение во вторую позицию
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveObject(2); // Перемещение в третью позицию
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MoveObject(3); // Перемещение в четвертую позицию
        }
    }

    void MoveObject(int index)
    {
        if (index >= 0 && index < positions.Length)
        {
            gameObject.transform.position = positions[index].position; // Перемещение объекта
        }
    }
}