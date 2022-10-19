using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCheck : MonoBehaviour
{

    Vector3 cameraPos = new Vector3(0.0f, 0.0f, -9.38f);

    void OnCollisionEnter2D(Collision2D collision)
    {

        if(Camera.main.transform.position.y < transform.position.y)
        {
            Camera.main.GetComponent<MoveCamera>().targetY += 0.3f;
        }
    }
}
