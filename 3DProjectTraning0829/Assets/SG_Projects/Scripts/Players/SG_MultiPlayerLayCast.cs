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
            Debug.LogFormat("ID : {0} �� �����Ϳ��� üũ ��û", photonView.ViewID);
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
    public void SyncCopyMeterial() //�÷��̾ �����ҋ��� ����ȭ
    {
        if (Physics.SphereCast
            (rayPotisionObj.transform.position, rayRadius, transform.forward, out rayHit, maxDis))
        {
            Debug.Log("Coty == false ����");
            //Debug.LogFormat("��ü�� �������� ���ư� �Ÿ� -> {0}", rayHit.distance);

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
    public void SyncPlayerMeterial() //�÷��̾ ������ Ǯ�� ����ȭ
    {
        myMeshFilter.mesh = null;
        myMeshRenderer.material = null;
        getMeshFilter = null;
        getMeshRenderer = null;

        plyaerMesh.SetActive(true);
        rayHitObjMesh.SetActive(false);

        isCopy = false;
    }

    // LEGACY : Photon ���� �������ϴ� �κ� �����ؼ� �����Ŵ
    //[PunRPC]
    //public void ShotRay()
    //{
    //    if (PhotonNetwork.IsMasterClient)
    //    {
    //        if (isCopy == false)    // ī������ �ƴ϶��
    //        {
    //            if (Physics.SphereCast
    //                (rayPotisionObj.transform.position, rayRadius, transform.forward, out rayHit, maxDis))
    //            {
    //                Debug.Log("Coty == false ����");
    //                //Debug.LogFormat("��ü�� �������� ���ư� �Ÿ� -> {0}", rayHit.distance);

    //                getMeshFilter = rayHit.collider.gameObject.GetComponent<MeshFilter>();
    //                getMeshRenderer = rayHit.collider.gameObject.GetComponent<MeshRenderer>();

    //                plyaerMesh.SetActive(false);
    //                rayHitObjMesh.SetActive(true);
    //                myMeshFilter.mesh = getMeshFilter.mesh;
    //                myMeshRenderer.material = getMeshRenderer.material;
    //                rayHitObjMesh.transform.rotation = rayHit.transform.rotation;

    //                isCopy = true;

    //            }

    //        } //ī���� �ƴҶ�

    //        else if (isCopy == true) //ī���� �϶�
    //        {
    //            Debug.Log("Copy == True ����");
    //            myMeshFilter.mesh = null;
    //            myMeshRenderer.material = null;
    //            getMeshFilter = null;
    //            getMeshRenderer = null;

    //            plyaerMesh.SetActive(true);
    //            rayHitObjMesh.SetActive(false);

    //            isCopy = false;

    //        }     //ī���� �϶�

    //    } // if : IsMasterClient

    //} //ShotRay()



}   // NameSpace
