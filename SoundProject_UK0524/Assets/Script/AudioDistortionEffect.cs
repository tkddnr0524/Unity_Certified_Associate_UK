using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDistortionEffect : MonoBehaviour
{
    AudioSource audioSource;                //AudioSource 컴포넌트를 저장할 변수

    //디스토션 레벨 (0.0에서 1.0 사이)
    public float distortionLevel = 0.5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();          //AudioSource 컴포넌트를 가져옴

        //AudioDistortionFilter 컴포넌트를 추가하고 설정
        AudioDistortionFilter distortionFilter = gameObject.AddComponent<AudioDistortionFilter>();
        distortionFilter.distortionLevel = distortionLevel;
    }
}
