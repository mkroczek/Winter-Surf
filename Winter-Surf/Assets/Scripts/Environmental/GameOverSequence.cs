using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSequence : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject coinCountDisplay;

    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence() {
        yield return new WaitForSeconds(3);
        endScreen.SetActive(true);
        coinCountDisplay.SetActive(false);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
        // reset points count to zero
        CollectableControl.Reset();

    }
}
