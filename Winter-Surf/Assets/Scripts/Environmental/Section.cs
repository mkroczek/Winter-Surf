using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section
{
    private GameObject section;
    private List<Vector3> pines = new List<Vector3>();
    private List<Vector3> rocks = new List<Vector3>();
    private List<Vector3> snowflakes = new List<Vector3>();

    public Section(GameObject section)
    {
        this.section = section;
    }

    public void SetPines(List<Vector3> pines)
    {
        this.pines = pines;
    }

    public void SetRocks(List<Vector3> rocks)
    {
        this.rocks = rocks;
    }

    public void SetSnowflakes(List<Vector3> snowflakes)
    {
        this.snowflakes = snowflakes;
    }
    
    public GameObject GetSection()
    {
        return section;
    }

    public List<Vector3> GetPines()
    {
        return pines;
    }

    public List<Vector3> GetRocks()
    {
        return rocks;
    }

    public List<Vector3> GetSnowflakes()
    {
        return snowflakes;
    }
}
