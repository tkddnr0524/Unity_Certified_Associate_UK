using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public static int count = 0; //���α׷��� �����ϴ� ���� �� ��
    public int AllCount = 0;
    private void Awake()
    {
        count++;
    }

    public void Update()
    {
        AllCount = count;
    }

    public void OnDestroy()     //�ı� �� �� ���� ����
    {
        count--;
    }
}
