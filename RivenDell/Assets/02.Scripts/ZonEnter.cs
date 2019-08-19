using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//DirIntZon에 진입시 힌트 UI 생성
//진입후 n초 후에 UI가 생성되야한다
//
public class ZonEnter : MonoBehaviour {

    public GameObject[] hintUI;
    public int currPage = 0;
    public GameObject menuBar;

    void Start () {

        //hintUI.SetActive (false);
        ShowUI ();
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
            Debug.Log("마지막 화면 - 씬 전환");
            
        } else {
            ++currPage;
            hintUI[currPage].gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {

    }

}