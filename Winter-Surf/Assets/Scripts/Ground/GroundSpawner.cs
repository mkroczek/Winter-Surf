using UnityEngine;

public class GroundSpawner : MonoBehaviour {
    public GameObject groundTile;
    public GameObject pineObstacle;
    public GameObject snowflakeCollectable;
    Vector3 nextSpawnPoint; 
    int startingTilesNumber = 2;


    public void SpawnTile(){
        int obstaclePosition = Random.Range(-1,2);
        int snowflakePosition = Random.Range(-1,2);
        while ( snowflakePosition == obstaclePosition ) 
        {
            snowflakePosition = Random.Range(-1,2);
        }
        
        // tile placement
        GameObject obj = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = obj.transform.GetChild(1).transform.position;

        // obstacle placement
        Vector3 obstacleVect = new Vector3(obj.transform.position.x + obstaclePosition, obj.transform.position.y, obj.transform.position.z);
        Instantiate(pineObstacle, obstacleVect, Quaternion.identity);

        // snowflake placement
        Vector3 snowflakeVect = new Vector3(obj.transform.position.x + snowflakePosition, obj.transform.position.y + 0.5f, obj.transform.position.z);
        Instantiate(snowflakeCollectable, snowflakeVect, transform.rotation * Quaternion.Euler (90f, 0f, 0f));
    }

    // Start is called before the first frame update
    void Start(){
        for(int i=0; i<startingTilesNumber; i++){
            SpawnTile();
        }
    }

}
