using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용자 키보드 입력 감지
//리지드바디를 사용하여 Player 게임 오브젝트 움직이게 설정
public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;               //이동에 사용할 리지드바디 컴포넌트
    public float speed =  8.0f;                     //이동 속력

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();      //오브젝트에 있는 Componet 검색(Rigidbody)해서 가져온다.

    }

    // Update is called once per frame
    void Update()
    {
        //수평추과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력 값과 이동 속렬을 사용해서 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;


        Vector3 vector3 = Vector3.one;
        //Vector3 속도를 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0.0f, zSpeed);


        //리지드바디의 속도의 할당
        playerRigidbody.velocity = newVelocity;

    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
