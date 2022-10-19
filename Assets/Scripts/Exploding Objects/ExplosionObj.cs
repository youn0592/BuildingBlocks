using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObj : MonoBehaviour
{
    public float timer = 1.0f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0.0f)
        {
            Destroy(this, timer);
        }
    }
}
