using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool top;
    private Player player;

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.gravityScale *= -1;
            Rotation();
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "KillZone" && rb.gravityScale != 1)
        {
            rb.gravityScale = 1;
            Rotation();
        }

        if(other.tag == "Knife" && rb.gravityScale != 1)
        {
            rb.gravityScale = 1;
            Rotation();
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    // roates the player model when the gravity is reversed 
    void Rotation()
    {
        // if top is false, do this
        if(top == false)
        {
            // rotates player model
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        // else do this
        else
        {
            // puts the player model back to the original rotation
            transform.eulerAngles = Vector3.zero;
        }

        // player facing right is equal to player not facing right
        player.facingRight = !player.facingRight;
        // top is equal to not top
        top = !top;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

}
