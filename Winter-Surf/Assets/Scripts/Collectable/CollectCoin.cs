using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinSound;

    void OnTriggerEnter(Collider other)
    {
        coinSound.Play();
        CollectableControl.Increment();
        this.gameObject.SetActive(false);
    }
}
