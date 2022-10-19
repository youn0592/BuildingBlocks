using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTrigger : MonoBehaviour
{

    GlobalParms parms;

    public GameObject GameOverUI;
    public GameObject HUD;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Temp = GameObject.Find("GameManager");
        parms = Temp.GetComponent<GlobalParms>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag != "Debris")
        {
            parms.ISDEAD = true;

            GameOverUI.SetActive(true);
            HUD.SetActive(false);

            Debug.Log("You Have Died");
        }
    }
}
