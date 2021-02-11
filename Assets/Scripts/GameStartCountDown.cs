using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartCountDown : MonoBehaviour
{
    public Text countdownTextField;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

      IEnumerator CountdownCoroutine() {
        countdownTextField.text = "3";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "2";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "1";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "Go!";
        // start the game here
        
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "";
        yield return null;
    }
}
