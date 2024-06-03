using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8.0f;              //ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody;      //�̵��� ����� ������ٵ� ������Ʈ

    
    void Start()
    {
        //���� ������Ʈ���� Rigidbody ������Ʈ�� ã�Ƽ� BulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<bulletRigidbody>();

        //������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ� transform.forward �� z�� ���� ������ �̾߱��Ѵ�.
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3.0f);
    }

   
}
