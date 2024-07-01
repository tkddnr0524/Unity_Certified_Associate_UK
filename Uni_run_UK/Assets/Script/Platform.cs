using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������μ� �ʿ��� ������ ���� ��ũ��Ʈ
public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;  //��ֹ� ������Ʈ ��
    private bool stepped = false;   //�÷��̾� ĳ���Ͱ� ��Ҵ°� üũ


    //������Ʈ�� Ȱ��ȭ �� ������ �Ź� ����Ǵ� �޼���
    private void OnEnable()
    {
        //���� ���¸� ����
        stepped = false;            //�ʱ�ȭ ������

        for(int i = 0; i < obstacles.Length; i++)
        {
            //���� ������ ��ֹ��� 1/3 Ȯ���� Ȱ��ȭ
            if(Random.Range(0,3) == 0)   //0, 1, 2
            {
                obstacles[i].SetActive(true);       //0�� ������ ������Ʈ Ȱ��ȭ
            }
            else
            {
                obstacles[i].SetActive(false);      //0�� �ƴҰ�� ��Ȱ��ȭ
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
        //�浹�� ������ �±װ� Player�̰� ������ �÷��̾� Ķ���Ͱ� ���� �ʾҴٸ�
        if(collision.collider.tag == "Player" && !stepped)
        {
            //������ �߰��ϰ�, ���� ���¸� ������ ����
            stepped = true;
            GameManager.Instance.AddScore(1);
        }
    }
    
}
