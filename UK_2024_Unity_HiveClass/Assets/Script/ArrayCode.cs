using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCode : MonoBehaviour
{
    public int[] students = new int[5];             //학생(int) 배열 5칸 선언
    // Start is called before the first frame update
    void Start()
    {


        students[0] = 100;                          //배열의 index에 값 입력
        students[1] = 90;
        students[2] = 80;
        students[3] = 70;
        students[4] = 60;

        //Debug.Log("0 번 학생의 점수 : " + students[0]);       //Debug.Log로 각각의 값 출력
        //Debug.Log("1 번 학생의 점수 : " + students[1]);
        //Debug.Log("2 번 학생의 점수 : " + students[2]);
        //Debug.Log("3 번 학생의 점수 : " + students[3]);
        //Debug.Log("4 번 학생의 점수 : " + students[4]);

        Debug.Log(" students.Length : " + students.Length);

        for( int i = 0; i < students.Length; i++)
        {
            Debug.Log((i + 1) + " 번 학생의 점수 : " + students[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
