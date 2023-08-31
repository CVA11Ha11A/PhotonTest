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
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }
            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }
    private static GameManager m_instance;

    public GameObject playerPrefab; // 생성할 플레이어 캐릭터 프리팹

    private void Awake()
    {
        //// 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        //if (instance != this)
        //{
        //    // 자신을 파괴
        //    Destroy(gameObject);
        //}

        // 네트워크 상의 모든 클라이언트들에서 생성 실행
        // 단, 해당 게임 오브젝트의 주도권은, 생성 메서드를 직접 실행한 클라이언트에게 있음
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.one, Quaternion.identity);
    }

    void Start()
    {
        // 생성할 랜덤 위치 지정
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

    // 주기적으로 자동 실행되는, 동기화 메서드
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //// 로컬 오브젝트라면 쓰기 부분이 실행됨
        //if (stream.IsWriting)
        //{
        //    // 네트워크를 통해 score 값을 보내기
        //    stream.SendNext(score);
        //}
        //else
        //{
        //    // 리모트 오브젝트라면 읽기 부분이 실행됨         

        //    // 네트워크를 통해 score 값 받기
        //    score = (int)stream.ReceiveNext();
        //    // 동기화하여 받은 점수를 UI로 표시
        //    UIManager.instance.UpdateScoreText(score);
        //}
    }
    //} IPunObservable

    // 룸을 나갈때 자동 실행되는 메서드
    public override void OnLeftRoom()
    {
        // 룸을 나가면 로비 씬으로 돌아감
        SceneManager.LoadScene("TitleScene");
    }
}
