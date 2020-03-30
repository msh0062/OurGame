using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float timeLeft = 60f;
    public Text startText;
    public Text loseText;
    PlayerController playerMovement;

    void Awake()
    {
        playerMovement = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = "Time Remaining: " + (timeLeft).ToString("0");

        if (timeLeft <= 0)
        {
            loseText.text = "Game Over!";
            Time.timeScale = 0;
        }
    }
}
