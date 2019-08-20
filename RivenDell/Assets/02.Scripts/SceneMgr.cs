using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnLevelWasLoaded(int level)
    {
        if(level == 2)
        {
            transform.position = spawnPoint.position;//new Vector3(80, 32.7f, 158);
        }
    }
}
