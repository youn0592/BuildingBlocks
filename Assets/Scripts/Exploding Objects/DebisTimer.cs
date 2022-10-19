using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebisTimer : MonoBehaviour
{

    public float lifeTime = 3.0f;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

}
