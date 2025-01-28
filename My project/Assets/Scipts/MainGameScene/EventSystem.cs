using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSystem : MonoBehaviour
{
    public static EventSystem singletonInstance;
    

  public enum MissonNames{
        SomethingOld, 
        SuchA90sKid
    }

    private int missionSuccessItemCnt =0;
    private GameObject mainPlayerObject;

    public string playerObjectName;

    private void Awake(){
        singletonInstance = this;
    }
    //Todo set start text
    void Start(){
         mainPlayerObject = GameObject.Find(playerObjectName);

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
        Debug.Log("HitCnt " + missionSuccessItemCnt);
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
        Debug.Log("According to the item, the hit was " + itIsGood);
        if(itIsGood){
            
            missionSuccessItemCnt-=1;
            Debug.Log("Good hit");
            
            if(missionSuccessItemCnt<=0){
                End(true);
            }
        }
        if(!itIsGood)
        {
            End(false);
            Debug.Log("Tough luck");
        }
        
    }
    //todo real fail and win states
    private void End(bool positive){
        if(positive)
            Debug.Log("Win");
        else{
            Debug.Log("Lose");
            //this should make the player fall through the floor
            mainPlayerObject.GetComponent<Rigidbody>().useGravity = true;
            mainPlayerObject.GetComponent<BoxCollider>().isTrigger = true;
            mainPlayerObject.GetComponent<Rigidbody>().AddForce(0,0,-5000000, ForceMode.Impulse);
            StartCoroutine(delayedStart());
        }
    }

    IEnumerator delayedStart(){
        yield return new WaitForSeconds(6);
        resetGame(MissonNames.SomethingOld);

    } 

    public void resetGame(MissonNames mn){
        //This wouldn't work in release
        SceneManager.LoadScene("MainGamePlayScene");
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
