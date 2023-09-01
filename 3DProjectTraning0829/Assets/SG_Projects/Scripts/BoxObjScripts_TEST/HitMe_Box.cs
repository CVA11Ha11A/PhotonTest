using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMe_Box : MonoBehaviour
{

    public void BoxHit()
    {
        boxHP boxHp = this.gameObject.GetComponent<boxHP>();
        SG_MultiPlayerHit playerStat = FindAnyObjectByType<SG_MultiPlayerHit>();

        boxHp.boxHp -= playerStat.playerDamage;
        Debug.LogFormat("데미지 계산후 BoxHP -> {0}", boxHp.boxHp);
    }
}
