using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.Threading;

public class EventSystem : MonoBehaviour
{
    public static EventSystem singletonInstance;
    

  public enum MissonNames{
        SomethingOld, 
        SuchA90sKid,
    }

    private int missionSuccessItemCnt =0;
    private readonly List<string> startText = new List<string> {"Player one you are the body" , "Player two you are the weapon", "Find objects:"};
            
    private GameObject mainPlayerObject;

    public string canvasName;

    public string playerObjectName;

    public TextMeshProUGUI mainTMP;

    private void Awake(){
        singletonInstance = this;
    }
    //Todo set start text
    void Start(){
         mainPlayerObject = GameObject.Find(playerObjectName);
        
         //for now there are no more requirements
         SomethingOld();        

         mainTMP = GameObject.Find(canvasName).GetComponent<TextMeshProUGUI>(); 

         var temp = CluesList(MissonNames.SomethingOld);   
         startText.AddRange(temp);

         StartCoroutine(delayedText(mainTMP, startText));


    }

    public void missionStart(MissonNames ms){
       switch(ms){
       case MissonNames.SomethingOld:
            missionSuccessItemCnt = 3;
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
    private void End(bool positive){
        if(positive){
            Debug.Log("Win");
            StartCoroutine(delayedStart());
        }
        else{
            Debug.Log("Lose");
            //this should make the player fall through the floor
            mainPlayerObject.GetComponent<Rigidbody>().useGravity = true;
            mainPlayerObject.GetComponent<BoxCollider>().isTrigger = true;
            mainPlayerObject.GetComponent<Rigidbody>().AddForce(0,0,-5000000, ForceMode.Impulse);
            StartCoroutine(delayedEnd());
        }
    }

    IEnumerator delayedText(TextMeshProUGUI tmp, List<String> text){
        foreach (var t in text){
            yield return new WaitForSeconds(2);
            tmp.text = t;
            Debug.Log("Wrote text to screen");        
        }
        tmp.text = "";
        
    }

    IEnumerator delayedStart(){
        yield return new WaitForSeconds(1);
        LoadScene("EndScreen");

    } 

    IEnumerator delayedEnd(){
        yield return new WaitForSeconds(6);
        LoadScene("MainGamePlayScene");

    } 

    public void LoadScene(String name){
        //This wouldn't work in release
        SceneManager.LoadScene(name);
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
