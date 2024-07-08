using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioLowPassEffect : MonoBehaviour
{
    AudioSource audioSource;                //AudioSource ������Ʈ�� ������ ����

    //�ƿ��� ���ļ� (Hz)
    public float cutoffFrequency = 500.0f;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();          //AudioSource ������Ʈ�� ������

        //AudioHighPassFilter ������Ʈ�� �߰��ϰ� ����
        AudioLowPassFilter lowPassFilter = gameObject.AddComponent<AudioLowPassFilter>();
        lowPassFilter.cutoffFrequency = cutoffFrequency;
    }
}
