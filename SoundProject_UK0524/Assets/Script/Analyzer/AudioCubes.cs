using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCubes : MonoBehaviour
{

    //����ť�� ������
    public GameObject sampleCubePrefab;

    GameObject[] sampleCube = new GameObject[512];      //���� ť�� �迭
    public float maxScale = 1000;                       //ť���� �ִ� ũ��

    void Start()
    {
        for(int i = 0; i < 512; i++)
        {
            GameObject temp = (GameObject)Instantiate(sampleCubePrefab);            //ť���������� �ν��Ͻ�ȭ
            temp.transform.position = this.transform.position;                      //ť���� �ʱ� ��ġ�� �� ������Ʈ�� ��ġ�� ����
            temp.transform.parent = this.transform;                                 //ť���� �θ� �� ������Ʈ�� ����
            temp.name = "Cube" + i.ToString("000");                                 //ť���� �̸��� "Cube000"�������� ����
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);         //�� ������Ʈ�� ȸ�����Ѽ� ť�긦 ��ġ
            temp.transform.position = Vector3.forward * 100;                        //ť�긦 �������� 100 �̵� ��Ŵ
            sampleCube[i] = temp;                                                   //ť�긦 �迭�� ����
        }
    }

    void Update()
    {
        for(int i = 0; i < 512; i++)
        {
            if (sampleCube[i] != null)
            {//����� ���� �����Ϳ� ����� ť���� Y�� �������� ����
                sampleCube[i].transform.localScale = new Vector3(10, (AudioPeer.samples[i] * maxScale) + 2, 10) * 0.1f;
            }
        }
    }
}
