using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSytem : MonoBehaviour
{
    [SerializeField]
    private Transform PlayerTransform;
    public Transform TeleportGoal,KeyCastleOutside,KeyCastleInside;
    public bool TeleportPlayer,KeyIsAvailable = false;


    public Collider2D KeyCastleInsideCol;

    void Start()
    {
        
    }

    void Update()
    {
        KeyIsAvailable = gameObject.GetComponent<dialogue2>().KeyAcquired;

        if (TeleportPlayer == true)
        {
            PlayerTransform.position = TeleportGoal.position;
        }

        if (gameObject.name== "CastleInsideHiddenDoor" && KeyIsAvailable)
        {
            PlayerTransform.position = KeyCastleOutside.position;
            Debug.Log("key castle outside");
        }
        
        if (gameObject.name == "CastleOutsideHiddenDoor" && KeyIsAvailable)
        {
            PlayerTransform.transform.position = KeyCastleInside.transform.position;
            KeyCastleInsideCol.enabled = false;
            Debug.Log("key castle inside col disabled");
        }
        else if (gameObject.name == "CastleOutsideHiddenDoor" && !KeyIsAvailable)
        {
            gameObject.GetComponent<dialogue2>().DisplayText.text = "I need the key";
        }

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.name == "Player")
        {
            TeleportPlayer = true;
        }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.name == "Player")
        {
            TeleportPlayer = false;
        }
    }
}
