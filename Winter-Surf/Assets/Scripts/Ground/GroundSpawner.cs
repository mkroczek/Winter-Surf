using UnityEngine;

public class GroundSpawner : MonoBehaviour {
    public GameObject groundTile;
    public GameObject pineObstacle;
    Vector3 nextSpawnPoint; 
    int startingTilesNumber = 2;


    public void SpawnTile(){
        GameObject obj = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        Instantiate(pineObstacle, obj.transform.position, Quaternion.identity);
        nextSpawnPoint = obj.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start(){
        for(int i=0; i<startingTilesNumber; i++){
            SpawnTile();
        }
    }

}
