using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SG_MultiPlayerLayCast : MonoBehaviourPun
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
        if (Input.GetMouseButtonDown(1) && photonView.IsMine)
        {
            Debug.LogFormat("ID : {0} 가 마스터에게 체크 요청", photonView.ViewID);
            photonView.RPC("CheckCopy",RpcTarget.MasterClient,isCopy);
            //photonView.RPC("ShotRay", RpcTarget.MasterClient);
        }
    }


    [PunRPC]
    public void CheckCopy(bool nowCopy)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (nowCopy == false)
            {
                photonView.RPC("SyncCopyMeterial", RpcTarget.All);
                //SyncCopyMeterial();
            }
            else if (nowCopy == true)
            {
                photonView.RPC("SyncPlayerMeterial", RpcTarget.All);
                // SyncPlayerMeterial
            }
            else { /*PASS*/ }
        }
       
    }


    [PunRPC]
    public void SyncCopyMeterial() //플레이어가 변신할떄에 동기화
    {
        if (Physics.SphereCast
            (rayPotisionObj.transform.position, rayRadius, transform.forward, out rayHit, maxDis))
        {
            Debug.Log("Coty == false 들어옴");
            //Debug.LogFormat("물체를 만났을때 날아간 거리 -> {0}", rayHit.distance);

            getMeshFilter = rayHit.collider.gameObject.GetComponent<MeshFilter>();
            getMeshRenderer = rayHit.collider.gameObject.GetComponent<MeshRenderer>();

            plyaerMesh.SetActive(false);
            rayHitObjMesh.SetActive(true);
            myMeshFilter.mesh = getMeshFilter.mesh;
            myMeshRenderer.material = getMeshRenderer.material;
            rayHitObjMesh.transform.rotation = rayHit.transform.rotation;

            isCopy = true;

        }
    }

    [PunRPC]
    public void SyncPlayerMeterial() //플레이어가 변신을 풀때 동기화
    {
        myMeshFilter.mesh = null;
        myMeshRenderer.material = null;
        getMeshFilter = null;
        getMeshRenderer = null;

        plyaerMesh.SetActive(true);
        rayHitObjMesh.SetActive(false);

        isCopy = false;
    }

    // LEGACY : Photon 으로 보내야하는 부분 분할해서 적용시킴
    //[PunRPC]
    //public void ShotRay()
    //{
    //    if (PhotonNetwork.IsMasterClient)
    //    {
    //        if (isCopy == false)    // 카피중이 아니라면
    //        {
    //            if (Physics.SphereCast
    //                (rayPotisionObj.transform.position, rayRadius, transform.forward, out rayHit, maxDis))
    //            {
    //                Debug.Log("Coty == false 들어옴");
    //                //Debug.LogFormat("물체를 만났을때 날아간 거리 -> {0}", rayHit.distance);

    //                getMeshFilter = rayHit.collider.gameObject.GetComponent<MeshFilter>();
    //                getMeshRenderer = rayHit.collider.gameObject.GetComponent<MeshRenderer>();

    //                plyaerMesh.SetActive(false);
    //                rayHitObjMesh.SetActive(true);
    //                myMeshFilter.mesh = getMeshFilter.mesh;
    //                myMeshRenderer.material = getMeshRenderer.material;
    //                rayHitObjMesh.transform.rotation = rayHit.transform.rotation;

    //                isCopy = true;

    //            }

    //        } //카피중 아닐때

    //        else if (isCopy == true) //카피중 일때
    //        {
    //            Debug.Log("Copy == True 들어옴");
    //            myMeshFilter.mesh = null;
    //            myMeshRenderer.material = null;
    //            getMeshFilter = null;
    //            getMeshRenderer = null;

    //            plyaerMesh.SetActive(true);
    //            rayHitObjMesh.SetActive(false);

    //            isCopy = false;

    //        }     //카피중 일때

    //    } // if : IsMasterClient

    //} //ShotRay()



}   // NameSpace
