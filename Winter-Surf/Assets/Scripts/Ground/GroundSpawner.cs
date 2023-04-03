using UnityEngine;

public class GroundSpawner : MonoBehaviour {
    public GameObject groundTile;
    Vector3 nextSpawnPoint; 
    int startingTilesNumber = 1;
    // public static GroundSpawner instance;


    public void SpawnTile(){
        GameObject obj = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = obj.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start(){
        SpawnTile();
    }

    // void Awake() {
    //     if (instance == null) {
    //         instance = this;
    //     } else {
    //         Destroy(gameObject);
    //     }
    // }

}
