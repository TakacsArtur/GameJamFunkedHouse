using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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
        float currentRotation;
        if(PlayerHand.transform.localRotation.eulerAngles.y <= 180)
            currentRotation = PlayerHand.transform.eulerAngles.y;
        else
            currentRotation = PlayerHand.transform.eulerAngles.y -360f;

        //movement
        PlayerHand.transform.position += PlayerHand.transform.right*Input.GetAxis("Vertical");
        
        //tank control
        PlayerHand.transform.Rotate(PlayerHand.transform.rotation.x, Input.GetAxis("Horizontal")*turnSpeed, PlayerHand.transform.rotation.z);
    }
}
