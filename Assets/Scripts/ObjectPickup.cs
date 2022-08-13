using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
        public bool fsPickUpFlint, fsPickUpPlanks,fsFlintAcquired, fsPlanksAcquired = false;

        [SerializeField]
        private GameObject flintAndSteel, Planks;

    private void Update()
    {
       if (fsPickUpFlint && Input.GetKeyDown(KeyCode.E))
		{
			Destroy(flintAndSteel);
            fsFlintAcquired = true;
            Debug.Log("Flint acquired");
		}
        
       if (fsPickUpPlanks && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(Planks);
            fsPlanksAcquired = true;
            Debug.Log("Planks acquired");
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == flintAndSteel)
        {
            fsPickUpFlint = true;
        }
        else
        {
            fsPickUpFlint = false;
        }
        

        if (collision.gameObject==Planks)
        {
            fsPickUpPlanks = true;
        }
        else
        {
            fsPickUpPlanks = false;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == flintAndSteel)
        {
            fsPickUpFlint = false;
        }

        if (collision.gameObject==Planks)
        {
            fsPickUpPlanks = false;
        }


    }


}



