using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AreaFloorBaker : MonoBehaviour
{

    [SerializeField] private NavMeshSurface Surface;                            //NavMesh ������ ���� Surface
    [SerializeField] private GameObject Player;                                 //NavMesh�� ���� �÷��̾� ������Ʈ 
    [SerializeField] private float UpdateRate = 0.1f;                           //NavMesh ������Ʈ �ֱ�
    [SerializeField] private float MovementThredshold = 3f;                     //NavMesh�� �ٽ� ������ �÷��̾� �̵� �Ÿ��� �Ӱ� ��
    [SerializeField] private Vector3 NavMeshSIze = new Vector3(20, 20, 20);     //NavMesh ũ��

    private Vector3 WorldAnchor;                                                //NavMesh �߽���
    private NavMeshData navMeshData;                                            //NavMesh ������
    private List<NavMeshBuildSource> Sources = new List<NavMeshBuildSource>();   //NavMesh ������ ���� �ҽ���

    void Start()
    {
        //NavMesh ������ �ʱ�ȭ �� ����
        navMeshData = new NavMeshData();
        NavMesh.AddNavMeshData(navMeshData);
        BuildNavMesh(false);
        StartCoroutine(CheckPlayerMovement());
    }

    //�÷��̾� ������ üũ �ڷ�ƾ
    private IEnumerator CheckPlayerMovement()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateRate);

        while (true)
        {
            //�÷��̾ ���� �Ÿ� �̻� �̵� �ߴ��� üũ 
            if (Vector3.Distance(WorldAnchor, Player.transform.position) > MovementThredshold)
            {
                BuildNavMesh(true);
                WorldAnchor = Player.transform.position;
            }
            yield return Wait;
        }

    }


    //NavMesh ���� �޼���
    private void BuildNavMesh(bool Async)
    {
        //NavMesh ��� ����
        Bounds navMeshBounds = new Bounds(Player.transform.position, NavMeshSIze);
        List<NavMeshBuildMarkup> markups = new List<NavMeshBuildMarkup>();
        List<NavMeshModifier> modifiers;

        //NavMeshModifier ������Ʈ ����
        if (Surface.collectObjects == CollectObjects.Children)
        {
            modifiers = new List<NavMeshModifier>(GetComponentsInChildren<NavMeshModifier>());
        }
        else
        {
            modifiers = NavMeshModifier.activeModifiers;
        }
        //NavMeshBuildMarkUp ����
        for (int i = 0; i < modifiers.Count; i++)
        {
            if (((Surface.layerMask & (1 << modifiers[i].gameObject.layer)) == 1) &&
                modifiers[i].AffectsAgentType(Surface.agentTypeID))
            {
                markups.Add(new NavMeshBuildMarkup()
                {
                    root = modifiers[i].transform,
                    overrideArea = modifiers[i].overrideArea,
                    area = modifiers[i].area,
                    ignoreFromBuild = modifiers[i].ignoreFromBuild
                });
            }
        }

        //NavMesh �ҽ� ����
        if (Surface.collectObjects == CollectObjects.Children)
        {
            NavMeshBuilder.CollectSources(transform, Surface.layerMask, Surface.useGeometry, Surface.defaultArea, markups, Sources);
        }
        else
        {
            NavMeshBuilder.CollectSources(navMeshBounds, Surface.layerMask, Surface.useGeometry, Surface.defaultArea, markups, Sources);
        }

        //NavMeshAget ������Ʈ�� �ִ� �ҽ��� ���� 
        Sources.RemoveAll(source => source.component != null && source.component.gameObject.GetComponent<NavMeshAgent>() != null);

        //NavMesh ������ ������Ʈ (�񵿱� ������ �������)
        if (Async)
        {
            NavMeshBuilder.UpdateNavMeshDataAsync
                (navMeshData, Surface.GetBuildSettings(), Sources, new Bounds(Player.transform.position, NavMeshSIze));
        }
        else
        {
            NavMeshBuilder.UpdateNavMeshData
              (navMeshData, Surface.GetBuildSettings(), Sources, new Bounds(Player.transform.position, NavMeshSIze));
        }
    }
}
