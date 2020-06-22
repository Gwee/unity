using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    // Update is called once per frame
    float timeLeft;
    Color targetColor;
    void Update()
    {
        // GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); 
        if (timeLeft <= Time.deltaTime) {
            // transition complete
            // assign the target color
            GetComponent<Renderer>().material.color = targetColor;
            // start a new transition
            targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = 1.0f;
        } else {
            // transition in progress
            // calculate interpolated color
            GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, targetColor, Time.deltaTime / timeLeft);
            // update the timer
            timeLeft -= Time.deltaTime;
        }
    }
}
