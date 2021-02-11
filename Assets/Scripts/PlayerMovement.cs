using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask layerMask;
    public float moveSpeed;
    private bool facingRight = true;
    private float moveDirection;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Awake(){
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets input (left, right; a or d. becuase of Horizontal key word)
        moveDirection = Input.GetAxis("Horizontal");

        //checks to see if character is on the gorund. if they are, they have the ability to jump
        //Input.GetKeyDown(KeyCode.Space)
        if((isGrounded() && Input.GetKeyDown(KeyCode.W)) || (isGrounded() && Input.GetKeyDown(KeyCode.UpArrow) )){
            float jumpVelocity = 150f;
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
            anim.SetBool("isRunning", false);
            //anim.SetTrigger("attack");
        }

        //flips the character to face the direction they are moving
        if(moveDirection > 0 && !facingRight){
            flipCharacter();
            //anim.SetBool("isRunning", true);
        }else if(moveDirection < 0 && facingRight){
            flipCharacter();
            //anim.SetBool("isRunning", true);
        }

        //moves the character based on speed and velocity
        rigidbody2D.velocity = new Vector2(moveDirection * moveSpeed, rigidbody2D.velocity.y);
        if(moveDirection != 0){
            anim.SetBool("isRunning", true);
        }else{
            anim.SetBool("isRunning", false);
        }
        
    }

    private bool isGrounded(){
        

        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, layerMask);
        
        return raycastHit2D.collider != null;
        
    }

    private void flipCharacter(){
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


}
