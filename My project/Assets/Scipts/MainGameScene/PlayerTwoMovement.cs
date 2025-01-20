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
        Debug.Log("Horizontal Axis value " + Input.GetAxis("Horizontal"));
        Debug.Log("Axis value " + Input.GetAxis("Vertical"));
        Debug.Log("Player rotation " + PlayerHand.transform.rotation.x + " " + PlayerHand.transform.rotation.y + " " + PlayerHand.transform.rotation.z);

        //movement
        PlayerHand.transform.position = new Vector3(PlayerHand.transform.rotation.y * PlayerHand.transform.position.x+ Input.GetAxis("Vertical") * moveHorizontalSpeed,0,0);
        //tank control
        PlayerHand.transform.Rotate(PlayerHand.transform.rotation.x, Input.GetAxis("Horizontal")*turnSpeed, PlayerHand.transform.rotation.z);
        Debug.Log("Corrected value " + (Input.GetAxis("Horizontal")*turnSpeed));
    }
}
