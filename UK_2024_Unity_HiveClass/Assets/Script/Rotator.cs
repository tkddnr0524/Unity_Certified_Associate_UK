using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public float rotationSpeed = 60.0f;


    private void Awake()
    {
        Application.targetFrameRate = 200;
    }
    void Update()
    {
        transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);                    //�����Ӹ��� 60�� Y�� ȸ���� �Ѵ�.
    }
}
