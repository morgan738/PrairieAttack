using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Animator anim;
    public float attackTime;
    public float startTimeAttack;

    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;
    private Component getHealth;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if( attackTime <= 0 )
        {
            if( Input.GetButton("Fire1"))
            {
                anim.SetBool("isAttacking", true);
                Collider2D[] damage = Physics2D.OverlapCircleAll( attackLocation.position, attackRange, enemies );

                for (int i = 0; i < damage.Length; i++)
                {
                    
                    Destroy( damage[i].gameObject);
                    ScoreScript.scoreValue += 1; 
                }
                Debug.Log("attack");
            }
            attackTime = startTimeAttack;
        }   else
        {
            attackTime -= Time.deltaTime;
            anim.SetBool("isAttacking", false);
        }
        
    }
}
