using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//왼쪽 끝으로 이동할 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoop : MonoBehaviour
{

    public float width;   //배경의 가로 길이
    
    void Awake()        //가로 길이를 측정하는 처리
    {
        //BoxCoiider2D 컴포넌트의 size 필드의 x 값을 가로 길이로 사용
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();           //BoxCollider2D 컴포넌트에 접근
        width = backgroundCollider.size.x;
    }

    
    void Update()
    {
        //현재 위치가 원점에서 왼쪽으로 Width 이상 이동했을 때의 위치를 재배치
        if(transform.position.x <= -width)
        {
            Repostion();                        //함수실행
        }
    }

    //위치를 재배치하는 메서드
    void Repostion()
    {
        //현재 위치에서 오른쪽으로 가로 길이 * 2 만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
