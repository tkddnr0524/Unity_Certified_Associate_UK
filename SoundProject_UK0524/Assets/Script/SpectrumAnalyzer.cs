using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpectrumAnalyzer : MonoBehaviour
{
    AudioSource audioSource;                //AudioSource ������Ʈ�� ������ ����
    public float[] samples = new float[512];     //����Ʈ�� ���渦 ������ �迭
    public FFTWindow fftWindow = FFTWindow.Blackman;        //����� ����

    //Blackman : ��ȣ�� �� ���� 0�� �ǵ��� ����ġ�� ����Ǹ�, ������ ���� �������� ���ļ� ���شɷ� ���� ������ �� �ֽ��ϴ�.
    //Hamming : ��ȣ�� �� ���� 0�� �ƴϸ�, ������ ���̱� ���� ����ġ�� ����˴ϴ�.
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();          //AudioSource ������Ʈ�� ������
    }

   
    void Update()
    {
        //����Ʈ�� ������ ������
        audioSource.GetSpectrumData(samples, 0, fftWindow);

        //����Ʈ�� ������ ���(�����)
        for ( int i = 0; i < samples.Length; i++)
        {
            Debug.Log("SamPle" + i + " : " + samples[i]);
        }
    }
}
