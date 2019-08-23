using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;

//DirIntZon에 진입시 힌트 UI 생성
//진입후 n초 후에 UI가 생성되야한다
//
public class ZonEnter : MonoBehaviour {

    public GameObject[] hintUI;
    public int currPage = 0;
    public GameObject menuBar;


    void Start () {
        
        //hintUI.SetActive (false);
        //ShowUI ();
    }

    public void ShowUI () 
    {
        hintUI[currPage].gameObject.SetActive(true);
        menuBar.SetActive(true);
    }
    public void ChangeUI () 
    {
        hintUI[currPage].gameObject.SetActive(false);
        //마지막 레이어인지 아닌지 판단하기
        if (hintUI.Length == currPage + 1) {
           
            //씬 전환하는 로직 넣기
            //Menu 패널을 안보이게하고
            //menuBar.SetActive(false);
            
            //
        } else {
            ++currPage;
            hintUI[currPage].gameObject.SetActive(true);
            
            if(currPage == 6){
            Debug.Log("마지막 화면 - 씬 전환");
                menuBar.SetActive(false);               
            }
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player"){
            ShowUI();
            // GameObject rightHand = GameObject.FindGameObjectWithTag("RIGHTHAND");
            // rightHand.GetComponent<LaserController>().CreateLine();
        }
    }

    public IEnumerator ChangeScene(){
        SteamVR_Fade.Start(Color.black, 4f);
        
        yield return new WaitForSeconds (2f);
        SceneManager.LoadScene("SecondScene");
    }
    public void StartC(){
          StartCoroutine("ChangeScene");
    }
}