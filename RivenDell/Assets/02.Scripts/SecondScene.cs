using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class SecondScene : MonoBehaviour
{
    
    //GameObject watchUI;
    Transform spawnPoint;
    Transform thePlayer;

    private void Awake()
    {
        //watchUI = GameObject.Find("Direction_Canvas");
        
        SteamVR_Fade.Start(Color.clear, 2f);

        //watchUI.SetActive(false);

        spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        thePlayer.position = spawnPoint.position;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
