using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class SceneMgr : MonoBehaviour
{
    Transform spawnPoint;
    Transform startPoint;
    GameObject watchUI;
    GameObject introUI;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = GameObject.Find("StartPoint").GetComponent<Transform>();
        spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        watchUI = GameObject.Find("Direction_Canvas").GetComponent<GameObject>();
        introUI = GameObject.Find("Canvas_Intro").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnLevelWasLoaded(int level)
    {
        SteamVR_Fade.Start(Color.clear, 2f);
        if (level == 1)
        {
            Destroy(introUI);
            transform.position = startPoint.position;
        }
        if(level == 2)
        {
            SteamVR_Fade.Start(Color.clear, 2f);
            Destroy(watchUI);
            transform.position = spawnPoint.position;//new Vector3(80, 32.7f, 158);
        }
    }
}
