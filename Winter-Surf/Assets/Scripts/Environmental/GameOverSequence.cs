using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSequence : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject pointDisplay;

    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence() {
        yield return new WaitForSeconds(3);
        endScreen.SetActive(true);
        pointDisplay.SetActive(false);
    }
}
