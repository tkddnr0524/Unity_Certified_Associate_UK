using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    //게임 오브젝트를 계속 왼쪽으로 움직이는 스크립트
    public float speed = 10.0f; //이동 속도
    

    void Start()
    {
        Dog.count = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameOver)       //게임 오버가 아니라면 
        {
            //초당 speed 속도로 왼쪽으로 평행이동
            transform.Translate(Vector3.left * speed * Time.deltaTime); //게임 오브젝트를 초당 (-speed , 0,0) 만큼 이동
        }
    }
}
