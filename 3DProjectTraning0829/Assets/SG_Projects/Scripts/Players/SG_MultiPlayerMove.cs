using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SG_MultiPlayerMove : MonoBehaviourPun
{

    private Rigidbody rigid;
    private BoxCollider boxCollider;
    private Animator animator;
    private Collider[] judgmentColliders;
    private bool isJump = false;


    private Vector3 jumpForce;
    private Vector3 leftRotaition;

    private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        jumpForce = new Vector3(0f, 5f, 0f);      

        //Gizmos.color = Color.red; // ������� ���� ����

        //// ���� ��ũ��Ʈ�� �پ� �ִ� ���� ������Ʈ�� ��ġ�� �������� ����� ǥ��
        //Gizmos.DrawWireSphere(transform.position, 5f); // ���� ����� ǥ��
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        Movement();
        Jump();       
    }

    private void Movement()
    {

        // ������ ó��
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        //Debug.Log(verticalInput);
        animator.SetFloat("MoveZ", verticalInput);
        animator.SetFloat("MoveX", horizontalInput);


        // ���콺 �¿� �����Ͻ� Rotaition �ٲپ��ִ� ����
        float mouseX = Input.GetAxis("Mouse X");
        if (Mathf.Abs(mouseX) > 0.1f || Mathf.Abs(mouseX) < 0.1f)
        {
            // ȸ�� ������ ����Ͽ� ����
            Vector3 newRotation = transform.eulerAngles + new Vector3(0f, mouseX * 2.5f, 0f);
            transform.eulerAngles = newRotation;
        }
        // ���콺 �¿� �����Ͻ� Rotaition �ٲپ��ִ� ����
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            rigid.AddForce(jumpForce, ForceMode.Impulse);
            isJump = true;
            animator.Play("Jump");
        }
    }

   



    private void OnCollisionEnter(Collision collision)
    {
        if (isJump == true)
        {
            isJump = false;
            animator.SetBool("JumpBool", isJump);
        }
    }











    #region LEGACY MOVE
    //private void FowardMove()
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        keyW = true;
    //        animator.SetBool("FowardRunBool", keyW);
    //    }
    //    else { /*PASS*/ }
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        keyW = true;
    //        rigid.velocity += Vector3.forward * (moveSpeed * Time.deltaTime);
    //    }
    //    else { /*PASS*/ }
    //    if(Input.GetKeyUp(KeyCode.W))
    //    {
    //        keyW = false;
    //        animator.SetBool("FowardRunBool", keyW);
    //    }            
    //}

    //private void BackMove()
    //{
    //    if(Input.GetKeyDown(KeyCode.S))
    //    {
    //        keyS = true;
    //        animator.SetBool("BackFowardRunBool", keyS);
    //    }
    //    else { /*PASS*/ }
    //    if(Input.GetKey(KeyCode.S))
    //    {
    //        keyS = true;
    //        rigid.velocity += Vector3.back * (15 * Time.deltaTime);
    //    }
    //    else { /*PASS*/ }
    //    if(Input.GetKeyUp(KeyCode.S))
    //    {
    //        keyS = false;
    //        animator.SetBool("BackFowardRunBool", keyS);
    //    }
    //}
    //private void LeftRotaition()
    //{
    //    if(Input.GetKey(KeyCode.A))
    //    {


    //    }
    //}

    //private void RightRotaition()
    //{

    //}

    //private void Jump()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
    //    {
    //        rigid.AddForce(jumpForce, ForceMode.Impulse);
    //        isJump = true;
    //        animator.Play("Jump");
    //    }
    //}
    #endregion LEGACY MOVE

    //  LEGACY Attack
    //void ExplosionDamage(Vector3 center, float radius)
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(center, radius);



    //    foreach (var hitCollider in hitColliders)
    //    {
    //        Debug.Log("���� �ݰ濡 ����");
    //        //hitCollider.SendMessage("");
    //    }
    //}
    //  LEGACY





}   //NAMESPACE


