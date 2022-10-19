using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLauncher : MonoBehaviour
{

    public List<GameObject> objectsPool;
    public float timeToLaunch = 3.0f;
    public float launchStrength = 10.0f;

    Vector2 force;

    public ScoreManager score;
    GlobalParms parms;

    public float timerDelay = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        force = new Vector2(0.0f, launchStrength);
        score.GetComponent<ScoreManager>();

        GameObject temp = GameObject.Find("GameManager");
        parms = temp.GetComponent<GlobalParms>();

    }

    // Update is called once per frame
    void Update()
    {
        if (parms.GetStaus() == false)
        {
            timerDelay -= Time.deltaTime;

            if (timerDelay <= 0)
            {
                LaunchObject();
                timerDelay = timeToLaunch;
                score.UpScore();
            }
        }
    }

    void LaunchObject()
    {
        int num = 0;
        num = Random.Range(0, objectsPool.Count);
 
        var instance = Instantiate(objectsPool[num], transform.position, transform.rotation);
        instance.transform.parent = GameObject.Find("objectPool").transform;
        instance.GetComponent<Rigidbody2D>().AddForce(transform.up * launchStrength, ForceMode2D.Impulse);



        Debug.Log(num + " Object has Launched");
    }

}
