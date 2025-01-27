using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public ParticleSystem flash;
    public GameObject impactEff;
    public AudioSource fireSound;
    void Update()
 {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }  
 }

    void Shoot()
    {
        flash.Play();
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            fireSound.Play();
            var hitItem = hit.transform.gameObject;
            Debug.Log(hitItem.name);
            GameObject impact =  Instantiate(impactEff, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f );
        }
    }
}

