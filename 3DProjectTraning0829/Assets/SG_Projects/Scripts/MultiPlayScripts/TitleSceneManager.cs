using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime; // 포톤 서비스 관련 라이브러리

public class TitleSceneManager : MonoBehaviourPunCallbacks
{

    //  현재 서버에 접속중인지 접속을 못했는지 알려줄 Text
    public TextMeshProUGUI serverText;
    //  게임에 들어가게 하는 버튼
    public Button joinButton;

    private void Awake()
    {

    }


    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //룸 접속 버튼 비활성화 (중복접속 명령을 방지하기위해)
        //  interactable 상호작용 여부를 명령하는 기능
        joinButton.interactable = false;
        // 접속 정보 표시
        serverText.text = "Connect to Master Server....";

    }

   
    void Update()
    {
        
    }


    // 마스터 서버 접속 성공시 자동 실행
    public override void OnConnectedToMaster()
    {
        //룸 접속 버튼 활성화
        joinButton.interactable = true;

        //접속 정보 표시
        serverText.text = "Online : Conneted to Master Server Succeed";
    }
    // 마스터 서버 접속 실패시 자동 실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        //룸 접속 버튼 비활성화
        joinButton.interactable = false;
        //접속 정보 표시
        serverText.text = "Offline : ReConnect to Master Server....";

        // 마스터 서버로의 재접속 시도
        PhotonNetwork.ConnectUsingSettings();
    }

    // 룸 접속 시도
    public void Connect()
    {
        //중복 접속 시도를 막기 위해 접속 버튼 잠시 비활성화
        joinButton.interactable = false;

        //마스터 서버에 접속 중이라면
        if (PhotonNetwork.IsConnected)
        {
            // 룸 접속 실행
            serverText.text = "Connect to Room";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // 마스터 서버에 접속 중이 아니라면 마스터 서버에 접속 시도
            serverText.text = " OffLine : Not Connect Master Server Remote";
            //마스터 서버로의 재접속 시도
            PhotonNetwork.ConnectUsingSettings();
        }

    }

    // (빈 방이 없어)랜덤 룸 참가에 실패한 경우 자동 실행
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //접속 상태 표시
        serverText.text = "Nothing to empty Room,Create new room.....";
        //최대 4명을 수용 가능한 빈 방 생성
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
    }

    // 룸에 참가 완료된 경우 자동 실행
    public override void OnJoinedRoom()
    {
        // 점속 상태 표시
        serverText.text = "Join Room Success";
        //  모든 룸 참가자가 TestScene 씬 로드하게 함
        PhotonNetwork.LoadLevel("TestScene");
    }

}
