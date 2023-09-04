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
        // 자신이 로컬 플레이어라면
        if(photonView.IsMine)
        {
            // 씬에 있는 시네머신 가상 카메라를 찾음
            CinemachineVirtualCamera followCam = FindObjectOfType<CinemachineVirtualCamera>();
            //hpCanvas.renderMode.
            // 가상카메라의 추적 대상을 자신의 트랜스폼으로 변경
            followCam.Follow = this.transform;
            followCam.LookAt = this.transform;
        }
    }

   
    void Update()
    {
        
    }
}
