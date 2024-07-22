using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScopeProjector : MonoBehaviour
{
    public float size = 2.0f;
    public float fadeSpeed = 2.0f;
    public Material projectorMaterial;                          //Ʈ���� ���׸��� ���

    private MeshRenderer quadRenderer;
    private bool isFading = false;

    void Awake()
    {
        GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);           //�⺻ ���� �����
        quad.transform.SetParent(transform);
        quad.transform.localPosition = Vector3.zero;                                //��ġ �ʱ�ȭ
        quad.transform.localRotation = Quaternion.Euler(90, 0, 0);                  //�ٴڿ� Quad �� ���� ���ؼ� X = 90
        quad.transform.localScale = Vector3.one * size;                             //������ ����

        quadRenderer = quad.GetComponent<MeshRenderer>();
        quadRenderer.material = projectorMaterial;                                          //�޾ƿ� ���׸����� ���� ��Ų��. 
        quadRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;       //�׸��ڸ� �ڵ�� ����. 
        quadRenderer.receiveShadows = false;

        Destroy(quad.GetComponent<Collider>());
    }


    void Update()
    {
        if (isFading)                                        //���̵� ���̸�
        {
            float currentAlpha = GetAlpha();                //�Լ��� ���� ���� ���� �����´�. 
            currentAlpha -= fadeSpeed * Time.deltaTime;     //�ð��� ���� ���� �������. 
            SetAlpha(currentAlpha);
            if (currentAlpha <= 0)                           //0 �����̸�
            {
                gameObject.SetActive(false);                //������Ʈ�� ����. 
            }
        }
    }

    public void ShowAtPosition(Vector3 position)                //���� �����ǿ��� ������Ʈ�� �����ش�. 
    {
        transform.position = position + Vector3.up * 0.1f;
        SetAlpha(1);
        isFading = false;
        gameObject.SetActive(true);
    }

    public void StartFading()
    {
        isFading = true;
    }

    private void SetAlpha(float alpha)
    {
        alpha = Mathf.Clamp01(alpha);                  //���� 0 ~ 1��
        Color color = projectorMaterial.color;          //�÷��� ���� ���� ����
        color.a = alpha;                                //���� �� �Ҵ�
        projectorMaterial.color = color;
    }

    private float GetAlpha()                            //���� ���� ���� ���� �Լ� 
    {
        return projectorMaterial.color.a;               //�÷� ���� �� ����     
    }
}