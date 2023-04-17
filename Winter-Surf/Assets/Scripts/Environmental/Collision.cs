using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{   
    public GameObject thePlayer;
    public GameObject playerChild;
    public GameObject mainCamera;

    void OnTriggerEnter(Collider e) {

        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        // Animator playerAnimator = playerChild.GetComponent<Animator>();
        playerChild.GetComponent<Animator>().Play("Stumble Backwards");
        mainCamera.GetComponent<Animator>().enabled = true;
        print("COLLISION");


    }
}
