using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioHighPassEffect : MonoBehaviour
{

    AudioSource audioSource;                //AudioSource ������Ʈ�� ������ ����

    //�ƿ��� ���ļ� (Hz)
    public float cutoffFrequency = 500.0f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();          //AudioSource ������Ʈ�� ������

        //AudioHighPassFilter ������Ʈ�� �߰��ϰ� ����
        AudioHighPassFilter highPassFilter = gameObject.AddComponent<AudioHighPassFilter>();
        highPassFilter.cutoffFrequency = cutoffFrequency;
    }
}
