using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    Rigidbody MovingLight;
    void Update()
    {
       
        if(Input.anyKey)
            SceneManager.LoadScene("MainGamePlayScene");
    }

    private IEnumerator LoadnextScene()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene("MainGamePlayScene");
    }

    
    
}
