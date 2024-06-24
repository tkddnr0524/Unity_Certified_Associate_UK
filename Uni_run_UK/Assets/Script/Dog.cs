using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public static int count = 0; //프로그램에 존재하는 개의 총 수
    public int AllCount = 0;
    private void Awake()
    {
        count++;
    }

    public void Update()
    {
        AllCount = count;
    }

    public void OnDestroy()     //파괴 될 때 숫자 제거
    {
        count--;
    }
}
