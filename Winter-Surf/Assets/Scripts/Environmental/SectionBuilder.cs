using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionBuilder
{
    private GameObject section;
    private int sectionLength;
    private float laneWidth;
    private int pinesNumber;
    private int rocksNumber;
    private int snowflakesNumber;

    public SectionBuilder (GameObject section, float laneWidth)
    {
        this.section = section;
        this.laneWidth = laneWidth;
        sectionLength = 10;
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
        List<Vector3> obstaclesPositions = generator.GetObstaclesPositions();
        GeneratePines(obstaclesPositions.GetRange(0, pinesNumber), sectionObj);
        GenerateRocks(obstaclesPositions.GetRange(pinesNumber, rocksNumber), sectionObj);
        GenerateSnowflakes(generator.GetCollectablesPositions(), sectionObj);
        return sectionObj;
    }

    private void GeneratePines(List<Vector3> positions, Section section)
    {
        Transform sectionTransform = section.GetSection().transform;
        List<Vector3> pines = new List<Vector3>();
        for (int i = 0; i < pinesNumber; i++)
        {
            Vector3 position = positions[i];
            Vector3 obstacleVect = new Vector3(sectionTransform.position.x + position.x * laneWidth, sectionTransform.position.y, sectionTransform.position.z + position.z - 5);
            pines.Add(obstacleVect);
        }
        section.SetPines(pines);
    }

    private void GenerateRocks(List<Vector3> positions, Section section)
    {
        Transform sectionTransform = section.GetSection().transform;
        List<Vector3> rocks = new List<Vector3>();
        for (int i = 0; i < rocksNumber; i++)
        {
            Vector3 position = positions[i];
            Vector3 obstacleVect = new Vector3(sectionTransform.position.x + position.x * laneWidth, sectionTransform.position.y, sectionTransform.position.z + position.z - 5);
            rocks.Add(obstacleVect);
        }
        section.SetRocks(rocks);
    }

    private void GenerateSnowflakes(List<Vector3> positions, Section section)
    {
        Transform sectionTransform = section.GetSection().transform;
        List<Vector3> snowflakes = new List<Vector3>();
        for (int i = 0; i < snowflakesNumber; i++)
        {
            Vector3 position = positions[i];
            Vector3 snowflakeVect = new Vector3(sectionTransform.position.x + position.x * laneWidth, sectionTransform.position.y + 0.5f, sectionTransform.position.z + position.z - 5);
            snowflakes.Add(snowflakeVect);
        }
        section.SetSnowflakes(snowflakes);
    }
}
