using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject lineRender;
    LineRenderer Line;
    Rigidbody2D m_Body;

    GlobalParms parms;

    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        Line = lineRender.GetComponent<LineRenderer>();
        parms = GetComponent<GlobalParms>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parms.GetStaus() == false)
        {
            GrabObject();
        }

            Vector3 tempMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector2(tempMouse.x, tempMouse.y);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void GrabObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.blue);

            if (hit && hit.collider != null)
            {
                if (hit.rigidbody != null)
                {

                    m_Body = hit.rigidbody;
                    Line.enabled = true;
                }
            }                

            
        }

        if(Input.GetMouseButton(0))
        {
            if (m_Body != null)
            {
                Vector2 dir = mousePos - m_Body.position;
                dir *= 2;
                m_Body.velocity = dir;
                Line.SetPosition(0, m_Body.position);
                Line.SetPosition(1, mousePos);
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            m_Body = null;
            Line.enabled = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
