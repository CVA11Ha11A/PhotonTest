using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // �ݶ��̴����� �ε����� ����� �ƴϱ⶧���� �ʿ� X
            //HitMe_Box hitBox = GetComponent<HitMe_Box>();
            //hitBox.BoxHit();
        }
    }
}
