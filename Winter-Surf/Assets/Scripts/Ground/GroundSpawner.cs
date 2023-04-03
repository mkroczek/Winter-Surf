using UnityEngine;

public class GroundSpawner : MonoBehaviour {
    public GameObject groundTile;
    Vector3 nextSpawnPoint; 
    int startingTilesNumber = 2;


    public void SpawnTile(){
        GameObject obj = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = obj.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start(){
        for(int i=0; i<startingTilesNumber; i++){
            SpawnTile();
        }
    }

}
