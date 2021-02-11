using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : BaseClass
{

   
    private Animator anim; 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log("Health: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            
            anim.SetTrigger("death");
            
        }
    }


}
