using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platformPrefab;       //������ ������ ���� ������
    public int count = 3;                   //������ ���� ��

    public float timeBetSpawnMin = 1.24f;       //���� ��ġ������ �ð� ���� �ּҰ�
    public float timeBetSpawnMax = 2.25f;       //���� ��ġ������ �ð� ���� �ִ밪
    private float timeBetSpawn;                 //���� ��ġ������ �ð� ����

    public float yMin = -3.5f;      //��ġ�� ��ġ�� �ּ� y��
    public float yMax = 1.5f;       //��ġ�� ��ġ�� �ִ� y�� 
    private float xPos = 20f;       //��ġ�� ��ġ�� x��

    private GameObject[] platforms;             //�̸� ������ ���ǵ�
    private int currentIndex = 0;               //����� ���� ������ ����

    private Vector2 poolPosition = new Vector2(0, -25); //�ʹݿ� ������ ������ ȭ�� �ۿ� ���ܵ� ��ġ
    private float lastSpawnTime;                        //������ ��ġ ���� 


    // Start is called before the first frame update
    void Start()
    {
        //count ��ŭ�� ������ ������ ���ο� ���� �迭 ����
        platforms = new GameObject[count];

        //count ��ŭ �������鼭 ���� ����
        for (int i = 0; i < count; i++)
        {
            //platformPrefab�� �������� �� ������ poolPosition ��ġ�� ���� ����
            //������ ������ platform �迭�� �Ҵ�
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity); //�����Լ��� Pool ��ġ�� ȸ�������� ������ ����
        }

        //������ ��ġ ������ �ʱ�ȭ
        lastSpawnTime = 0.0f;
        //������ ��ġ������ �ð� ������ 0���� �ʱ�ȭ
        timeBetSpawn = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //���� ���� ���¿����� �������� ����
        if(GameManager.Instance.isGameOver)
        {
            return;
        }

        //������ ��ġ �������� TimeBetSpawn �̻� �ð��� Ǯ�ȴٸ�
        if(Time.time >= lastSpawnTime + timeBetSpawn)
        {
            //��ϵ� ������ ��ġ ����(lastSpawnTime)�� ���� ����(Time.time)���� ����
            lastSpawnTime = Time.time;

            //���� ��ġ������ �ð� ������ timeBetSpawnMin, timeBetSpawnMax ���̿��� ���� ����
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            //��ġ�� ��ġ�� ���̸� yMin�� yMax ���̿��� ���� ����
            float yPos = Random.Range(yMin, yMax);

            //����� ���� ������ ���� ���ӿ�����Ʈ�� ��Ȱ��ȭ�ϰ� ��� �ٽ� Ȱ��ȭ
            //�̶� ������ Platform ������Ʈ�� OnEnable �޼��尡 ����ȴ�.
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            //���� ������ ������ ȭ�� �����ʿ� ���ġ
            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            //���� �ѱ��
            currentIndex++;

            //������ ������ �����ߴٸ� ������ ���� ( �������� ������ �迭 ������ ����)
            if(currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
    }
}
