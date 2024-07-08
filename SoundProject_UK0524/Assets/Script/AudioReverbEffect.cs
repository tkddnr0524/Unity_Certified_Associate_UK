using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioReverbEffect : MonoBehaviour
{

    AudioSource audioSource;                //AudioSource 컴포넌트를 저장할 변수

    //리버브 프리셋 (다양한 환경에 대한 사전 설정)
    public AudioReverbPreset reverbPreset = AudioReverbPreset.Cave;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();          //AudioSource 컴포넌트를 가져옴

        //AudioRverbFilter 컴포넌트를 추가하고 설정
        AudioReverbFilter reverbFilter = gameObject.AddComponent<AudioReverbFilter>();
        reverbFilter.reverbPreset = reverbPreset;
    }

   
}
