 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D myRigidBody;

    private Vector2 direction;

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void FixedUpdate()
    {
        myRigidBody.velocity = direction * speed;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
