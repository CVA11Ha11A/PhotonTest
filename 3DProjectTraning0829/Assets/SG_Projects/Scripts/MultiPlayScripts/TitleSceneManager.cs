using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime; // ���� ���� ���� ���̺귯��

public class TitleSceneManager : MonoBehaviourPunCallbacks
{

    //  ���� ������ ���������� ������ ���ߴ��� �˷��� Text
    public TextMeshProUGUI serverText;
    //  ���ӿ� ���� �ϴ� ��ư
    public Button joinButton;

    private void Awake()
    {

    }


    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //�� ���� ��ư ��Ȱ��ȭ (�ߺ����� ����� �����ϱ�����)
        //  interactable ��ȣ�ۿ� ���θ� ����ϴ� ���
        joinButton.interactable = false;
        // ���� ���� ǥ��
        serverText.text = "Connect to Master Server....";

    }

   
    void Update()
    {
        
    }


    // ������ ���� ���� ������ �ڵ� ����
    public override void OnConnectedToMaster()
    {
        //�� ���� ��ư Ȱ��ȭ
        joinButton.interactable = true;

        //���� ���� ǥ��
        serverText.text = "Online : Conneted to Master Server Succeed";
    }
    // ������ ���� ���� ���н� �ڵ� ����
    public override void OnDisconnected(DisconnectCause cause)
    {
        //�� ���� ��ư ��Ȱ��ȭ
        joinButton.interactable = false;
        //���� ���� ǥ��
        serverText.text = "Offline : ReConnect to Master Server....";

        // ������ �������� ������ �õ�
        PhotonNetwork.ConnectUsingSettings();
    }

    // �� ���� �õ�
    public void Connect()
    {
        //�ߺ� ���� �õ��� ���� ���� ���� ��ư ��� ��Ȱ��ȭ
        joinButton.interactable = false;

        //������ ������ ���� ���̶��
        if (PhotonNetwork.IsConnected)
        {
            // �� ���� ����
            serverText.text = "Connect to Room";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // ������ ������ ���� ���� �ƴ϶�� ������ ������ ���� �õ�
            serverText.text = " OffLine : Not Connect Master Server Remote";
            //������ �������� ������ �õ�
            PhotonNetwork.ConnectUsingSettings();
        }

    }

    // (�� ���� ����)���� �� ������ ������ ��� �ڵ� ����
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //���� ���� ǥ��
        serverText.text = "Nothing to empty Room,Create new room.....";
        //�ִ� 4���� ���� ������ �� �� ����
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
    }

    // �뿡 ���� �Ϸ�� ��� �ڵ� ����
    public override void OnJoinedRoom()
    {
        // ���� ���� ǥ��
        serverText.text = "Join Room Success";
        //  ��� �� �����ڰ� TestScene �� �ε��ϰ� ��
        PhotonNetwork.LoadLevel("TestScene");
    }

}
