using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   //UI 라이브러리를 가져온다.
using UnityEngine.SceneManagement;      //Scene 관리 라이브러리를 가져온다.

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;             //싱글턴을 할당할 전역 변수

    public bool isGameOver = false;                 //게임 오버 상태 
    public Text scoreText;                          //점프를 출력할 UI Text
    public GameObject gameOverUI;                   //게임 오버시 활성화할 UI 게임 오브젝트

    private int score = 0;                          //게임 점수 (GameManager에서만 점수를 관리)

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;        //지금 클래스를 지칭한다.
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다.");  //경고 로그 함수 <= LogWarning
            Destroy(gameObject);                    //1개로 유지 시키기 위해 파괴 시킨다.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver && Input.GetMouseButton(0))       //게임 오버 상태에서 마우스 왼쪽 버튼을 클리하면 현재 씬 재시작
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //SceneManager.GetActiveScene().name <- 지금 씬 이름
        }
    }

    //점수를 증가시키는 함수
    public void AddScore(int newScore)
    {
        //게임오버가 아니라면
        if(!isGameOver)
        {
            //점수 증가
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }

    //플레이어 캐릭터 사망 시 게임오버를 실행하는 함수
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);             //SetActive true는 오브젝트를 활성화
    }
}
