using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxHP : MonoBehaviour
{
    public float boxHp = 20f;

    private void Update()
    {
        if(boxHp <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
