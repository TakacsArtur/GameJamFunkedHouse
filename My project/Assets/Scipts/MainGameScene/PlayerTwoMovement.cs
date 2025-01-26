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
    void Start()
    {
        PlayerHand = GameObject.Find(playerHandName);
    }

    // Update is called once per frame
    void Update()
    {
        
        Rigidbody rb = PlayerHand.GetComponent<Rigidbody>();
        float currentRotation;
        /*
        if (PlayerHand.transform.localRotation.eulerAngles.y <= 180)
            currentRotation = PlayerHand.transform.eulerAngles.y;
        else
            currentRotation = PlayerHand.transform.eulerAngles.y - 360f;
        */
        //movement
        rb.MovePosition(rb.position + PlayerHand.transform.right * Input.GetAxis("Vertical") * Time.deltaTime * moveHorizontalSpeed);

        //tank control
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0));
        


    }
}
