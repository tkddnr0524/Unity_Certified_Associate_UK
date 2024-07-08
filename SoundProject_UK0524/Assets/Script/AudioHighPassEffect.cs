using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioHighPassEffect : MonoBehaviour
{

    AudioSource audioSource;                //AudioSource 컴포넌트를 저장할 변수

    //컷오프 주파수 (Hz)
    public float cutoffFrequency = 500.0f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();          //AudioSource 컴포넌트를 가져옴

        //AudioHighPassFilter 컴포넌트를 추가하고 설정
        AudioHighPassFilter highPassFilter = gameObject.AddComponent<AudioHighPassFilter>();
        highPassFilter.cutoffFrequency = cutoffFrequency;
    }
}
