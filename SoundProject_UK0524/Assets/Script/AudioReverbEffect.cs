using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioReverbEffect : MonoBehaviour
{

    AudioSource audioSource;                //AudioSource ������Ʈ�� ������ ����

    //������ ������ (�پ��� ȯ�濡 ���� ���� ����)
    public AudioReverbPreset reverbPreset = AudioReverbPreset.Cave;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();          //AudioSource ������Ʈ�� ������

        //AudioRverbFilter ������Ʈ�� �߰��ϰ� ����
        AudioReverbFilter reverbFilter = gameObject.AddComponent<AudioReverbFilter>();
        reverbFilter.reverbPreset = reverbPreset;
    }

   
}
