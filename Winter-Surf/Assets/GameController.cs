using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{   
    // public GameObject terrain;

    public static GameObject LEVELCONTROL;
    // public GameObject PLAYERINSTANCE;
    // public GameObject PLAYERCHILDINSTANCE;

    void Awake()
    {
        LEVELCONTROL = gameObject;
    }
}
