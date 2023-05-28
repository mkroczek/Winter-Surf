using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    // public GameObject terrain;

    public static GameObject LEVELCONTROL;
    // public GameObject PLAYERINSTANCE;
    // public GameObject PLAYERCHILDINSTANCE;

    void Awake()
    {   
        // this is used to share the LevelControl object outside along with its components
        LEVELCONTROL = gameObject;
    }

        public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
