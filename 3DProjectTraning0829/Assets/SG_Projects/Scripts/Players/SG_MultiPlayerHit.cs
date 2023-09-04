using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using Photon.Pun;
using System;

public class SG_MultiPlayerHit : MonoBehaviourPun
{
    public float playerHp = 100;
    public float playerDamage = 20;

    public event Action hpbarEvent;

    [PunRPC]
    public void PlayerHitMe(float enemyDamage)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            SG_MultiPlayserOnClick playerClickClass = this.GetComponent<SG_MultiPlayserOnClick>();
            playerHp -= enemyDamage;
            //Debug.LogFormat("맞고난후 채력 -> {0}", playerHp);
            playerClickClass.isEndAttack = true;
            photonView.RPC("ApplyUpdatedHp", RpcTarget.Others, playerHp);
            photonView.RPC("PlayerHitMe", RpcTarget.Others, enemyDamage);
        }


        if (playerHp <= 0)
        {
            this.gameObject.SetActive(false);
        }

    }

    [PunRPC]
    public void ApplyUpdatedHp(float nowHp)
    {
        playerHp = nowHp;

        //마스터 클라이언트한테 함수 불러달라고 Call
        photonView.RPC("CallHPEvent", RpcTarget.MasterClient);

    }

    [PunRPC]
    public void CallHPEvent()
    {
        // 이벤트를 발생시킴
        hpbarEvent?.Invoke();
    }

}
