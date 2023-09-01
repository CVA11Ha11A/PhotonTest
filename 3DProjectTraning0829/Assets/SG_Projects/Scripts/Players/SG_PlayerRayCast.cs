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
                //Debug.LogFormat("트렌스폼 -> {0}",rayHit.transform);
                //Debug.LogFormat("맞은좌표 -> {0}", rayHit.point);

                if (rayHit.transform != null)

                    rayCollider = rayHit.collider.gameObject.GetComponent<Mesh>();
                    
                // TODO : 플레이어 자식오브젝트로 메쉬를 너어두었고 플레이어 자체에 Mesh라는 것을 끄면
                // Mesh가 꺼짐 그걸로 조절하면 될거같음
                

            }

        }
    }
}
