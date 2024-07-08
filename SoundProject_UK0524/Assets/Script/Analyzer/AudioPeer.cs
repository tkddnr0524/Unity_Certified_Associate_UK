using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]


public class AudioPeer : MonoBehaviour
{

    AudioSource audioSource;                //AudioSource ������Ʈ�� ������ ����
    public static float[] samples = new float[512];     //FFT�� ���� ����Ʈ�� ������ ����
    public static float[] freqBand = new float[8];      //���ļ� �뿪 ( 8���� ���ļ� �뿪���� ������ ���ؼ�)
    public static float[] bandBuffet = new float[8];    //���ļ� �뿪 ����
    float[] bufferDecreas = new float[8];               //���� ���� �ӵ�

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrumAudioSource(); //����� ����Ʈ�� �����͸� �����´�.
        MakeFrequencyBand();      //���ļ� �뿪�� ����ϴ�.
        BandBuffer();             //���ļ� �뿪 ���۸� �����.
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);            //����� ���� ����Ʈ�� �����͸� Samples �迭�� �����մϴ�.
    }

    void MakeFrequencyBand()        //���Ĵ뿪�� ����� �Լ�
    {
        int count = 0;

        for(int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            
            //������ ���ļ� �뿪�� 2���� ������ �߰��� ���
            if(i == 7)
            {
                sampleCount += 2;
            }

            for(int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            //���ļ� �뿪 ���� ���� (�ð������� �� �� ���̵��� 10�� ����)
            freqBand[i] = average * 10;
        }
    }

    void BandBuffer()       //���ļ� �뿪 ���۸� ����� �Լ�
    {
        for(int i = 0; i < 8; i++)
        {
            //���ļ� �뿪�� ���ۺ��� ũ�� ���۸� ���ļ� �뿪������ ����
            if (freqBand[i] > bandBuffet[i])
            {
                bandBuffet[i] = freqBand[i];
                bufferDecreas[i] = 0.005f;
            }
            //���ļ� �뿪�� ���ۺ��� ������ ���۸� ����
            if (freqBand[i] < bandBuffet[i])
            {
                bandBuffet[i] -= bufferDecreas[i];
                bufferDecreas[i] *= 1.2f;
            }
        }
    }
}
