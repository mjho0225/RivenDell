using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ForestScene : MonoBehaviour
{
    GameObject introUI;
    Transform thePlayer;
    Transform startPoint;
    
    // Start is called before the first frame update

    private void Awake()
    {
        SteamVR_Fade.Start(Color.clear, 0f);
        introUI = GameObject.Find("Canvas_Intro");
        introUI.SetActive(false);
       

        startPoint = GameObject.Find("StartPoint").GetComponent<Transform>();
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        thePlayer.position = startPoint.position;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}