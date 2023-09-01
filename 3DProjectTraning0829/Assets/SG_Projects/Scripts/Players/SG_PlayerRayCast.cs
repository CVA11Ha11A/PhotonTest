using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_PlayerRayCast : MonoBehaviour
{
    RaycastHit rayHit;
    public GameObject rayPotisionObj;
    private float maxDis = 30f;

    public GameObject myMeshObj;
    public GameObject hitObjMeshObj;


    Mesh rayCollider;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShotRay();
    }

    public void ShotRay()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(rayPotisionObj.transform.position, transform.forward, out rayHit, maxDis))
            {
                //Debug.LogFormat("Ʈ������ -> {0}",rayHit.transform);
                //Debug.LogFormat("������ǥ -> {0}", rayHit.point);

                if (rayHit.transform != null)

                    rayCollider = rayHit.collider.gameObject.GetComponent<Mesh>();
                    
                // TODO : �÷��̾� �ڽĿ�����Ʈ�� �޽��� �ʾ�ξ��� �÷��̾� ��ü�� Mesh��� ���� ����
                // Mesh�� ���� �װɷ� �����ϸ� �ɰŰ���
                

            }

        }
    }
}
