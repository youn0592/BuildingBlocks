using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    public List<GameObject> debris;
    public float destroyStrength = 2.0f;
    public float timer = 4.0f;

    public GameObject explosion;

    float numOfObjs = 1;
    Vector2 objCheck;
    KilObj destroyObj;
    Animator anim;
    BoxCollider2D collision;

    bool startTimer = false;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = gameObject.transform.GetChild(0).gameObject;
        destroyObj = temp.GetComponent<KilObj>();
        anim = GetComponent<Animator>(); 
        collision = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        numOfObjs = transform.lossyScale.y * 2;
        objCheck = transform.position;
        objCheck.y = numOfObjs;

        if (startTimer == true)
        {
            timer -= Time.deltaTime;

            if (timer <= 2.0f)
            {
                anim.enabled = true;
            }

            if (timer <= 0.0f)
            {
                timer = 0.0f;
                destroyObj.DestoryObjs();
                DoExplode();
            }
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (startTimer == false)
        {
            startTimer = true;
        }
    }

    public void DoExplode()
    {
        for (int i = 0; i < debris.Count; i++)
        {
            int numX = Random.Range(-5, 5);
            int numY = Random.Range(1, 5);
            Vector3 force = new Vector3(numX * destroyStrength, numY * destroyStrength, 0);
            var Instance = Instantiate(debris[i], transform.position, transform.rotation);
            Instance.GetComponent<Rigidbody2D>().AddForce(transform.up + force, ForceMode2D.Impulse);
        }

        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(this.gameObject);
    }
}
