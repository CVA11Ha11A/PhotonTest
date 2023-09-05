using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UIElements;

public class Item : MonoBehaviourPun
{
    public float healHP;   
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.name == "HpPotion")
            {
                
            }
        }
        else { /*PASS*/ }
    }


}
