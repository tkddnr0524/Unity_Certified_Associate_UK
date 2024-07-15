using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float cycleLength = 240f;        //�Ϸ��� ����(��)
    public Light directionalLight;          //���̷��Ǿ� ����Ʈ �Ҵ�

   
    void Update()
    {
        float cycleCompletionPerectage = (Time.time % cycleLength) / cycleLength;       //����Ŭ %����
        float sunAngle = cycleCompletionPerectage * 360.0f;                             //����Ŭ %�� ���� ���� ���

        directionalLight.transform.rotation = Quaternion.Euler(sunAngle, 170, 0);       //���� ������ ����Ʈ�� ������
    }
}
