using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public int maxDroplets = 5;
    public Text countText;
    public Text winText;
    public AudioClip pickUpClip;

    AudioSource playerAudio;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }


    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            playerAudio.Play();
            count++;
            SetCountText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Droplets Collected: " + count.ToString() + "/" + maxDroplets;
        if (count >= maxDroplets)
        {
            //Open up panel/window that says:
            winText.text = "All Water Droplets Collected!";
            // and has next level button.
            Time.timeScale = 0;
        }
    }
}
