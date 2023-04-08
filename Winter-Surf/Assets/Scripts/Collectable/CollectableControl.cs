using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    private static int coinCount;
    [SerializeField] GameObject coinCountDisplay;

    // Update is called once per frame
    void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
    }

    public static void Increment()
    {
        coinCount ++;
    }
}
