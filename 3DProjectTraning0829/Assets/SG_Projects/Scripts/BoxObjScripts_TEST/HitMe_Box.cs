using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMe_Box : MonoBehaviour
{

    public void BoxHit()
    {
        boxHP boxHp = this.gameObject.GetComponent<boxHP>();
        SG_MultiPlayserStat playerStat = FindAnyObjectByType<SG_MultiPlayserStat>();

        boxHp.boxHp -= playerStat.playerDamage;
        Debug.LogFormat("������ ����� BoxHP -> {0}", boxHp.boxHp);
    }
}
