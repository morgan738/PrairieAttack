﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public string NewGameScene;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGameButton(){
        SceneManager.LoadScene(NewGameScene);
    }
}
