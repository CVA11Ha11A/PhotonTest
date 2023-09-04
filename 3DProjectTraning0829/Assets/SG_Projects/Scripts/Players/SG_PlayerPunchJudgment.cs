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
            //Debug.Log("�Լ�������ǳ�?");
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
        //Debug.Log("�Լ�������ǳ�?");
        //Debug.LogFormat("Collider -> {0} isNull? -> {1}", judgmentColliders, judgmentColliders == null);


        judgmentColliders = Physics.OverlapSphere(fist.transform.position, 1f);

        foreach (Collider col in judgmentColliders)
        {
            //Debug.Log("�ָ��� �ֵθ����� foreach �� �����°�?");
            //Debug.LogFormat("name -> {0}, tag -> {1}", col.name, col.tag);
            if (col.gameObject.CompareTag("Player"))
            {
                //Debug.Log("�÷��̾� �ν�");

                // TODO : �̰��� ���� �´� ���� �ҷ����� �ɰŰ���
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
