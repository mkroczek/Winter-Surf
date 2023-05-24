using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionBuilder : MonoBehaviour
{
    private GameObject section;
    private int sectionLength;
    private float laneWidth;
    private int pinesNumber;
    private int rocksNumber;
    private int snowflakesNumber;
    private GameObject pineObstacle;
    private GameObject snowflakeCollectable;

    public SectionBuilder (GameObject section, float laneWidth, GameObject pineObstacle, GameObject snowflakeCollectable)
    {
        this.section = section;
        this.laneWidth = laneWidth;
        this.pineObstacle = pineObstacle;
        this.snowflakeCollectable = snowflakeCollectable;
        Renderer renderer = section.GetComponent<Renderer>();
        sectionLength = (int)renderer.bounds.size.z;
    }

    public SectionBuilder WithPines(int pinesNumber)
    {
        this.pinesNumber = pinesNumber;
        return this;
    }

    public SectionBuilder WithRocks(int rocksNumber)
    {
        this.rocksNumber = rocksNumber;
        return this;
    }

    public SectionBuilder WithSnowflakes(int snowflakesNumber)
    {
        this.snowflakesNumber = snowflakesNumber;
        return this;
    }

    public Section Build()
    {
        SectionObjectsPositionsGenerator generator = new SectionObjectsPositionsGenerator(
            sectionLength, 
            3, 
            rocksNumber + pinesNumber, 
            snowflakesNumber
        );
        Section sectionObj = new Section(section);
        GeneratePines(generator.GetObstaclesPositions(), sectionObj);
        GenerateSnowflakes(generator.GetCollectablesPositions(), sectionObj);
        return sectionObj;
    }

    private void GeneratePines(List<Vector3> positions, Section section)
    {
        Transform sectionTransform = section.GetSection().transform;
        List<GameObject> pines = new List<GameObject>();
        for (int i = 0; i < pinesNumber; i++)
        {
            Vector3 position = positions[i];
            Vector3 obstacleVect = new Vector3(sectionTransform.position.x + position.x * laneWidth, sectionTransform.position.y, sectionTransform.position.z + position.z);
            GameObject pine = Instantiate(pineObstacle, obstacleVect, Quaternion.identity);
            pines.Add(pine);
        }
        section.SetPines(pines);
    }

    private void GenerateSnowflakes(List<Vector3> positions, Section section)
    {
        Transform sectionTransform = section.GetSection().transform;
        List<GameObject> snowflakes = new List<GameObject>();
        for (int i = 0; i < rocksNumber; i++)
        {
            Vector3 position = positions[i];
            Vector3 snowflakeVect = new Vector3(sectionTransform.position.x + position.x * laneWidth, sectionTransform.position.y + 0.5f, sectionTransform.position.z + position.z);
            GameObject snowflake = Instantiate(snowflakeCollectable, snowflakeVect, transform.rotation * Quaternion.Euler (90f, 0f, 0f));
            snowflakes.Add(snowflake);
        }
        section.SetSnowflakes(snowflakes);
    }
}
