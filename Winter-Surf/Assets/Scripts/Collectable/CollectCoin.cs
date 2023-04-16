using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    
    [SerializeField] AudioSource coinSound;

    public void Start() {
        coinSound = GameObject.Find("CoinCollect").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {   
        coinSound.Play();
        CollectableControl.Increment();
        this.gameObject.SetActive(false);
    }
}
