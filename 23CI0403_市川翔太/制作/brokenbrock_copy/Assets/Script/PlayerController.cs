using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 mousepos,worldpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousepos=Input.mousePosition;
        worldpos = Camera.main.ScreenToWorldPoint(new Vector3(mousepos.x, 50, 10f));
        if(worldpos.x < -2.3f )
        {
            worldpos.x = -2.3f;
        }
        if(worldpos.x > 2.3f)
        {
            worldpos.x = 2.3f;
        }
        transform.position = worldpos;
    }
}
