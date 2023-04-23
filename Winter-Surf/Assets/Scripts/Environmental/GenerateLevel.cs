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
        secNum = Random.Range(0, 4);
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += increment;
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }
}
