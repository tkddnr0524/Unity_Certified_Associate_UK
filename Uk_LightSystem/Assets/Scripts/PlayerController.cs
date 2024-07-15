using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //라이트에 의한 데미지 설정 클래스
    [System.Serializable]
    public class LightDamageSettings            //일반 빛에 데미지
    {
        public float nearDistacne = 2f;         //가까운 거리 기준
        public float mediumDistance = 5f;       //중간 거리 기준
        public int nearDamage = 3;              //가까운 거리에서의 데미지
        public int mediumDamage = 2;            //중간 거리에서의 데미지
        public int farDamage = 1;               //머전 거리에서의 데미지
    }

    [System.Serializable]
    public class DirectionalLightSetttings
    {
        public int baseDamage = 1;                      //기본데미지
        public int maxDamage = 3;                       //최대 데미지
        public float damagelIncreaseInterval = 2f;      //데미ㅣ 증가 간격

    }

    public LightDamageSettings lightDamage;
    public DirectionalLightSetttings directionalLightDamage;

    public float damagedInterval = 1.0f;                    //데미지를 반는 간격
    public float nightThreshold = 0.2f;                     //밤으로 간주할 빛의 강도 임계값
    public float moveSpeed = 5f;                            //이동속도

    private CharacterController controller;                 //캐릭터 컨트롤러 컴포넌트
    private Light[] sceneLights;                            //씬의 모든 라이트를 가져와서 배열에 넣는다.
    private int currentDirectionalLightDamage;              //현재 디렉셔널 라이트 데미지
    private float lastDamageTime;                           //마지막으로 데미지를 받은 시간
    private float lastDirectionalLightDamageTime;             //마지막으로 디렉셔널 라이트 데미지가 증가한 시간
    private float cumalativeDamage;                        //누적 데미지


    void Start()                //데이터 초기화
    {
        controller = GetComponent<CharacterController>();
        sceneLights = FindObjectsOfType<Light>();           //Scene의 모든 라이트 찾기
        ResetDirectionalLightDamage();
    }


    void Update()
    {
        //플레이어 이동 처리 
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(movement * moveSpeed * Time.deltaTime);

        //데미지 처리 
        if(IsExposedToLight())
        {
            if(Time.time - lastDamageTime >= damagedInterval)
            {
                TakeDamage();
            }
            UpdateDirectionalLightDamage();
        }
        else
        {
            ResetDirectionalLightDamage();
        }
    }

    void TakeDamage()           //데미지 적용
    {
        int damage = currentDirectionalLightDamage;
        cumalativeDamage += damage;
        lastDamageTime = Time.time;
        Debug.Log($"플레이어가 데미지를 받음 : {damage} , 누적 데미지 : {cumalativeDamage}");
    }

    int CalculateDamage()
    {
        int damage = currentDirectionalLightDamage;

        float clossetPointLightDistance = float.MaxValue;
        bool exposedToPointLight = false;

        //가장 가까운 포인트 라이트 찾기ㅏ
        for (int i = 0; i < sceneLights.Length; i++)
        {
            if (sceneLights[i].type == LightType.Point && isExposedToPointLight(sceneLights[i]))
            {
                float distance = Vector3.Distance(transform.position, sceneLights[i].transform.position);
                if(distance < clossetPointLightDistance)
                {
                    clossetPointLightDistance = distance;
                    exposedToPointLight = true;
                }
            }
        }

        //포인트 라이트에 의한 데미지 계산
        if(exposedToPointLight)
        {
            if (clossetPointLightDistance <= lightDamage.nearDistacne) damage += (int)lightDamage.nearDistacne;
            else if (clossetPointLightDistance <= lightDamage.mediumDistance) damage += (int)lightDamage.mediumDistance;
            else damage += (int)lightDamage.farDamage;
        }

        return damage;
    }

    bool IsExposedToLight()
    {
        return IsExposedToDirectionalLight() || IsExposedToAnyPointLight();           //라이트 타입이 추가되면 추가 코딩 해준다.
    }

    //포인트 라이트에 노출 되어 있는지 확인
    bool isExposedToPointLight(Light light)
    {
        Vector3 directionToLight = light.transform.position - transform.position;       //받아온 포인트의 방향값을 구한다.
        return directionToLight.magnitude <= light.range &&
            !Physics.Raycast(transform.position, directionToLight.normalized, directionToLight.magnitude);
    }

    //
    bool IsExposedToAnyPointLight()
    {
        for(int i = 0; i < sceneLights.Length; i++)
        {
            if(sceneLights[i].type == LightType.Point && isExposedToPointLight(sceneLights[i]))
            {
                return true;
            }
        }
        return false;
    }

    bool IsExposedToDirectionalLight()
    {
        for (int i = 0; i < sceneLights.Length; i++)
        {
            if (sceneLights[i].type == LightType.Directional && !isInDirectionalShadow(sceneLights[i]))
            {
                return true;
            }
        }

        return false;
    }

    //디렉셔널 라이트 그림자 안에 있는지 확인
    bool isInDirectionalShadow(Light light)
    {
        const int rayCount = 5;
        const float rayRadius = 0.5f;
        int shadowCount = 0;

        for (int i = 0; i < rayCount; i++)
        {
            Vector3 rayStart = transform.position + Quaternion.Euler(0, i * 360.0f / rayCount, 0) * (Vector3.forward * rayRadius);
            if (Physics.Raycast(rayStart, -light.transform.forward, out _))
            {
                shadowCount++;
            }
        }

        return shadowCount > rayCount / 2;
    }


    void UpdateDirectionalLightDamage()
    {
        if (Time.time - lastDirectionalLightDamageTime >= directionalLightDamage.damagelIncreaseInterval)
        {
            currentDirectionalLightDamage = Mathf.Min(currentDirectionalLightDamage + 1, directionalLightDamage.maxDamage);
            lastDirectionalLightDamageTime = Time.time;
        }
    }

    //디렉셔널 라이트 데미지 리셋
    void ResetDirectionalLightDamage()
    {
        currentDirectionalLightDamage = directionalLightDamage.baseDamage;
    }
}
