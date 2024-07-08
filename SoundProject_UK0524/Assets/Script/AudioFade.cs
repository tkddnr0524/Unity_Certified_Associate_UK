using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFade : MonoBehaviour
{

    AudioSource audioSource;                //AudioSource ������Ʈ�� ������ ����
    public float fadeDuration = 1.0f;       //���̵� ��/�ƿ� ���ӽð�

    private bool isFadingIn = false;        //���̵� �� ���� Ȯ��
    private bool isFadingOut = false;       //���̵� �ƿ� ���� Ȯ��
    private float fadeTimer = 0.0f;         //���̵� Ÿ�̸� 
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadingIn)
        {
            fadeTimer += Time.deltaTime;
            audioSource.volume = Mathf.Clamp01(fadeTimer / fadeDuration);

            if (audioSource.volume >= 1.0f)
            {
                isFadingIn = false;
                fadeTimer = 0.0f;
            }
        }
        if(isFadingOut)
        {
            fadeTimer += Time.deltaTime;
            audioSource.volume = Mathf.Clamp01(1.0f - (fadeTimer / fadeDuration));

            if(audioSource.volume <= 0.0f)
            {
                isFadingOut = false;
                fadeTimer = 0.0f;
                audioSource.Stop();
            }
        }
    }

    public void StartFadeIn()
    {
        isFadingIn = true;
        isFadingOut = false;
        fadeTimer = 0.0f;
        audioSource.Play();
    }

    public void StartFadeOut()
    {
        isFadingIn = false;
        isFadingOut = true;
        fadeTimer = 0.0f;
    }
}
