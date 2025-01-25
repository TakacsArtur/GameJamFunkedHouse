using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRestrict : MonoBehaviour
{
    // Start is called before the first frame update
    public int minX = 50;
    public int maxX = 70;
    public int minY = 60;
    public int maxY = 50;
    private Vector3 mousePos;
    void Start()
    {
        mousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Mouse position " + mousePos);
        mousePos.x = Mathf.Clamp(Input.mousePosition.x, minX, maxX);
        mousePos.y = Mathf.Clamp(Input.mousePosition.y, minY, maxY);
    }

    
}
