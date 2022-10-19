using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GlobalParms : MonoBehaviour
{
    public bool ISDEAD = true;

    public int HighScore;

    public bool GetStaus()
    {
        return ISDEAD;
    }
}

