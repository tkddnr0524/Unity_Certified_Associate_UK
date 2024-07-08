using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFade : MonoBehaviour
{

    AudioSource audioSource;                //AudioSource 컴포넌트를 저장할 변수
    public float fadeDuration = 1.0f;       //페이드 인/아웃 지속시간

    private bool isFadingIn = false;        //페이드 인 상태 확인
    private bool isFadingOut = false;       //페이드 아웃 상태 확인
    private float fadeTimer = 0.0f;         //페이드 타이머 
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
