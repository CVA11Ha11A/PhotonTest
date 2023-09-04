using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;
using UnityEngine.UI;
public class SG_MultiPlayerCameraSetup : MonoBehaviourPun
{
    public Canvas hpCanvas;

    void Start()
    {
        // �ڽ��� ���� �÷��̾���
        if(photonView.IsMine)
        {
            // ���� �ִ� �ó׸ӽ� ���� ī�޶� ã��
            CinemachineVirtualCamera followCam = FindObjectOfType<CinemachineVirtualCamera>();
            //hpCanvas.renderMode.
            // ����ī�޶��� ���� ����� �ڽ��� Ʈ���������� ����
            followCam.Follow = this.transform;
            followCam.LookAt = this.transform;
        }
    }

   
    void Update()
    {
        
    }
}
