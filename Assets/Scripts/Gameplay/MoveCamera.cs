using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public float targetY = 0;

    // Update is called once per frame
    void Update()
    {
        float temp = Mathf.Lerp(transform.position.y, targetY, Time.deltaTime);
        transform.position = new Vector3(0, temp, -9.38f);
    }

    public void Reset()
    {
        targetY = 0;
    }
}
