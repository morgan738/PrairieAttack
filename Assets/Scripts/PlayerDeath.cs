using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDeath : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private bool isDying;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        source = GetComponent<AudioSource>();
    }

    void Awake(){
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.name == "enemy(Clone)" && !isDying)
        {
            isDying = true;
            Debug.Log("death");
            anim.SetBool("isRunning", false);
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            source.Play();
            
            anim.SetTrigger("death");
            Destroy(this.gameObject, 2.0f);
            
            

     
        }
    }


}
