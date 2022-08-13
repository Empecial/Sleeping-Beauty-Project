using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int PlayerHealth = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (PlayerHealth >= 3)
        {
            PlayerHealth = 0;
        }
    }
	public void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.name == "SkullAttack(Clone)")
        {
            PlayerHealth++;
        }
	}

}
