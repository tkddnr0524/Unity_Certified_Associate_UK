using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                           //UI ���� ���̺귯��
using UnityEngine.SceneManagement;              //Scene ���� ���̺귯��

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;             //���� ���� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ(TextUI)
    public Text timeText;                       //���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText;                     //�ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime;                  //���� �ð�
    private bool isGameover;                    //���ӿ��� ����

    private void Start()
    {
        //���� �ð��� ���� ���� ���¸� �ʱ�ȭ
        surviveTime = 0;
        isGameover = false;
    }


    void Update()
    {
        //���� ������ �ƴ� ����
        if(!isGameover)
        {
            //���� �ð� ����
            surviveTime += Time.deltaTime;
            //������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time : " + (int)surviveTime;           //float -> int ��ȯ ��Ű�� �Ҽ����� �������� ����
        }
        else
        {
            //���ӿ��� ���¿��� RŰ�� ���� ���
            if(Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene ���� �ε�
                SceneManager.LoadScene("MyGameScene");          //���� �������� ���� ��Ͽ� ���
            }

            if(Input.GetKeyDown(KeyCode.Escape))                    //Esc Ű�� ������
            {
                Application.Quit();                                 //������ ���� �ȴ�.
            }
        }
    }

    public void EndGame()
    {
        //���� ���¸� ���� ���� ���·� ��ȯ
        isGameover = true;
        
        //���� ���� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        //BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //���� ������ �ְ� ��Ϻ��� ���� �ð��� �� ũ�ٸ�
        if(surviveTime > bestTime)
        {
            //�ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;

            //����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //�ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��Ͽ� ǥ��
        recordText.text = "Best Time : " + (int)bestTime;
    }

}
