using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shootable : MonoBehaviour
{
     public bool smthOld, ninetiesOne;
     private bool alreadyShot = false;
     //walls and shit can have this toogled off
     public bool validHit = true;
     
     private EventSystem.MissonNames currentMission;
     void Start(){
        EventSystem.singletonInstance.somethingOld += setSomethingOld;
     }

    void setSomethingOld(){
        currentMission = EventSystem.MissonNames.SomethingOld;
    }

    public void gotShot(){
        if (!alreadyShot && validHit){
            EventSystem.singletonInstance.ValidHit(correctShot());
        }
    }
     
     bool correctShot(){

        switch (currentMission){
            case (EventSystem.MissonNames.SomethingOld):
                return smthOld; 
            case (EventSystem.MissonNames.SuchA90sKid):
                return ninetiesOne;
            default: return false;
        }
    }
}
