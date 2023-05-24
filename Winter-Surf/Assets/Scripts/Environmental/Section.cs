using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    private GameObject section;
    private List<GameObject> pines = new List<GameObject>();
    private List<GameObject> rocks = new List<GameObject>();
    private List<GameObject> snowflakes = new List<GameObject>();

    public Section(GameObject section)
    {
        this.section = section;
    }

    public void SetPines(List<GameObject> pines)
    {
        this.pines = pines;
    }

    public void SetRocks(List<GameObject> rocks)
    {
        this.rocks = rocks;
    }

    public void SetSnowflakes(List<GameObject> snowflakes)
    {
        this.snowflakes = snowflakes;
    }
    
    public GameObject GetSection()
    {
        return section;
    }

    public void DestroyScene()
    {
        pines.ForEach(pine => Destroy(pine));
        rocks.ForEach(rocks => Destroy(rocks));
        snowflakes.ForEach(snowflakes => Destroy(snowflakes));
        Destroy(section);
    }
}
