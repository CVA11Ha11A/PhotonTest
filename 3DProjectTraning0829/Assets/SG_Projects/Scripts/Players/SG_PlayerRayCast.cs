using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_PlayerRayCast : MonoBehaviour
{

    public GameObject rayPotisionObj;

    public GameObject plyaerMesh;


    public GameObject rayHitObjMesh;
    private MeshFilter myMeshFilter;
    private MeshRenderer myMeshRenderer;

    private RaycastHit rayHit;

    private MeshFilter getMeshFilter;
    private MeshRenderer getMeshRenderer;




    private float maxDis = 5f;
    private float rayRadius = 0.5f;

    private bool isCopy = false;


    void Start()
    {
        myMeshFilter = rayHitObjMesh.GetComponent<MeshFilter>();
        myMeshRenderer = rayHitObjMesh.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    private void FixedUpdate()
    {                  
        ShotRay();
    }

    public void ShotRay()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isCopy == false)
            {
                if (Physics.SphereCast(rayPotisionObj.transform.position, rayRadius, transform.forward, out rayHit, maxDis))
                {
                    //Debug.Log("Coty == false 들어옴");
                    //Debug.LogFormat("물체를 만났을때 날아간 거리 -> {0}", rayHit.distance);

                    getMeshFilter = rayHit.collider.gameObject.GetComponent<MeshFilter>();
                    getMeshRenderer = rayHit.collider.gameObject.GetComponent<MeshRenderer>();

                    plyaerMesh.SetActive(false);
                    rayHitObjMesh.SetActive(true);
                    myMeshFilter.mesh = getMeshFilter.mesh;
                    myMeshRenderer.material = getMeshRenderer.material;
                    rayHitObjMesh.transform.rotation = rayHit.transform.rotation;

                    isCopy = true;

                    // TODO : 플레이어 자식오브젝트로 메쉬를 너어두었고 플레이어 자체에 Mesh라는 것을 끄면
                    // Mesh가 꺼짐 그걸로 조절하면 될거같음            

                }


            } //카피중 아닐때

            else if (isCopy == true)
            {
                //Debug.Log("Coty == True 들어옴");
                myMeshFilter.mesh = null;
                myMeshRenderer.material = null;
                getMeshFilter = null;
                getMeshRenderer = null;

                plyaerMesh.SetActive(true);
                rayHitObjMesh.SetActive(false);

                isCopy = false;

            }     //카피중 일때

        }

    }
}
