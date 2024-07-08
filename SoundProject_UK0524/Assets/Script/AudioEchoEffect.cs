using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioEchoEffect : MonoBehaviour
{
    AudioSource audioSource;                //AudioSource 컴포넌트를 저장할 변수
    public float delay = 500.0f;            //에코 딜리에 시간(밀리초[1000단위])
    public float delayRatio = 0.5f;         //에코 감쇠 비율
    void Start()
    {
        audioSource = GetComponent<AudioSource>();          //AudioSource 컴포넌트를 가져옴

        //AudioEchoFilter 컴포넌트를 추가하고 설정
        AudioEchoFilter echoFilter = gameObject.AddComponent<AudioEchoFilter>();
        echoFilter.delay = delay;
        echoFilter.decayRatio = delayRatio;
    }
}
