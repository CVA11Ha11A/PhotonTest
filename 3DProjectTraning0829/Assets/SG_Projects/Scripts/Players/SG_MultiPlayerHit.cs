using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SG_MultiPlayerHit : MonoBehaviour
{


    public void PlayerHitMe(float enemyDamage, float myHp)
    {
        SG_MultiPlayserOnClick playerClickClass = this.GetComponent<SG_MultiPlayserOnClick>();
        myHp = myHp - enemyDamage;
        Debug.LogFormat("�°��� ä�� -> {0}", myHp);
        playerClickClass.isEndAttack = true;
    }

}
