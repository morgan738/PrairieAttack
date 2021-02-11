using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
/*     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */

     public void doExitGame() {
        //Application is ignored in unity editor. this will only work in a build
        Application.Quit();

        //This will exit if in Unity editor
        UnityEditor.EditorApplication.isPlaying = false;
 }
}
