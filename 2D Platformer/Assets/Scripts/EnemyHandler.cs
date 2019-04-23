using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{

    // sets values for raycasting for sight
    public Transform sightStart, sightEnd;

    private float nextActionTime = 0.0f;
    public float period = 1f;

    // bool for detecting if the player is spotted (default is false)
    public bool spotted;

    public GameObject Target { get; set; }

    private Animator myAnimator;

    // sets the game object for the knife prefab
    [SerializeField]
    private GameObject knifePrefab;

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            Raycasting();
        }
       
    }
    

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    void Raycasting()
    {
        // Sees if the enemy spots the player
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);
        spotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
    

        if (spotted == true)
        {
            myAnimator.SetTrigger("throw");
            GameObject tmp = Instantiate(knifePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<Knife>().Initialize(Vector2.left);
        }

    }
    

    //////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {

            myAnimator.SetBool("death", true);
            Destroy(gameObject, 0.5f);
        }

    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    
   


}