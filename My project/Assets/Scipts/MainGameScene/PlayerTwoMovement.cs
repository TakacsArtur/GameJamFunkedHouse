using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoMovement : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject PlayerHand;
    public string playerHandName = "Hand_placeholder";
    public int moveHorizontalSpeed = 5;
    public int turnSpeed = 5;
    public AudioSource walkSound;
    void Start()
    {
        PlayerHand = GameObject.Find(playerHandName);
        walkSound = GameObject.Find("WalkSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Rigidbody rb = PlayerHand.GetComponent<Rigidbody>();
    
        //movement
        rb.MovePosition(rb.position + PlayerHand.transform.right * Input.GetAxis("Vertical") * Time.deltaTime * moveHorizontalSpeed);

        //tank control
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0));
        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            walkSound.Play();
        }
        else
        {
            walkSound.Stop();
        }
    }
}
