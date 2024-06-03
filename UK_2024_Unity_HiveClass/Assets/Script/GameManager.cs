using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;                                             //�÷��̾� ������
    public GameObject playingPlayer;                                            //�÷��� ���� �÷��̾� ������Ʈ
    public float Timer;                                                         //���� �ð� �÷���
    public Text uiTextTimer;                                                    //UI Timer ����

    void SpawnPlayer()                                                                                  //�÷��̾� ���� �Լ�
    {
        playingPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);                 //�÷��̾� ������ ����
        Timer = 0.0f;                                                                                   //Ÿ�̸� �ʱ�ȭ
    }

    private void Start()
    {
        SpawnPlayer();
    }
    // Update is called once per frame
    void Update()
    {
        uiTextTimer.text = Timer.ToString("F1");                //�Ҽ��� 1��° �ڸ������� ToString�� (float) ���� (string) ������ ����
        if (playingPlayer != null)
            Timer += Time.deltaTime;                            //����ִ� ���� �ð� ����
        
        if(Input.GetKeyDown(KeyCode.Space))                 //�����̽� ���� ����
        {
            if(playingPlayer == null)                       //�÷��̾ ���� ��� �Լ� ȣ��� ����
            {
                SpawnPlayer();
            }
        }
    }
}
