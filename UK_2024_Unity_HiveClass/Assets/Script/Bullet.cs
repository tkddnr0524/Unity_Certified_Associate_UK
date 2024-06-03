using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8.0f;              //탄알 이동 속력
    private Rigidbody bulletRigidbody;      //이동에 사용할 리지드바디 컴포넌트

    
    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아서 BulletRigidbody에 할당
        bulletRigidbody = GetComponent<bulletRigidbody>();

        //리지드바디의 속도 = 앞쪽 방향 * 이동 속력 transform.forward 는 z축 앞쪽 방향을 이야기한다.
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3.0f);
    }

   
}
