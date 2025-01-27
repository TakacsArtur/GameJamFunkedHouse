using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shootable : MonoBehaviour
{
     public bool smthOld, ninetiesOne;
     public MissionsEnum missionsEnum;
     void Start(){
        missionsEnum = new MissionsEnum();
     }
     bool correctShot(MissionsEnum.MissonNames name){

        switch (name){
            case (MissionsEnum.MissonNames.SomethingOld):
                return smthOld; 
            case (MissionsEnum.MissonNames.SuchA90sKid):
                return ninetiesOne;
            default: return false;
        }
    }
}
