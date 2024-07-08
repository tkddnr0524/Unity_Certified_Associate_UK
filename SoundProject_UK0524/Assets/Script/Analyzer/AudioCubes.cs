using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCubes : MonoBehaviour
{

    //샘플큐브 프리팹
    public GameObject sampleCubePrefab;

    GameObject[] sampleCube = new GameObject[512];      //샘플 큐브 배열
    public float maxScale = 1000;                       //큐브의 최대 크기

    void Start()
    {
        for(int i = 0; i < 512; i++)
        {
            GameObject temp = (GameObject)Instantiate(sampleCubePrefab);            //큐브프리팹을 인스턴스화
            temp.transform.position = this.transform.position;                      //큐브의 초기 위치를 이 오브젝트의 위치로 설정
            temp.transform.parent = this.transform;                                 //큐브의 부모를 이 오브젝트로 설정
            temp.name = "Cube" + i.ToString("000");                                 //큐브의 이름을 "Cube000"형식으로 설정
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);         //이 오브젝트를 회전시켜서 큐브를 배치
            temp.transform.position = Vector3.forward * 100;                        //큐브를 전방으로 100 이동 시킴
            sampleCube[i] = temp;                                                   //큐브를 배열에 저장
        }
    }

    void Update()
    {
        for(int i = 0; i < 512; i++)
        {
            if (sampleCube[i] != null)
            {//오디오 샘플 데이터에 기반해 큐브의 Y축 스케일을 변경
                sampleCube[i].transform.localScale = new Vector3(10, (AudioPeer.samples[i] * maxScale) + 2, 10) * 0.1f;
            }
        }
    }
}
