using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;

public class BraceZon : MonoBehaviour
{
    public GameObject[] hintUI;
    public int currPage = 0;
    public GameObject menuBar;

    GameObject legPosition;

    

    void Start () {
        
        //hintUI.SetActive (false);
        ShowUI ();
        legPosition = GameObject.Find("LegPosition");
        legPosition.SetActive(false);
       
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
            //if(currPage == 3)
            //{
            //    legPosition.SetActive(true);
            //}
            //if(currPage == 5 && HitPointPosition.Instance.currPoint < 3)
            //{
            //    menuBar.SetActive(false);
            //}
            //if (currPage == 5 && HitPointPosition.Instance.currPoint ==4)
            //{
            //    menuBar.SetActive(true);
            //}

            //if((currPage >= 5 || currPage <= 8) && HitPointPosition.Instance.currPoint <3)
            //{
            //    menuBar.SetActive(false);
            //}
            //if ((currPage >= 5 || currPage <=8 )&& HitPointPosition.Instance.currPoint == 3)
            //{
            //    menuBar.SetActive(true);   

            //    //currPoint가 켜졌을때 메뉴바 O                       
            //}
            if (currPage == 9){
            Debug.Log("마지막 화면 - 씬 전환");
                menuBar.SetActive(false);
                legPosition.SetActive(false);
            }
          
        }
    }

    public IEnumerator ChangeScene(){
        SteamVR_Fade.Start(Color.black, 2f);
        
        yield return new WaitForSeconds (2f);
        SceneManager.LoadScene("JMScene");
    }
    public void StartC(){
          StartCoroutine("ChangeScene");
    }
}
