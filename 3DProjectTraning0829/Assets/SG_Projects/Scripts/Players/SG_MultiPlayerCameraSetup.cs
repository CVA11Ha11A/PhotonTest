using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class SG_MultiPlayerCameraSetup : MonoBehaviourPun
{
   
    void Start()
    {
        // �ڽ��� ���� �÷��̾���
        if(photonView.IsMine)
        {
            // ���� �ִ� �ó׸ӽ� ���� ī�޶� ã��
            CinemachineVirtualCamera followCam = FindObjectOfType<CinemachineVirtualCamera>();
            // ����ī�޶��� ���� ����� �ڽ��� Ʈ���������� ����
            followCam.Follow = this.transform;
            followCam.LookAt = this.transform;
        }
    }

   
    void Update()
    {
        
    }
}
