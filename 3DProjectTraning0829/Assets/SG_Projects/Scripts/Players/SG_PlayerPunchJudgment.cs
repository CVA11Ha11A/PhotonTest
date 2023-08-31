using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_PlayerPunchJudgment : MonoBehaviour
{    
    Collider[] judgmentColliders;
    public GameObject myPlayer;

    // Start is called before the first frame update
    void Start()
    {

  
    }

    // Update is called once per frame
    void Update()
    {
    }

 


    private void OnEnable()
    {
        Debug.Log("�ָ�Obj OnEnable ����");
        judgmentColliders = Physics.OverlapSphere(this.transform.position, 1f);

        foreach (Collider col in judgmentColliders)
        {
            Debug.Log("�ָ��� �ֵθ����� foreach �� �����°�?");
            Debug.LogFormat("name -> {0}, tag -> {1}", col.name, col.tag);
            if (col.gameObject.CompareTag("Player"))
            {
                Debug.Log("�÷��̾� �ν�");

                // TODO : �̰��� ���� �´� ���� �ҷ����� �ɰŰ���
                SG_MultiPlayerHit hitClass = col.gameObject.GetComponent<SG_MultiPlayerHit>();
                SG_MultiPlayserStat hitHp = col.gameObject.GetComponent<SG_MultiPlayserStat>();
                SG_MultiPlayserStat attackerClass = myPlayer.GetComponent<SG_MultiPlayserStat>();
                Debug.LogFormat("hitClass �޾ƿ�? -> {0}", hitClass != null);
                Debug.LogFormat("hitHp �޾ƿ�? -> {0}", hitHp != null);
                Debug.LogFormat("attackerClass �޾ƿ�? -> {0}", attackerClass != null);
                hitClass.PlayerHitMe(attackerClass.playerDamage, hitHp.playerHp);
                break;

            }
            else if(col.gameObject.CompareTag("Box"))
            {
                HitMe_Box hitBox = FindAnyObjectByType<HitMe_Box>();

                hitBox.BoxHit();
            }
            else { /*PASS*/ }

        }
        judgmentColliders = null;
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        
    }
}
