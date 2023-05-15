using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    private static int coinCount;
    [SerializeField] GameObject coinCountDisplay;
    // private static int coinEndCount;
    [SerializeField] GameObject coinEndCountDisplay;

    // Update is called once per frame
    void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
        coinEndCountDisplay.GetComponent<Text>().text = "" + coinCount;
    }

    public static void Increment()
    {
        coinCount ++;
    }

    public static void Reset()
    {
        coinCount = 0;
    }
}
