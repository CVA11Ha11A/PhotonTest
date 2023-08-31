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
        Debug.Log("주먹Obj OnEnable 실행");
        judgmentColliders = Physics.OverlapSphere(this.transform.position, 1f);

        foreach (Collider col in judgmentColliders)
        {
            Debug.Log("주먹을 휘두를때에 foreach 에 들어오는가?");
            Debug.LogFormat("name -> {0}, tag -> {1}", col.name, col.tag);
            if (col.gameObject.CompareTag("Player"))
            {
                Debug.Log("플레이어 인식");

                // TODO : 이곳에 적이 맞는 판정 불러오면 될거같음
                SG_MultiPlayerHit hitClass = col.gameObject.GetComponent<SG_MultiPlayerHit>();
                SG_MultiPlayserStat hitHp = col.gameObject.GetComponent<SG_MultiPlayserStat>();
                SG_MultiPlayserStat attackerClass = myPlayer.GetComponent<SG_MultiPlayserStat>();
                Debug.LogFormat("hitClass 받아옴? -> {0}", hitClass != null);
                Debug.LogFormat("hitHp 받아옴? -> {0}", hitHp != null);
                Debug.LogFormat("attackerClass 받아옴? -> {0}", attackerClass != null);
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
