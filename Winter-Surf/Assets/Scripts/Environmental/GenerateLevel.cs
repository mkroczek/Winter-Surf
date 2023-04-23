using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 16;
    public int increment = 10;
    public bool creatingSection = false;
    public int secNum;
    public GameObject pineObstacle;
    public GameObject snowflakeCollectable;


    // Update is called once per frame
    void Update()
    {
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
        secNum = Random.Range(0, 4);
        GameObject obj = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += increment;
        yield return new WaitForSeconds(2);
        creatingSection = false;

         // obstacle placement
        Vector3 obstacleVect = new Vector3(obj.transform.position.x + obstaclePosition, obj.transform.position.y, obj.transform.position.z);
        Instantiate(pineObstacle, obstacleVect, Quaternion.identity);

        // snowflake placement
        Vector3 snowflakeVect = new Vector3(obj.transform.position.x + snowflakePosition, obj.transform.position.y + 0.5f, obj.transform.position.z);
        Instantiate(snowflakeCollectable, snowflakeVect, transform.rotation * Quaternion.Euler (90f, 0f, 0f));
    }
}
