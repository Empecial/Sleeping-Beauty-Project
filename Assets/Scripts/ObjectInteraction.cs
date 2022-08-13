using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject InteractBridge;

    
    private ObjectPickup InteractionRef;
    private dialogue2 DialogueRef;

    [SerializeField]
    Tilemap bridgeBroken,bridgeFixed;

    [SerializeField]
    bool PlanksAreAvailable,NearBridge,KeyIsAvailable,NearSmallDoor;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        PlanksAreAvailable = gameObject.GetComponent<ObjectPickup>().fsPlanksAcquired;

        if (PlanksAreAvailable && Input.GetKeyDown(KeyCode.E) && NearBridge)
        {
            bridgeBroken.gameObject.SetActive(false);
            bridgeFixed.gameObject.SetActive(true);
            InteractBridge.gameObject.SetActive(false);
        }

        KeyIsAvailable = gameObject.GetComponent<dialogue2>().KeyAcquired;

        if (KeyIsAvailable && NearSmallDoor && Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Bro gulv")
        {
            NearBridge = true;
            Debug.Log("near bridge");
        }

        if (collision.name =="")
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Bro gulv")
        {
            NearBridge = false;
            Debug.Log("near not bridge");
           
        }
    }

}
