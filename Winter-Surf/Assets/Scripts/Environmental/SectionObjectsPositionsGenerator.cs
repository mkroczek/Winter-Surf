using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class SectionObjectsPositionsGenerator
{
    private int sectionRows;
    private int sectionLanes;
    private int obstacles;
    private int collectables;
    private int leftBoundLane;
    private int rightBoundLane;
    private List<Vector3> runningPath = new List<Vector3>();
    private List<Vector3> obstaclesPositions = new List<Vector3>();
    private List<Vector3> collectablesPositions = new List<Vector3>();

    public SectionObjectsPositionsGenerator(int sectionRows, int sectionLanes, int obstacles, int collectables)
    {
        this.sectionRows = sectionRows;
        this.sectionLanes = sectionLanes;
        this.obstacles = obstacles;
        this.collectables = collectables;

        leftBoundLane = -sectionLanes/2;
        rightBoundLane = leftBoundLane + sectionLanes - 1;

        InitializeRunningPath();
        GenerateObstacles();
        GenerateCollectables();
    }

    private void InitializeRunningPath()
    {
        int firstLane = 0;
        runningPath.Add(new Vector3(firstLane, 0, 0));
        for (int i = 1; i < sectionRows; i++)
        {
            int previousLane = (int)runningPath[runningPath.Count - 1].z;
            int nextLane = GetNeighbourLane(previousLane);
            runningPath.Add(new Vector3(previousLane, 0, i));
            if (previousLane != nextLane)
            {
                runningPath.Add(new Vector3(nextLane, 0, i));
            }
        }
    }

    private int GetNeighbourLane(int lane)
    {
        int minLane = Math.Max(leftBoundLane, lane - 1);
        int maxLane = Math.Max(rightBoundLane, lane + 1);
        return Random.Range(minLane, maxLane + 1);
    }

    private void GenerateObstacles()
    {
        for (int i = 0; i < obstacles; i++)
        {
            int row = Random.Range(0, sectionRows + 1);
            int lane = Random.Range(0, sectionLanes + 1);
            Vector3 position = new Vector3(lane, 0, row);
            while(IsOnRunningPath(position))
            {
                row = Random.Range(0, sectionRows + 1);
                lane = Random.Range(0, sectionLanes + 1);
                position = new Vector3(lane, 0, row);
            }
            obstaclesPositions.Add(position);
        }
    }

    private void GenerateCollectables()
    {
        for (int i = 0; i < collectables; i++)
        {
            Vector3 randomPositionOnPath = runningPath[Random.Range(0, runningPath.Count + 1)];
            while(IsOccupiedByObstacleOrCollectable(randomPositionOnPath))
            {
                randomPositionOnPath = runningPath[Random.Range(0, runningPath.Count + 1)];
            }
            collectablesPositions.Add(randomPositionOnPath);
        }
    }

    private bool IsOnRunningPath(Vector3 position)
    {
        return runningPath.Contains(position);
    }

    private bool IsOccupiedByObstacleOrCollectable(Vector3 position)
    {
        return obstaclesPositions.Contains(position) || collectablesPositions.Contains(position);
    }

    public List<Vector3> GetObstaclesPositions()
    {
        return obstaclesPositions;
    }

    public List<Vector3> GetCollectablesPositions()
    {
        return collectablesPositions;
    }
}
