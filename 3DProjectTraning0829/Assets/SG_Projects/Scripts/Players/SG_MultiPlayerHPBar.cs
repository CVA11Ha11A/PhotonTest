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
        Debug.Log("�̺�Ʈ�� �߻��ؼ� HP�� �ٲ�� ǥ�ð� �ߵǾ���?");
        redBar.fillAmount = playerHitClass.playerHp * 0.01f;
    }
}



