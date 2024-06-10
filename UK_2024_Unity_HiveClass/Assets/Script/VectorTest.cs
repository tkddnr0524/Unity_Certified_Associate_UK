using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 0, 10);
        transform.localScale = new Vector3(1, 1, 1); //Vector3.one

        //rotation�� Vector3 Ÿ���� �ƴ�
        transform.rotation = Quaternion.Euler(new Vector3(30, 60, 90));         //���Ϸ� ���� ǥ���ϴ� Vector3 ������ ���ο� Quaternion ���� ����

        //Quaternion Ÿ���� ����� ȸ������ Vector3 Ÿ���� ���Ϸ� ������ ��ȯ�� ���� eulerAngle �� ����

        Quaternion rotation = Quaternion.Euler(new Vector3(0, 60, 0));

        Vector3 eulerRotation = rotation.eulerAngles;  //Vector3 Ÿ�� ������ (0, 60, 0)���� ���

        Quaternion a = Quaternion.Euler(30, 0, 0);
        Quaternion b = Quaternion.Euler(0, 60, 0);

        //a��ŭ ȸ���� ���¿��� b��ŭ �� ȸ���� ȸ������ ǥ��
        Quaternion Qrotation = a * b;

    }
}
