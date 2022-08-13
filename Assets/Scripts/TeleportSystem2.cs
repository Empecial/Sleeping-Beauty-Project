using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSystem2 : MonoBehaviour
{

    [SerializeField]
    GameObject Player, CastleOutside, CastleOutsideHidden, CastleInside, CastleInsideHidden;

    [SerializeField]
    bool KeyAvailable;

    public dialogue2 DialogueRef;

    // Start is called before the first frame update
    void Start()
    {
        DialogueRef = gameObject.GetComponent<dialogue2>();
    }




    // Update is called once per frame
    void Update()
    {
        KeyAvailable = DialogueRef.KeyAcquired;
        

        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == CastleInside)
        {
            Player.transform.position = new Vector2(CastleOutside.transform.position.x, CastleOutside.transform.position.y - 1);
        }

        if (collision.gameObject == CastleOutside)
        {
            Player.transform.position = new Vector2(CastleInside.transform.position.x, CastleInside.transform.position.y + 1);
            Debug.Log("outside");
        }

        if (collision.gameObject == CastleOutsideHidden && KeyAvailable)
        {
            Player.transform.position = new Vector2(CastleInsideHidden.transform.position.x, CastleInsideHidden.transform.position.y + 1);
            Debug.Log("Hidden outside");
        }
        else if (collision.gameObject == CastleOutsideHidden && !KeyAvailable)
        {
            DialogueRef.DisplayText.text = "I need the key";
            DialogueRef.DialogueBackground();
            DialogueRef.StartCoroutine(DialogueRef.RemoveDialogueBackground2(1));

        }

        if (collision.gameObject == CastleInsideHidden)
        {
            Player.transform.position = new Vector2(CastleOutsideHidden.transform.position.x, CastleOutsideHidden.transform.position.y-1);
            Debug.Log("Hidden inside");
        }
    }
}
