using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject cameraMove;
    public GameManager gameManager;

    Vector3 StartCamPos;
    GlobalParms parms;

    GameObject objPool;

    // Start is called before the first frame update
    void Start()
    {
        parms = gameManager.GetComponent<GlobalParms>();
        StartCamPos = new Vector3(0.0f, 0.98f, -9.38f);
        
    }
    public void StartGame()
    {
        parms.ISDEAD = false;
        cameraMove.GetComponent<MoveCamera>().enabled = true;

        var temp = Instantiate(gameObject);
        temp.name = "objectPool";
        objPool = temp;
    }

    public void ResetGame()
    {
        Destroy(objPool);
        gameManager.GetComponent<ScoreManager>().SetScore(0);
        var temp = Instantiate(gameObject);
        temp.name = "objectPool";
        objPool = temp;
        //cameraMove.transform.position = StartCamPos;
        cameraMove.GetComponent<MoveCamera>().Reset();
        parms.ISDEAD = false;
    }

    public void QuitGame()
    {
        
    }
}
