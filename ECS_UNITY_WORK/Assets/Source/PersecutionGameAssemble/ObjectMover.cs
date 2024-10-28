using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public Transform[] positions; // ������ ������� ��� �����������

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveObject(0); // ����������� � ������ �������
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveObject(1); // ����������� �� ������ �������
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveObject(2); // ����������� � ������ �������
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MoveObject(3); // ����������� � ��������� �������
        }
    }

    void MoveObject(int index)
    {
        if (index >= 0 && index < positions.Length)
        {
            gameObject.transform.position = positions[index].position; // ����������� �������
        }
    }
}