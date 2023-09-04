using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SG_MultiPlayerHPBar : MonoBehaviourPun
{
    public GameObject player;
    public Image redBar;
    SG_MultiPlayerHit playerHitClass;

    private void Awake()
    {
        redBar = GetComponent<Image>();
        playerHitClass = player.GetComponent<SG_MultiPlayerHit>();
    }
    void Start()
    {
        playerHitClass.hpbarEvent += ChangedHP;
    }
    

    [PunRPC]
    public void ChangedHP()
    {
        Debug.Log("이벤트가 발생해서 HP가 바뀌는 표시가 잘되었나?");
        redBar.fillAmount = playerHitClass.playerHp * 0.01f;
    }
}



