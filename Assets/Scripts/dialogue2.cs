using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class dialogue2 : MonoBehaviour
{
    public TextMeshProUGUI DisplayText;

    [SerializeField]
    private Tilemap DialogueBox;

    [SerializeField]
    private GameObject Player,Wizard;

    [SerializeField]
    Collider2D BeforeBossCol;

    public PlayerMovement movementRef;

    public bool IsTalking, choice, IsTalkingNPC1, IsTalkingNPC2, IsTalkingNPC3, IsTalkingNPC4, SignRead, CanChoose, BossFightTrigger,BossDefeated,BossFightWonBool,FoundPrincess = false;
    public bool KeyAcquired;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject;

        /*DialogueBackground();
        DisplayText.text = "It's time to earn my place in the knights order,\nand for that i must help out the people of the sapphire kingdom!";

        StartCoroutine(RemoveDialogueBackground2(8));*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //female villager 1
        if (collision.name == "Female villager 1" && !IsTalking)
        {
            IsTalkingNPC1 = true;
        }
        else
        {
            IsTalkingNPC1 = false;
        }

        //sign reading
        if (collision.name == "sign" && !IsTalking)
        {
            SignRead = true;
        }
        else
        {
            SignRead = false;
        }

        //leaving kingdom ending
        if (collision.name== "leave kingdom ending")
        {
            Debug.Log("left kingdom");
        }

        //Boss fight trigger
        if (collision.name== "Boss fight trigger")
        {
            BossFightTrigger = true;
        }

        //finding the princess
        if (collision.name== "gold bed")
        {
            FoundPrincess = true;
        }
    }

    //player reading the sign
    void ReadingSign()
    {
        DialogueBackground();

        DisplayText.text = "Sign reads: Road to the left leads to the ruby kingdom.";

        StartCoroutine(InBetweenDialogue("Going past this point would mean leaving the sapphire kingdom.", 4));

        StartCoroutine(RemoveDialogueBackground2(7));
    }

    //female villager 1 dialogue
    void FemaleVillager1()
    {
        DialogueBackground();

        DisplayText.text = "Ahh!!! Hello! Now who might this man in armor be. I see you have the dark blue colors of the sapphire kingdom on your armor set there!";

        StartCoroutine(InBetweenDialogue("Well yes in that you are not wrong, citizen.\nI do need to ask, could you tell me the name of \nthe village that we find ourselves in at the \nmoment?",4));

        StartCoroutine(InBetweenDialogue("Well how do you not know?... well nevermind that. You currently find yourself to be in the very \nKyanite itself, a small village north of central.", 10));

        StartCoroutine(InBetweenDialogue("Kyanite! really.. But I don't even recognize it in the slightest.. has it really been that long?", 14));

        StartCoroutine(InBetweenDialogue("Sir knight I am sorry to bother your thinking but may i ask your name? if you do not mind, of course.", 18));

        StartCoroutine(InBetweenDialogue("A: Dont tell\nB: Lie\nC: Tell the truth\nD: Leave", 25));


    }
    
    //the dialogue between knight and knight before the fight
    void BossFightBefore()
    {
        DialogueBackground();
        DisplayText.text = "You have finally arrived BROTHER! Dont think you can beat me or even make me change my mind!";

        StartCoroutine(InBetweenDialogue("Brother dont do this, i dont want to fight you", 3));
        StartCoroutine(RemoveDialogueBackground2(5));
    }

    //if knight wins over boss
    void BossFightWon()
    {
        DialogueBackground();
        DisplayText.text = "A: Capture him\nB: Leave him\nC: Kill him";

    }

    //knight finds princess sleeping
    void PrincessDialogue()
    {
        DialogueBackground();
        DisplayText.text = "Who..? Who's there!? Please don’t hurt me! it’s the princess please help me get out of here.";
    }


    //the dialogue that happens between the start and ending text
    IEnumerator InBetweenDialogue(string DialogueBetween, int time)
    {
        yield return new WaitForSeconds(time);

        DisplayText.text = DialogueBetween;
    }


    // Update is called once per frame
    void Update()
    {

        BossDefeated = Wizard.GetComponent<BossMechanic>().BossDefeated;

        //female villager 1
        if (Input.GetKeyDown(KeyCode.E) && IsTalkingNPC1)
        {
            Debug.Log("female villager 1 choice");
            FemaleVillager1();
            CanChoose = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1) && IsTalkingNPC1)
        {
            DisplayText.text = "Well I do not see the importance of such matters as my name. My title as knight should be more than enough!";
            StartCoroutine(InBetweenDialogue("Well alright that’s too bad then, Here I was hoping for one of the Lancelots, but a knight is a knight! " +
                "You should go check out the danger for yourself over by the tower, just cross the bridge and you will be right there!", 5));
            StartCoroutine(RemoveDialogueBackground2(15));
            CanChoose = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && IsTalkingNPC1)
        {
              DisplayText.text = "Well I am sorry to say but i seem to have hit my head earlier, so I can’t seem to remember.";
            StartCoroutine(InBetweenDialogue("Well alright that’s too bad then, Here I was hoping for one of the Lancelots, but a knight is a knight! " +
                "You should go check out the danger for yourself over by the tower, just cross the bridge and you will be right there!", 10));
            StartCoroutine(RemoveDialogueBackground2(16));
            CanChoose = false;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && IsTalkingNPC1)
        {
            DisplayText.text = "Sir Serlo! Is it really you? How long has it been? well nevermind me we do not have time for idle chat." +
                " your brother has gone mad with power! He has kidnapped the princess and is holding her in the lancelot tower. Just east of here!";
            StartCoroutine(InBetweenDialogue("Villager gives the knight a key", 10));
            StartCoroutine(InBetweenDialogue("What is this!?", 13));
            StartCoroutine(InBetweenDialogue("It is a key to a hidden door to the tower. I still had it from when I used to serve the Lacelot family.",17));
            StartCoroutine(InBetweenDialogue("Thank you old friend of my family. I will get going now, stay safe!", 20));
            StartCoroutine(RemoveDialogueBackground2(23));
            KeyAcquired = true;
            CanChoose = false;
            IsTalkingNPC1 = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && IsTalkingNPC1)
        {
            DisplayText.text = "I am sorry madam, but duty calls. Goodbye.";
            StartCoroutine(InBetweenDialogue("Oh okay, goodbye. It was nice to meet you.", 3));
            StartCoroutine(RemoveDialogueBackground2(6));
        }


        //sign reading
        if (Input.GetKeyDown(KeyCode.E) && SignRead)
        {
            ReadingSign();
        }

        //boss fight triggered
        if (BossFightTrigger)
        {
            BossFightTrigger = false;
            BossFightBefore();
            BeforeBossCol.enabled = false;
        }

        //if knight wins over wizard
        if (BossDefeated)
        {
            BossFightWon();
            BossFightWonBool = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisplayText.text = "Brother! your time has come to serve your time for what you have done. You will be coming with me back to the inner kingdom.";
            StartCoroutine(RemoveDialogueBackground2(3));
        }


        //at the princess
        if (FoundPrincess)
        {
            PrincessDialogue();
        }
    }


    public IEnumerator RemoveDialogueBackground2(int time)
    {
        yield return new WaitForSeconds(time);

        DialogueBox.gameObject.SetActive(false);

        DisplayText.text = "";

        movementRef.moveSpeed = 5f;

        CanChoose = false;
    }

    void RemoveDialogueBackground()
    {
        DialogueBox.gameObject.SetActive(false);

        DisplayText.text = "";

        movementRef.moveSpeed = 5f;

    }

    public void DialogueBackground()
    {
        DialogueBox.gameObject.SetActive(true);

        DialogueBox.transform.position = new Vector2(Player.transform.position.x + 10, Player.transform.position.y + 1);

        movementRef.moveSpeed = 0;
    }



}
