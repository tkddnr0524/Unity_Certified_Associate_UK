using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public int gold = 1000;                    // int (정수) gold(변수 이름) 선언하고 1000값을 넣어줌
    public float itemWeight = 1.34f;           // float (실수) itemWeight(변수 이름) 선언하고 1.34값을 넣어줌
    public bool isStoreOpen = true;            // bool (참/거짓) isStoreOpen(변수 이름) 선언하고 true값을 넣어줌
    public string itemName = "포션";           // string (문자열) itemName(변수 이름) 선언하고 포션(문자열)을 넣어줌

    public int HP = 100;                        //체력값 선언
    public float MoveDistance = 1.0f;           //이동 값 선언

    public void Move()                          //이동 함수 선언
    {
        HP = HP - 10;                           //체력 10 감소
        MoveDistance = MoveDistance + 1;        //이동 위치 1증가
    }

    public void Move(int hp , int distance)                          //이동 함수 선언 overrid
    {
        HP = HP - hp;                           //함수 hp 인수 받은 만큼 감소
        MoveDistance = MoveDistance + distance; //함수 distance 인수 받은 만큼 이동 
    }

    public int RandomNumber()                   //Return 값이 있는 함수
    {
        int Number = 0;
        Number = Random.Range(0, 10);           // 0 ~ 9 값의 랜덤 값을 가져온다.

        return Number;
    }

    // Start is called before the first frame update
    void Start()
    {
         Debug.Log("Gold : " + gold + " itemWeight : " + itemWeight + " isStoreOpen : " + isStoreOpen + " itemName : " + itemName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))             //1번 버튼을 눌렀을때 (Input 클래스로 입력 감지)
        {
            Debug.Log(KeyCode.Alpha1.ToString() + " 버튼 눌림 ");
            Move();                                //Move 함수 사용
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))             //2번 버튼을 눌렀을때 (Input 클래스로 입력 감지)
        {
            Debug.Log(KeyCode.Alpha2.ToString() + " 버튼 눌림 ");
            Move(30, 1);                                     //Move 함수 사용
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))             //3번 버튼을 눌렀을때 (Input 클래스로 입력 감지)
        {
            Debug.Log(KeyCode.Alpha3.ToString() + " 버튼 눌림 ");
            Move(15, 2);                                     //Move 함수 사용
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))             //4번 버튼을 눌렀을때 (Input 클래스로 입력 감지)
        {
            int GetRandNumber = 0;                          //GetRandNumber(변수 선언)
            GetRandNumber = RandomNumber();                //변수에 INT 함수 값을 Return 받아서 저장
            Debug.Log("GetRangnumber : " + GetRandNumber); //해당 값을 콘솔로그 창에 보여준다.        }
        }
    }
}
