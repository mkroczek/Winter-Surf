using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    private List<int> weightedIndices = new List<int>();
    public int zPos = 16;
    public int increment = 10;
    public bool creatingSection = false;
    public int secNum;
    public int levelSectionsNum = 5;
    public GameObject pineObstacle;
    public GameObject snowflakeCollectable;
    private PlayerMove playerMove;
    private float spawnSpeed;
    private const float epsilon = 1;

    // Start is called before the first frame update
    void Start(){
        AssignWeights();

        playerMove = PlayerMove.PLAYERINSTANCE.GetComponent<PlayerMove>();
        spawnSpeed = 2;
    }


    // Update is called once per frame
    void Update()
    {
        if(playerMove.distancePassed >= 10 * levelSectionsNum - epsilon && playerMove.distancePassed <= 10 * levelSectionsNum + epsilon) // Section length is 10
        {
            playerMove.moveSpeed *= 1.25f;
            // spawnSpeed /= 1.5f;
            levelSectionsNum *= 2;
        }

        if(!creatingSection)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        float obstaclePosition = Random.Range(-1,2) * 1.5f;
        float snowflakePosition = Random.Range(-1,2) * 1.5f;
        while ( snowflakePosition == obstaclePosition ) 
        {
            snowflakePosition = Random.Range(-1,2) * 1.5f;
        }

        // section placement
        int randomIndex = Random.Range(0, weightedIndices.Count);
        secNum = weightedIndices[randomIndex];
        GameObject obj = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += increment;
        yield return new WaitForSeconds(spawnSpeed);
        creatingSection = false;

         // obstacle placement
        Vector3 obstacleVect = new Vector3(obj.transform.position.x + obstaclePosition, obj.transform.position.y, obj.transform.position.z);
        Instantiate(pineObstacle, obstacleVect, Quaternion.identity);

        // snowflake placement
        Vector3 snowflakeVect = new Vector3(obj.transform.position.x + snowflakePosition, obj.transform.position.y + 0.5f, obj.transform.position.z);
        Instantiate(snowflakeCollectable, snowflakeVect, transform.rotation * Quaternion.Euler (90f, 0f, 0f));
    }

    void AssignWeights()
    {
        // Clear any previous weights
        weightedIndices.Clear();

        // Assign weights based on probabilities
        for (int i = 0; i < section.Length; i++)
        {
            int weight;

            if (i == 0){
                weight = 30;
            } else if (i < 3){
                weight = 25;
            } else{
                weight = 10;
            }

            for (int j = 0; j < weight; j++) {
                weightedIndices.Add(i);
            }
        }
    }
}
