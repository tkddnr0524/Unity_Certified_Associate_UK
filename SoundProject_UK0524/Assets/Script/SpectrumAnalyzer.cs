using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpectrumAnalyzer : MonoBehaviour
{
    AudioSource audioSource;                //AudioSource 컴포넌트를 저장할 변수
    public float[] samples = new float[512];     //스펙트럼 데잍를 저장할 배열
    public FFTWindow fftWindow = FFTWindow.Blackman;        //사용할 파형

    //Blackman : 신호의 양 끝이 0이 되도록 가중치가 적용되며, 간섭을 많이 줄이지만 주파수 분해능력 더욱 낮아질 수 있습니다.
    //Hamming : 신호의 양 끝이 0이 아니며, 간섭을 줄이기 위한 가중치가 적용됩니다.
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();          //AudioSource 컴포넌트를 가져옴
    }

   
    void Update()
    {
        //스펙트럼 데이터 가져옴
        audioSource.GetSpectrumData(samples, 0, fftWindow);

        //스펙트럼 데이터 출력(디버그)
        for ( int i = 0; i < samples.Length; i++)
        {
            Debug.Log("SamPle" + i + " : " + samples[i]);
        }
    }
}
