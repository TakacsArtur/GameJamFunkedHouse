using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Light_Movement_Logog : MonoBehaviour
{
    Rigidbody MovingLight;
    // Start is called before the first frame update
    void Start()
    {
        MovingLight = GameObject.Find("Spot Light_1").GetComponent<Rigidbody>();
        StartCoroutine(LoadnextScene());
    }

    // Update is called once per frame
    void Update()
    {
        MovingLight.AddForce(0, 19, 0);
        //Yeah this should not be here, but it is here anyway.
        if(Input.anyKey)
            SceneManager.LoadScene("MainGamePlayScene");
    }

    private IEnumerator LoadnextScene()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene("MainGamePlayScene");
    }

    
    
}
