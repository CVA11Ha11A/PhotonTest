using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SG_MultiPlayserOnClick : MonoBehaviourPun
{  
    Animator animator;
    Rigidbody rigid;    

    public GameObject punchObj;

    public bool isEndAttack = false;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        punchObj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        { 
            Attack();

            if (isEndAttack == true)
            {
                punchObj.SetActive(false);
                isEndAttack = false;
            }
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isEndAttack == false)    // TODO : ���� ��Ÿ�� ������ �������� �־��ָ� �ɰŰ���
            {
                isEndAttack = true;
                animator.Play("Punch");

                punchObj.SetActive(true);

            }
        }
    }
  
}
