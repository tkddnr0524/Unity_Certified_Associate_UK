using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDistortionEffect : MonoBehaviour
{
    AudioSource audioSource;                //AudioSource ������Ʈ�� ������ ����

    //����� ���� (0.0���� 1.0 ����)
    public float distortionLevel = 0.5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();          //AudioSource ������Ʈ�� ������

        //AudioDistortionFilter ������Ʈ�� �߰��ϰ� ����
        AudioDistortionFilter distortionFilter = gameObject.AddComponent<AudioDistortionFilter>();
        distortionFilter.distortionLevel = distortionLevel;
    }
}
