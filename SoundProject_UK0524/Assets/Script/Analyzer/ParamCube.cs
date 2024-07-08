using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int band;
    public float startScale;
    public float scaleMultiplier;
    private Vector3 initalPosition;
    public bool useBuffer;
    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newYScale = 0;
        if(!useBuffer)
        {
            newYScale = (AudioPeer.freqBand[band] * scaleMultiplier) + startScale;          //새로운 스캐일 계산
        }
        if(useBuffer)
        {
            newYScale = (AudioPeer.bandBuffet[band] * scaleMultiplier) + startScale;          //새로운 스캐일 계산
        }
        transform.localScale = new Vector3(transform.localScale.x, newYScale, transform.localScale.z);  //로컬 스케일 변경
        transform.position = new Vector3(transform.position.x, initalPosition.y + (newYScale / 2), transform.position.z);   //y축 위치 조정
    }
}
