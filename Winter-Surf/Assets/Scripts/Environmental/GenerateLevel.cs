using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sections;
    private List<int> weightedIndices = new List<int>();
    public int zPos = 16;
    public int increment = 10;
    public int secNum;
    public int levelSectionsNum = 5;
    public GameObject pineObstacle;
    public GameObject snowflakeCollectable;
    [SerializeField] GameObject rockObstacle;
    private PlayerMove playerMove;
    private const float epsilon = 1;
    private const float generationDistance = 40;
    private List<List<GameObject>> sectionsToBeRemoved = new List<List<GameObject>>();

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
            List<GameObject> firstSection = sectionsToBeRemoved[0];
            if (playerMove.position.z >= firstSection[0].transform.position.z + 30)
            {
                sectionsToBeRemoved.RemoveAt(0);
                firstSection.ForEach(obj => Destroy(obj));
            }
        }
    }

    void GenerateSection()
    {
        if(zPos - playerMove.position.z <= generationDistance){
            int secNum = PickRandomSection();
            
            GameObject sectionObject = Instantiate(sections[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
            SectionBuilder sectionBuilder = new SectionBuilder(sectionObject, 1f);
            sectionBuilder.WithPines(3).WithRocks(3).WithSnowflakes(5);
            Section section = sectionBuilder.Build();
            sectionsToBeRemoved.Add(InstantiateSection(section));

            zPos += increment;
        }
    }

    private List<GameObject> InstantiateSection(Section section)
    {
        List<GameObject> sectionObjects = new List<GameObject>();
        sectionObjects.Add(section.GetSection());
        section.GetPines().ForEach(pinePosition => sectionObjects.Add(InstantiatePine(pinePosition)));
        section.GetRocks().ForEach(rockPosition => sectionObjects.Add(InstantiateRock(rockPosition)));
        section.GetSnowflakes().ForEach(snowflakePosition => sectionObjects.Add(InstantiateSnowflake(snowflakePosition)));
        return sectionObjects;
    }

    private GameObject InstantiatePine(Vector3 position)
    {
        return Instantiate(pineObstacle, position, Quaternion.identity);
    }

    private GameObject InstantiateRock(Vector3 position)
    {
        return Instantiate(rockObstacle, position, Quaternion.identity);
    }

    private GameObject InstantiateSnowflake(Vector3 position)
    {
        return Instantiate(snowflakeCollectable, position, transform.rotation * Quaternion.Euler (90f, 0f, 0f));
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
        for (int i = 0; i < sections.Length; i++)
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
