using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAttackAfterTime : MonoBehaviour
{
    
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }
}
