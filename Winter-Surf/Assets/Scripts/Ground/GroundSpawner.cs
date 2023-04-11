using UnityEngine;

public class GroundSpawner : MonoBehaviour {
    public GameObject groundTile;
    public GameObject pineObstacle;
    public GameObject snowflakeCollectable;
    Vector3 nextSpawnPoint; 
    int startingTilesNumber = 2;


    public void SpawnTile(){
        GameObject obj = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = obj.transform.GetChild(1).transform.position;

        Instantiate(pineObstacle, obj.transform.position, Quaternion.identity);

        Vector3 snowflakePosition = new Vector3(obj.transform.position.x + 1, obj.transform.position.y, obj.transform.position.z);
        Instantiate(snowflakeCollectable, snowflakePosition, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start(){
        for(int i=0; i<startingTilesNumber; i++){
            SpawnTile();
        }
    }

}
