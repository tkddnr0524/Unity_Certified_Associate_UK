using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public int gold = 1000;                    // int (����) gold(���� �̸�) �����ϰ� 1000���� �־���
    public float itemWeight = 1.34f;           // float (�Ǽ�) itemWeight(���� �̸�) �����ϰ� 1.34���� �־���
    public bool isStoreOpen = true;            // bool (��/����) isStoreOpen(���� �̸�) �����ϰ� true���� �־���
    public string itemName = "����";           // string (���ڿ�) itemName(���� �̸�) �����ϰ� ����(���ڿ�)�� �־���

    public int HP = 100;                        //ü�°� ����
    public float MoveDistance = 1.0f;           //�̵� �� ����

    public void Move()                          //�̵� �Լ� ����
    {
        HP = HP - 10;                           //ü�� 10 ����
        MoveDistance = MoveDistance + 1;        //�̵� ��ġ 1����
    }

    public void Move(int hp , int distance)                          //�̵� �Լ� ���� overrid
    {
        HP = HP - hp;                           //�Լ� hp �μ� ���� ��ŭ ����
        MoveDistance = MoveDistance + distance; //�Լ� distance �μ� ���� ��ŭ �̵� 
    }

    public int RandomNumber()                   //Return ���� �ִ� �Լ�
    {
        int Number = 0;
        Number = Random.Range(0, 10);           // 0 ~ 9 ���� ���� ���� �����´�.

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
        if (Input.GetKeyDown(KeyCode.Alpha1))             //1�� ��ư�� �������� (Input Ŭ������ �Է� ����)
        {
            Debug.Log(KeyCode.Alpha1.ToString() + " ��ư ���� ");
            Move();                                //Move �Լ� ���
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))             //2�� ��ư�� �������� (Input Ŭ������ �Է� ����)
        {
            Debug.Log(KeyCode.Alpha2.ToString() + " ��ư ���� ");
            Move(30, 1);                                     //Move �Լ� ���
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))             //3�� ��ư�� �������� (Input Ŭ������ �Է� ����)
        {
            Debug.Log(KeyCode.Alpha3.ToString() + " ��ư ���� ");
            Move(15, 2);                                     //Move �Լ� ���
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))             //4�� ��ư�� �������� (Input Ŭ������ �Է� ����)
        {
            int GetRandNumber = 0;                          //GetRandNumber(���� ����)
            GetRandNumber = RandomNumber();                //������ INT �Լ� ���� Return �޾Ƽ� ����
            Debug.Log("GetRangnumber : " + GetRandNumber); //�ش� ���� �ַܼα� â�� �����ش�.        }
        }
    }
}
