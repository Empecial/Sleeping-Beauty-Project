using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    /* denne kode var lavet med inspiration fra: https://www.youtube.com/watch?v=whzomFgjT50&t=1201s&ab_channel=Brackeys 
     * og https://www.youtube.com/watch?v=fRpoE4FfJf8&ab_channel=JTAGames*/


    [SerializeField]
    AudioClip GrassWalkingSound;

    public float moveSpeed = 3f;

    [SerializeField]
    private Rigidbody2D rb;

    Vector2 movement;

    [SerializeField]
    Animator MoveAnimation;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        MoveAnimation.SetFloat("Horizontal", movement.x);
        MoveAnimation.SetFloat("Vertical", movement.y);
        MoveAnimation.SetFloat("Speed", movement.sqrMagnitude);

        Orientation();
    }

    void Orientation()
    {
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            MoveAnimation.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            MoveAnimation.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }
    }

    /*void Interaction()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 90);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, -90);
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }*/

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+movement.normalized*moveSpeed*Time.fixedDeltaTime);
    }


    void GrassWalking()
    {
        


    }

}
