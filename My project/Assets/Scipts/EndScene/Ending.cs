using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    Rigidbody MovingLight;
    private IEnumerator LoadnextScene()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene("MainGamePlayScene");
    }

    
    
}
