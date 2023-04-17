using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{   
     void OnTriggerEnter(Collider e) {
        GameObject levelControl = GameController.LEVELCONTROL;
        GameObject thePlayer = PlayerMove.PLAYERINSTANCE;
        GameObject playerChild = PlayerMove.PLAYERCHILDINSTANCE;
        GameObject mainCamera = Camera.main.gameObject;

        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        // Animator playerAnimator = playerChild.GetComponent<Animator>();
        playerChild.GetComponent<Animator>().Play("Stumble Backwards");
        mainCamera.GetComponent<Animator>().enabled = true;
        levelControl.GetComponent<GameOverSequence>().enabled = true;
    }
}
