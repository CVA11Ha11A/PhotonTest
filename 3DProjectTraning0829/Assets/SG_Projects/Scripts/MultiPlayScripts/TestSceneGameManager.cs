using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class TestSceneGameManager : MonoBehaviourPunCallbacks,IPunObservable
{
    public static GameManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<GameManager>();
            }
            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }
    private static GameManager m_instance;

    public GameObject playerPrefab; // ������ �÷��̾� ĳ���� ������

    private void Awake()
    {
        //// ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        //if (instance != this)
        //{
        //    // �ڽ��� �ı�
        //    Destroy(gameObject);
        //}

        // ��Ʈ��ũ ���� ��� Ŭ���̾�Ʈ�鿡�� ���� ����
        // ��, �ش� ���� ������Ʈ�� �ֵ�����, ���� �޼��带 ���� ������ Ŭ���̾�Ʈ���� ����
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.one, Quaternion.identity);
    }

    void Start()
    {
        // ������ ���� ��ġ ����
        //Vector3 randomSpawnPos = Random.insideUnitSphere * 5f;
        //randomSpawnPos.y = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    //{ IPunObservable

    // �ֱ������� �ڵ� ����Ǵ�, ����ȭ �޼���
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //// ���� ������Ʈ��� ���� �κ��� �����
        //if (stream.IsWriting)
        //{
        //    // ��Ʈ��ũ�� ���� score ���� ������
        //    stream.SendNext(score);
        //}
        //else
        //{
        //    // ����Ʈ ������Ʈ��� �б� �κ��� �����         

        //    // ��Ʈ��ũ�� ���� score �� �ޱ�
        //    score = (int)stream.ReceiveNext();
        //    // ����ȭ�Ͽ� ���� ������ UI�� ǥ��
        //    UIManager.instance.UpdateScoreText(score);
        //}
    }
    //} IPunObservable

    // ���� ������ �ڵ� ����Ǵ� �޼���
    public override void OnLeftRoom()
    {
        // ���� ������ �κ� ������ ���ư�
        SceneManager.LoadScene("TitleScene");
    }
}
