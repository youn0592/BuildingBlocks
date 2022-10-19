using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilObj : MonoBehaviour
{
    CircleCollider2D radius;
    List<GameObject> KillList;

 void Start()
    {
        radius = GetComponent<CircleCollider2D>();
        radius.enabled = true;

        KillList = new List<GameObject>();
    }

    public void DestoryObjs()
    {
        for(int i = 0; i < KillList.Count; i++)
        {
            if (KillList[i].tag == "Bomb")
            {
                KillList[i].GetComponent<Explode>().DoExplode();
            }
            else
            {
                KillList[i].GetComponent<Destroy>().KillExplode();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Object" || collision.tag == "Bomb")
        {
            KillList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Object" || collision.tag == "Bomb")
        {
            KillList.Remove(collision.gameObject);
        }    
    }
}
