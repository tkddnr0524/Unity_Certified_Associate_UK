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
        bulletRigidbody = GetComponent<Rigidbody>();

        //������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ� transform.forward �� z�� ���� ������ �̾߱��Ѵ�.
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3.0f);
    }

    //Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    private void OnTriggerEnter(Collider other)         //�浹�� ���� ������Ʈ �ݶ��̴�(other)
    {   
        //�浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if(other.tag == "Player")
        {
            //���� ���� ������Ʈ���� PlayerController ������Ʈ�� �����´�.
            PlayerController playerController = other.GetComponent<PlayerController>();


            //�������� ���� PlayerController ������Ʈ�� �������� �� �����ߴٸ�
            if(playerController != null)
            {
                //���� PlayerController ������Ʈ�� �޼��� ����
                playerController.Die();
            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //�浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        //���� ���� ������Ʈ���� PlayerController ������Ʈ�� �����´�.
    //        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();


    //        //�������� ���� PlayerController ������Ʈ�� �������� �� �����ߴٸ�
    //        if (playerController != null)
    //        {
    //            //���� PlayerController ������Ʈ�� �޼��� ����
    //            playerController.Die();
    //        }
    //    }
    //}
}
