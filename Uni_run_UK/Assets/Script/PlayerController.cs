using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;

    public float jumpForce = 700f;              //점프 힘의 값

    //플레이어 캐릭터의 상태를 나타내는 변수
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    //Player 게임 오브젝트의 컴포넌트들을 할당할 변수
    Rigidbody2D playerRigidbody;
    Animator animator;
    AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트로부터 사용할 컴포넌트들을 가져와 변수에 할당
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //보통 사망하거나 상태값을 확인하는 것이 맨 앞으로 옴
        if(isDead)
        {
            //사망 시 처리를 더 이상 진행 하지 않고 종료
            return;
        }

        //마우스 왼쪽 버튼을 눌렀으며 && 최대 점프 회수 (2)에 도달 하지 않았다면
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            //점프 횟수 추가
            jumpCount++;
            //점프 직전에 속도를 순간적으로 제로 (0,0)로 변경
            playerRigidbody.velocity = Vector2.zero;
            //리지드바디에 위쪽으로 힘 주기
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //오디오 소스 재생
            //playerAudio.Play();

        }
        else if(Input.GetMouseButtonDown(0) && playerRigidbody.velocity.y>0)
        {
            //마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y값이 양수라면 (위로 상승 중)
            //현재 속도를 절반으로 변경
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        animator.SetBool("Grounded", isGrounded); //애니메이터의 Grounded 파라미터를 isGrounded 값으로 갱신
    }

    void Die()
    {
        //애니메이터의 Die 트리거 파라미터를 셋팅
        animator.SetTrigger("Die");

        //속도를 제로 (0,0)로 변경
        playerRigidbody.velocity = Vector2.zero;
        //사망 상태를 true로 변경
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dead" && !isDead)
        {
            //충돌한 상대방의 태그가 Dead 이며 아직 사망하지 않았다면 Die() 함수를 실행
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //어떤 콜라이더와 닿았으며 충돌 표면이 위쪽을 보고 있으면
        if(collision.contacts[0].normal.y > 0.7)
        {
            //isGrounded를 true로 변경하고, 누적 점프 횟수를 0으로 리셋
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //어떤 콜라이더에서 떼어진 경우 isGround를 false로 변경
        isGrounded = false;
    }
}
