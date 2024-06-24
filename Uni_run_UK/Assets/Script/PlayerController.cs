using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;

    public float jumpForce = 700f;              //���� ���� ��

    //�÷��̾� ĳ������ ���¸� ��Ÿ���� ����
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    //Player ���� ������Ʈ�� ������Ʈ���� �Ҵ��� ����
    Rigidbody2D playerRigidbody;
    Animator animator;
    AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        //���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //���� ����ϰų� ���°��� Ȯ���ϴ� ���� �� ������ ��
        if(isDead)
        {
            //��� �� ó���� �� �̻� ���� ���� �ʰ� ����
            return;
        }

        //���콺 ���� ��ư�� �������� && �ִ� ���� ȸ�� (2)�� ���� ���� �ʾҴٸ�
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            //���� Ƚ�� �߰�
            jumpCount++;
            //���� ������ �ӵ��� ���������� ���� (0,0)�� ����
            playerRigidbody.velocity = Vector2.zero;
            //������ٵ� �������� �� �ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //����� �ҽ� ���
            //playerAudio.Play();

        }
        else if(Input.GetMouseButtonDown(0) && playerRigidbody.velocity.y>0)
        {
            //���콺 ���� ��ư���� ���� ���� ���� && �ӵ��� y���� ������ (���� ��� ��)
            //���� �ӵ��� �������� ����
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        animator.SetBool("Grounded", isGrounded); //�ִϸ������� Grounded �Ķ���͸� isGrounded ������ ����
    }

    void Die()
    {
        //�ִϸ������� Die Ʈ���� �Ķ���͸� ����
        animator.SetTrigger("Die");

        //�ӵ��� ���� (0,0)�� ����
        playerRigidbody.velocity = Vector2.zero;
        //��� ���¸� true�� ����
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dead" && !isDead)
        {
            //�浹�� ������ �±װ� Dead �̸� ���� ������� �ʾҴٸ� Die() �Լ��� ����
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //� �ݶ��̴��� ������� �浹 ǥ���� ������ ���� ������
        if(collision.contacts[0].normal.y > 0.7)
        {
            //isGrounded�� true�� �����ϰ�, ���� ���� Ƚ���� 0���� ����
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //� �ݶ��̴����� ������ ��� isGround�� false�� ����
        isGrounded = false;
    }
}
