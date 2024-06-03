using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefabs;            //생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f;           //탄알 최소 생성 주기
    public float spawnRateMax = 3.0f;           //탄알 최대 생성 주기

    private Transform target;                   //발사할 대상(Transform)
    public float spawnRate;                    //생성 주기 (랜덤값을 가지는 변수)
    public float timeAfterSpawn;                //최근 생성 시점에서 지난 시간 (타이머를 표시하는 변수)

    public float findTargetTime;                //Target을 찾는 시간 추가

    // Start is called before the first frame update
    void Start()
    {
        //최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;
        //탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이에 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아서 조준 대상으로 설정
        target = FindObjectOfType<PlayerController>().transform;  //Target은 (Transfrom) , FindObjectOfType<PlayerController>()(GameObject) 이기 때문에
                                                                  //.transform으로 같은 형태의 변수로 만들어 준다.

        //게임 오브젝트를 찾는 방법(Scene)
        //FindObjectOfType : 컴포넌트로 찾는다.
        //FindWithTag : Tag로 게임 오브젝트를 찾는다. ->  GameObject.FindWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        if(findTargetTime >= 1.0f)                          //타겟이 없는 시간이 1초가 넘어 갔을 때
        {
            GameObject findTarget = GameObject.FindWithTag("Player");             //target 오브제트를 찾는다.
            if(findTarget != null)
            {
                target = findTarget.transform;
            }
            findTargetTime = 0.0f;                          //찾는 시간을 초기화 시켜준다.
        }
        if(target == null)                                  //타겟이 없을 경우
        {
            findTargetTime += Time.deltaTime;               //타겟이 없을 경우 누적 시간을 계산해서
            return;                                         //Update 를 빠져나간다.
        }
        //timerAfterspawn 갱신
        timeAfterSpawn += Time.deltaTime;                       //해당 프레임 초를 쌓아서 timeAfterSpawn에 반영한다.

        //최근 생성 시점으로 부터 누적된 시간이 생성 주기보다 크면
        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            //bulletPrefab의 복제본을 생성
            //transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bullet
                = Instantiate(bulletPrefabs, transform.position, transform.rotation);

            //생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);

            //다음번 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤을 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
