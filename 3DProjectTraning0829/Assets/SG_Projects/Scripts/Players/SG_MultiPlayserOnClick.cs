using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

    public class SG_MultiPlayserOnClick : MonoBehaviourPunCallbacks
{
    Animator animator;
    Rigidbody rigid;
    private Coroutine coroutine;
    private WaitForSeconds waitForSeconds;

    public GameObject punchObj;

    public bool isEndAttack = false;
    public bool isPunch = false;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        punchObj.SetActive(false);
        waitForSeconds = new WaitForSeconds(0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            Attack();

            if (isEndAttack == true)
            {
                isEndAttack = false;
            }
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isEndAttack == false && punchObj.activeSelf == false && isPunch == false)    // TODO : 공격 쿨타임 같은거 조건으로 넣어주면 될거같음
            {

                //Debug.Log("펀치 오브젝트 켜기 실행");
                isEndAttack = true;
                isPunch = true;
                animator.SetBool("IsPunch", isPunch);
                punchObj.SetActive(true);
                coroutine = StartCoroutine(AttackTime());

            }
        }
    }

    private IEnumerator AttackTime()
    {
        yield return waitForSeconds;
        isPunch = false;
        animator.SetBool("IsPunch", isPunch);
    }
}   //NameSpace
