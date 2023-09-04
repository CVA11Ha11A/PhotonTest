using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_PlayerPunchJudgment : MonoBehaviourPun
{
    Collider[] judgmentColliders;
    public GameObject myPlayer;

    public GameObject fist;

    public bool oneTimeCall = false;

    // Start is called before the first frame update
    void Start()
    {

    }
   

    void Update()
    {
        if (photonView.IsMine && oneTimeCall == false && fist.activeSelf == true)
        {
            oneTimeCall = true;
            photonView.RPC("IsPunch", RpcTarget.MasterClient);
            //Debug.Log("함수가실행되나?");
            //Debug.LogFormat("Collider -> {0} isNull? -> {1}", judgmentColliders, judgmentColliders == null);
        }
    }


   
    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        
    }


    [PunRPC]
    public void IsPunch()
    {
        //Debug.Log("함수가실행되나?");
        //Debug.LogFormat("Collider -> {0} isNull? -> {1}", judgmentColliders, judgmentColliders == null);


        judgmentColliders = Physics.OverlapSphere(fist.transform.position, 1f);

        foreach (Collider col in judgmentColliders)
        {
            //Debug.Log("주먹을 휘두를때에 foreach 에 들어오는가?");
            //Debug.LogFormat("name -> {0}, tag -> {1}", col.name, col.tag);
            if (col.gameObject.CompareTag("Player"))
            {
                //Debug.Log("플레이어 인식");

                // TODO : 이곳에 적이 맞는 판정 불러오면 될거같음
                SG_MultiPlayerHit hitClass = col.gameObject.GetComponent<SG_MultiPlayerHit>();
                SG_MultiPlayerHit attackerClass = myPlayer.GetComponent<SG_MultiPlayerHit>();
                hitClass.PlayerHitMe(attackerClass.playerDamage);
                break;

            }
            else if (col.gameObject.CompareTag("Box"))
            {
                HitMe_Box hitBox = FindAnyObjectByType<HitMe_Box>();

                hitBox.BoxHit();
            }
            else { /*PASS*/ }

        }
        judgmentColliders = null;
        photonView.RPC("ActiveFist", RpcTarget.All);
                
    }

    [PunRPC]
    public void ActiveFist()
    {
        fist.gameObject.SetActive(false);
        oneTimeCall = false;
    }
}
