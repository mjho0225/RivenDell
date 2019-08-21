using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class SceneMgr : MonoBehaviour
{
    //Transform spawnPoint;
    //Transform startPoint;
    // Start is called before the first frame update
    void Start()
    {
        //startPoint = GameObject.Find("StartPoint").GetComponent<Transform>();
//spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        gameObject.GetComponent<IntroMoveCtrl>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnLevelWasLoaded(int level)
    {
        //if(level == 1)
        //{
        //    transform.position = startPoint.position;
        
        //}
        //if (level == 2)
        //{
        //    transform.position = spawnPoint.position;//new Vector3(80, 32.7f, 158);
        //}
    }
}
