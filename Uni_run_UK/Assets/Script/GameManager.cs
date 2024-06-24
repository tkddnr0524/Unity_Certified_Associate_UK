using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   //UI ���̺귯���� �����´�.
using UnityEngine.SceneManagement;      //Scene ���� ���̺귯���� �����´�.

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;             //�̱����� �Ҵ��� ���� ����

    public bool isGameOver = false;                 //���� ���� ���� 
    public Text scoreText;                          //������ ����� UI Text
    public GameObject gameOverUI;                   //���� ������ Ȱ��ȭ�� UI ���� ������Ʈ

    private int score = 0;                          //���� ���� (GameManager������ ������ ����)

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;        //���� Ŭ������ ��Ī�Ѵ�.
        }
        else
        {
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�.");  //��� �α� �Լ� <= LogWarning
            Destroy(gameObject);                    //1���� ���� ��Ű�� ���� �ı� ��Ų��.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver && Input.GetMouseButton(0))       //���� ���� ���¿��� ���콺 ���� ��ư�� Ŭ���ϸ� ���� �� �����
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //SceneManager.GetActiveScene().name <- ���� �� �̸�
        }
    }

    //������ ������Ű�� �Լ�
    public void AddScore(int newScore)
    {
        //���ӿ����� �ƴ϶��
        if(!isGameOver)
        {
            //���� ����
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }

    //�÷��̾� ĳ���� ��� �� ���ӿ����� �����ϴ� �Լ�
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);             //SetActive true�� ������Ʈ�� Ȱ��ȭ
    }
}
