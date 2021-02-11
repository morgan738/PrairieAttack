using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    GameObject player;
    public Image black;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("protag");
        gameOver();
    }

    public void gameOver(){
        
        if(player == null){
            anim.SetBool("fade", true);
            //yield return new WaitUntil (() => black.color.a==1);
            SceneManager.LoadScene("GameOver");

        }

    }
}
