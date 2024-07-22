using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10f;
    public string speedParameterName = "Speed";
    public GameObject scopeProjectorPrefabs;                        //ĳ���� �̵� ��ġ�� �˷��� ������
    public NavMeshAgent agent;                                      //�׺�Ž� Ŭ���� �Ҵ�
    public Animator animator;
    private Camera mainCamera;                                      //�����ɽ�Ʈ�� �ϱ� ���� ī�޶� �����´�. 
    public QuadScopeProjector scopeProjector;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        agent.speed = moveSpeed;                                    //�׺�޽� ���ǵ� �Ҵ�

        GameObject projectorObj = Instantiate(scopeProjectorPrefabs);
        scopeProjector = projectorObj.GetComponent<QuadScopeProjector>();
        projectorObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);             //ī�޶󿡼� ��ũ�� ��ġ�� ���콺�����ǿ��� �����ɽ����� �Ѵ�. 
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))                                       //�����ɽ��ÿ� ������ �Ǵ°��� ���� ���
            {
                agent.SetDestination(hit.point);                                    //������Ʈ�� �������� ��Ʈ ����Ʈ�� �Ѵ�. 
                scopeProjector.gameObject.SetActive(true);
                scopeProjector.ShowAtPosition(hit.point);
            }
        }

        float currentSpeed = Mathf.Clamp01(agent.velocity.magnitude / agent.speed);     // 0 ~ 1 ���̰����� ����

        animator.SetFloat(speedParameterName, currentSpeed);                            //���� �ִϸ��̼� ���� �־� �ش�. 

        if (agent.velocity.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(agent.desiredVelocity, Vector3.up);      //�̵��� ȸ�� ���� ���Ѵ�.
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);  //ȸ�� ������ ���ش�. 
        }

        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            scopeProjector.StartFading();
        }
    }
}