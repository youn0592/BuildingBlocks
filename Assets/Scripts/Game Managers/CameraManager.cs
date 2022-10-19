using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    int x;
    int y;

    Vector2 getMidPoi;

    Vector3 cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        x = Screen.width / 2;
        y = Screen.height / 2;

        getMidPoi = new Vector2(x, y);

        cameraPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        CheckForObj();
    }
    
    void CheckForObj()
    {
        RaycastHit2D hit = Physics2D.Raycast(getMidPoi, Vector2.zero);
        if(hit.collider)
        {
            cameraPos.y += 0.5f;
            transform.position = cameraPos;
        }    
    }
}
