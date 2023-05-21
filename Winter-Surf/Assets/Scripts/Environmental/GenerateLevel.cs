using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    private List<int> weightedIndices = new List<int>();
    public int zPos = 16;
    public int increment = 10;
    public int secNum;
    public int levelSectionsNum = 5;
    public GameObject pineObstacle;
    public GameObject snowflakeCollectable;
    private PlayerMove playerMove;
    private const float epsilon = 1;
    private const float generationDistance = 40;
    private List<GameObject> sectionsToBeRemoved = new List<GameObject>();
    private List<GameObject> snowflakesToBeRemoved = new List<GameObject>();
    private List<GameObject> pinesToBeRemoved = new List<GameObject>();


    // Start is called before the first frame update
    void Start(){
        AssignWeights();

        playerMove = PlayerMove.PLAYERINSTANCE.GetComponent<PlayerMove>();
    }


    // Update is called once per frame
    void Update()
    {
        if(playerMove.distancePassed >= 10 * levelSectionsNum - epsilon && playerMove.distancePassed <= 10 * levelSectionsNum + epsilon) // Section length is 10
        {
            playerMove.moveSpeed *= 1.25f;
            levelSectionsNum *= 2;
        }

        GenerateSection();
    }

    void GenerateSection()
    {
        float obstaclePosition = Random.Range(-1,2) * 1.5f;
        float snowflakePosition = Random.Range(-1,2) * 1.5f;
        while ( snowflakePosition == obstaclePosition ) 
        {
            snowflakePosition = Random.Range(-1,2) * 1.5f;
        }

        // Remove old section
        if (sectionsToBeRemoved.Count > 0)
        {
            GameObject firstElement = sectionsToBeRemoved[0];
            GameObject firstSnowflake = snowflakesToBeRemoved[0];
            GameObject firstPine = pinesToBeRemoved[0];
            if (playerMove.position.z >= firstElement.transform.position.z + 30)
            {
                sectionsToBeRemoved.RemoveAt(0);
                snowflakesToBeRemoved.RemoveAt(0);
                pinesToBeRemoved.RemoveAt(0);
                Destroy(firstElement);
                Destroy(firstSnowflake);
                Destroy(firstPine);
            }
        }

        if(zPos - playerMove.position.z <= generationDistance){
            // section placement
            int randomIndex = Random.Range(0, weightedIndices.Count);
            int prevSecNum = secNum;
            secNum = weightedIndices[randomIndex];
            while (secNum == prevSecNum)
            {
                randomIndex = Random.Range(0, weightedIndices.Count);
                secNum = weightedIndices[randomIndex];
            }

            
            GameObject obj = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
            sectionsToBeRemoved.Add(obj);
            zPos += increment;

            // obstacle placement
            Vector3 obstacleVect = new Vector3(obj.transform.position.x + obstaclePosition, obj.transform.position.y, obj.transform.position.z);
            GameObject pine = Instantiate(pineObstacle, obstacleVect, Quaternion.identity);
            pinesToBeRemoved.Add(pine);

            // snowflake placement
            Vector3 snowflakeVect = new Vector3(obj.transform.position.x + snowflakePosition, obj.transform.position.y + 0.5f, obj.transform.position.z);
            GameObject snowflake = Instantiate(snowflakeCollectable, snowflakeVect, transform.rotation * Quaternion.Euler (90f, 0f, 0f));
            snowflakesToBeRemoved.Add(snowflake);
        }
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
