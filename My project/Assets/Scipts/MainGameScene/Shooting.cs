using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    void Update()
 {
     Vector3 mouse = Input.mousePosition;
     Ray castPoint = Camera.main.ScreenPointToRay(mouse);
     RaycastHit hit;
     if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
     {
          var hitItem = hit.transform.gameObject;
          Debug.Log(hitItem.name);
     }
 }
}

