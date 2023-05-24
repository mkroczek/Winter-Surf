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
    private List<Section> sectionsToBeRemoved = new List<Section>();

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

        RemoveOldSection();
        GenerateSection();
    }

    private void RemoveOldSection()
    {
        if (sectionsToBeRemoved.Count > 0)
        {
            Section firstSection = sectionsToBeRemoved[0];
            if (playerMove.position.z >= firstSection.GetSection().transform.position.z + 30)
            {
                sectionsToBeRemoved.RemoveAt(0);
                firstSection.DestroyScene();
            }
        }
    }

    void GenerateSection()
    {
        if(zPos - playerMove.position.z <= generationDistance){
            int secNum = PickRandomSection();
            
            GameObject sectionObject = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
            SectionBuilder sectionBuilder = new SectionBuilder(sectionObject, 1.5f, pineObstacle, snowflakeCollectable);
            sectionBuilder.WithPines(3).WithSnowflakes(3);
            sectionsToBeRemoved.Add(sectionBuilder.Build());

            zPos += increment;
        }
    }

    private int PickRandomSection()
    {
        int randomIndex = Random.Range(0, weightedIndices.Count);
        int prevSecNum = secNum;
        secNum = weightedIndices[randomIndex];
        while (secNum == prevSecNum)
        {
            randomIndex = Random.Range(0, weightedIndices.Count);
            secNum = weightedIndices[randomIndex];
        }
        return secNum;
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
