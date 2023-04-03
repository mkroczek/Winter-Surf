using System;
using UnityEngine;
using System.Collections;

public class GroundTile : MonoBehaviour {
    GroundSpawner groundSpawner;
    PlayerMove playerMove;
    // public static GroundTile Instance;

    // void Awake() {
    //     if (Instance == null) {
    //         Instance = this;
    //     } else {
    //         Destroy(gameObject);
    //     }
    // }

     // Start is called before the first frame update
    void Start() {
        playerMove = GameObject.FindObjectOfType<PlayerMove>();
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        StartCoroutine(SpawnTileWithDelay(2));
    }

    IEnumerator SpawnTileWithDelay(float delay) {
        while (true) {
            yield return new WaitForSeconds(delay);
            groundSpawner.SpawnTile();
        }
    }
}
