using System;
using UnityEngine;
using System.Collections;

public class GroundTile : MonoBehaviour {
    GroundSpawner groundSpawner;
    PlayerMove playerMove;
    float spawnDelay;

     // Start is called before the first frame update
    void Start() {
        playerMove = GameObject.FindObjectOfType<PlayerMove>();
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        spawnDelay = playerMove.getMoveSpeed()*2;
        StartCoroutine(SpawnTileWithDelay(spawnDelay));
    }

    IEnumerator SpawnTileWithDelay(float delay) {
        while (true) {
            yield return new WaitForSeconds(delay);
            groundSpawner.SpawnTile();
            Destroy(gameObject, delay);
        }
    }
}
