using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnTriggerEnter(Collider e) {
        if (e.gameObject.tag == "Pine") 
        {
            print("COLLISION");
        }

    }
}
