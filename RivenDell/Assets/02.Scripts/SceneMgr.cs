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
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            
            SteamVR_Fade.Start(Color.clear, 2f);
            gameObject.GetComponent<IntroMoveCtrl>().enabled = false;
            introUI = GameObject.Find("Canvas_Intro").GetComponent<GameObject>();
            Destroy(introUI);

            startPoint = GameObject.Find("StartPoint").GetComponent<Transform>();
            transform.position = startPoint.position;

            target = GameObject.Find("Sun").GetComponent<GameObject>();


        }
        if(level == 2)
        {
            SteamVR_Fade.Start(Color.clear, 2f);

            watchUI = GameObject.Find("Direction_Canvas").GetComponent<GameObject>();
            Destroy(watchUI);

            spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
            transform.position = spawnPoint.position;//new Vector3(80, 32.7f, 158);
        }
    }
}
