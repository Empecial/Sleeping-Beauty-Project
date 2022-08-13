using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI DisplayText;
    public string[] sentences;
    private int index;
    public float Speed;
    [SerializeField]
    bool IsTalking, WritingText,Choice,input1,input2,input3,input4 = false;

    [SerializeField]
    private Tilemap DialogueBox;

    private GameObject Player;

    public PlayerMovement movementRef;


    private void Start()
    {
        Player = gameObject;

        Debug.Log(sentences[1]);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "npc" && !IsTalking) 
        {
            StartCoroutine(DialogueString());
            DialogueBackground();

            movementRef.moveSpeed = 0;

            IsTalking = true;
            Debug.Log("nice");
        }
    }
  
    


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsTalking)
        {
            StartCoroutine(NextSentence());
        }
    }


    private IEnumerator DialogueString()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            DisplayText.text += letter;
            yield return new WaitForSeconds(Speed);
        }
    }

    IEnumerator NextSentence()
    {
        if (index < sentences.Length -1 )
        {
            index++;
            DisplayText.text = "";
            StartCoroutine(DialogueString());
        }
        else
        {
            DisplayText.text = "";
            IsTalking = false;
            movementRef.moveSpeed = 5;

        }
        yield return new WaitForSeconds(5);
    }

    void DialogueBackground()
    {
        DialogueBox.gameObject.SetActive(true);

        DialogueBox.transform.position = new Vector2(Player.transform.position.x + 10, Player.transform.position.y + 1);

    }


    void DialogueChoices()
    {
        while (Choice)
        {



            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                index = 1;
                StartCoroutine(DialogueString());

                Choice = false;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                index = 10;
                StartCoroutine(DialogueString());

                Choice = false;

                

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Choice = false;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Choice = false;

            }

        }

    }

}
