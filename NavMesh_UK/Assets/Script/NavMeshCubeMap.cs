using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;
using Unity.VisualScripting;

public class NavMeshCubeMap : MonoBehaviour
{
    public int gridSize = 10;               //���� ���� ũ�� ����
    public float cellSize = 1.0f;           //�� ť�� �� ũ��
    public float dropProbability = 0.1f;        //ť�갡 ������ Ȯ��
    public float dropDuration = 3.0f;           //ť�갡 �������µ� �ɸ��� �ð�
    public float terrainChangeInterval = 10f;   //���� ��ȭ ����
    public GameObject cubePrefabs;                 //ť�� ������
    public NavMeshSurface surface;                  //NavMesh�� ������ ǥ��
    public GameObject playerPrefab;                     //�÷��̾� ������

    private GameObject[,] grid;                         //�׸��带 ������ 2���� �迭
    private GameObject player;                          //�÷��̾� ���� ������Ʈ
    private NavMeshAgent playerAgent;                   //�÷��̾� ������Ʈ
    private float terraionChangeTimer;                  //���� ��ȭ Ÿ�̸�
    private List<DroppingCube> droppingCubes = new List<DroppingCube>();        //�������� �ִ� ť�긮��Ʈ

    private struct DroppingCube
    {
        public GameObject cube;       //ť�� ���� ������Ʈ
        public Vector3 startPos;   //������ġ
        public Vector3 endPos;      //�� ��ġ
        public float dropTimer;         //�������� �ð��� �����ϴ� Ÿ�̸�
        public int x, z;                //�׸��� �� ��ġ
    }


    void Start()
    {
        CreateGrid();
        SpawnPlayer();
        surface.BuildNavMesh();                         //�����Ҷ� ����޽ø� �����Ѵ�.
        terraionChangeTimer = terrainChangeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        HandleTerraionChanges();
        UpdateDroppingCubes();
    }

    //�ʱ� �׸��� ���� (GameObject �����ؼ� 2���� �迭�� �Ҵ�)
    void CreateGrid()
    {
        grid = new GameObject[gridSize, gridSize];              //�׸��� ������ ��ŭ 2���� �迭�� �Ҵ�

        for (int x = 0; x < gridSize; x++)                       //���� ������ �ۼ�
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 position = new Vector3(x * cellSize, 0, z * cellSize); //�� ť�� ��ġ ���
                GameObject cube = Instantiate(cubePrefabs, position, Quaternion.identity);  //ť�� �ν��Ͻ� ȭ
                cube.transform.localScale = new Vector3(cellSize, cellSize, cellSize);          //��� ũ�� ����
                grid[x, z] = cube;                                                           //�׸��忡 ť�� ����
            }
        }
    }
    void SpawnPlayer()
    {
        Vector3 spawnPosition = new Vector3(gridSize / 2 * cellSize, cellSize, gridSize / 2 * cellSize);    //�׸��� �߾�
        player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);                                 //�÷��̾� �ν��Ͻ� ȭ
        playerAgent = player.GetComponent<NavMeshAgent>();                                                  //NavMeshAgent ������Ʈ ��������
    }

    void HandleTerraionChanges()                    //���� ��ȭ ó��
    {
        terraionChangeTimer -= Time.deltaTime;      //Ÿ�̸� ����
        if (terraionChangeTimer <= 0)
        {
            bool terrainChange = false;

            for (int x = 0; x < gridSize; x++)                       //���� ������ �ۼ�
            {
                for (int z = 0; z < gridSize; z++)
                {
                    if (Random.value < dropProbability && grid[x, z] != null)
                    {
                        StartDropCube(x, z);
                        terrainChange = true;
                    }
                }
            }

            if (terrainChange)       //������ ���� �Ǿ��ٸ� NavMesh �籸��
            {
                StartCoroutine(BakemapNavMesh());
            }

            terraionChangeTimer = terrainChangeInterval;
        }
    }

    IEnumerator BakemapNavMesh()
    {
        yield return new WaitForSeconds(0.2f);
        surface.BuildNavMesh();
    }

    void UpdateDroppingCubes()      //�������� ť��� ������Ʈ
    {
        for (int i = droppingCubes.Count - 1; i >= 0; i--)
        {
            DroppingCube droppingCube = droppingCubes[i];
            droppingCube.dropTimer += Time.deltaTime;

            //�������� �ð��� �Ϸ�Ǹ�
            if (droppingCube.dropTimer >= dropDuration)
            {
                Destroy(droppingCube.cube);
                grid[droppingCube.x, droppingCube.z] = null;
                droppingCubes.RemoveAt(i);
            }
            else
            {
                droppingCube.cube.transform.position = Vector3.Lerp(droppingCube.startPos, droppingCube.endPos,
                    droppingCube.dropTimer / dropDuration);
                droppingCubes[i] = droppingCube;            //ť�� ��ġ ������Ʈ
            }
        }
    }

    void StartDropCube(int x, int z)        //ť�긦 ����߸��� ����
    {
        GameObject cube = grid[x, z];
        Vector3 startPos = cube.transform.position;
        Vector3 endPos = startPos - Vector3.up * 5;

        droppingCubes.Add(new DroppingCube          //����ü�� �´� ���·� ����Ʈ�� �ִ´�. 
        {
            cube = cube,
            startPos = startPos,
            endPos = endPos,
            dropTimer = 0,
            x = x,
            z = z
        });
    }
}