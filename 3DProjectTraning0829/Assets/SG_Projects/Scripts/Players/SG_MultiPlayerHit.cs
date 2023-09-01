using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using Photon.Pun;

public class SG_MultiPlayerHit : MonoBehaviourPun
{
    public float playerHp = 100;
    public float playerDamage = 20;

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
    }

}
