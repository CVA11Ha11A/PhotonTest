using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_MultiPlayserStat : MonoBehaviour
{
    public float playerHp = 100;
    public float playerDamage = 20;

    private void Update()
    {
        if(playerHp <= 0)
        {
            Debug.Log("Ã¼·Â 0");
        }
    }
}
