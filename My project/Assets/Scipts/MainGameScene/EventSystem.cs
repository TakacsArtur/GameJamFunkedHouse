using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem singletonInstance;
    

  public enum MissonNames{
        SomethingOld, 
        SuchA90sKid
    }

    private int missionSuccessItemCnt =0;

    private void Awake(){
        singletonInstance = this;
    }
    //Todo set start text
    void Start(){
         //for now there are no more requirements
         SomethingOld();
    }

    public void missionStart(MissonNames ms){
       switch(ms){
       case MissonNames.SomethingOld:
            missionSuccessItemCnt = 4;
            break;
        }
    }

    public event Action somethingOld;
    public void SomethingOld(){
        if(somethingOld != null){
            somethingOld();
            missionStart(MissonNames.SomethingOld);
        Debug.Log("Something old started");
        }   
    }

    public void SomethingGotShot(GameObject shotObject){
        //as dumb as it is, ALL ITEMS SHOULD HAVE THE SHOOTABLE OBJECT, THAT HAVE COLLSION
        var shootscript = shotObject.GetComponent<Shootable>();
        shootscript.gotShot();
        Debug.Log(shotObject + " got shot");
    }

    public void ValidHit(bool itIsGood){
        //Todo death screen
        if(itIsGood){
            missionSuccessItemCnt --;
            Debug.Log("Good hit");
            if(missionSuccessItemCnt<=0){
                End(true);
            }
        else
            End(false);
            Debug.Log("Tough luck");
        }
    }
    //todo real fail and win states
    private void End(bool positive){
        if(positive)
            Debug.Log("Win");
        else
            Debug.Log("Lose");
    }


    //this COULD be moved to an inner class
      public List<string> CluesList(MissonNames missonNames){
        switch(missonNames){
            case MissonNames.SomethingOld:
                return new List<string> {"Something old" , "Seomething new", "Something borrowed", "Something blue"};
            case MissonNames.SuchA90sKid:
                return new List<string>{"Things that existed in the nineties, but not before"};
            default:
                return new List<string> {"Something old" , "Seomething new", "Something borrowed", "Something blue"};
        }
    }
}
