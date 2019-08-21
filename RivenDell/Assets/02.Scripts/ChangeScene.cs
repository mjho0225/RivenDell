using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator ChangeButton()
    {
        SteamVR_Fade.Start(Color.black, 4f);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("ForestScene");
    }
    
    public void ChangeC()
    {
        StartCoroutine("ChangeButton");
    }
}
