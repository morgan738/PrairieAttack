using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    GameObject target; 
    float moveSpeed;
    Vector3 directionToTarget;
    Animator anim;
    private bool facingLeft = true;
    private GameObject _enemy;
    [SerializeField] private LayerMask layerMask;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("protag");
        anim = GetComponent<Animator>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(35f,45f);

        
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacle();
        /* if(directionToTarget != null  ){
            anim.SetBool("isRunning", true);
        }else{
            anim.SetBool("isRunning", false);
        } */

        if(directionToTarget.x < 0 && !facingLeft){
            flipCharacter();
        }else if(directionToTarget.x > 0 && facingLeft){
            flipCharacter();
        }
    }

    void MoveObstacle(){
        
        if(target != null ){
            //moves toward target (which is protag in this case)
            directionToTarget = (target.transform.position - transform.position).normalized;

            //moves towards left
            //directionToTarget = new Vector3(-1.0f, 0.0f, 0.0f);
            if(isGrounded()){
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                rb.velocity = new Vector2 (directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);

            }else{
                rb.velocity = new Vector2 (directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
            }
            /* if(transform.position.x < -120){
                Destroy(this.gameObject);
                ScoreScript.scoreValue += 1; 
        } */

            anim.SetBool("isRunning", true);
            
        }else{
            rb.velocity = Vector3.zero;
            anim.SetBool("isRunning", false);
        }
    }

    private void flipCharacter(){
        facingLeft = !facingLeft;
        transform.Rotate(0f, 180f, 0f);
    }

    private bool isGrounded(){
        

        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, layerMask);
        
        return raycastHit2D.collider != null;
        
    }
}
