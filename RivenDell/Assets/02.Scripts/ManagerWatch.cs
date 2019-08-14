using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ManagerWatch : MonoBehaviour
{
    public GameObject WatchUI; //시계 UI
    public Transform handPivot; //시침분침 피봇
    public Transform bigWatch;
    public Transform emptyPivot;

    public GameObject target; // 태양 타겟

    int angle; //각도
    int sunMask;

    float i; // 화살표 숫자

    public Slider[] m_ArrowSlider; // 화살표 배열

    float rayLength = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        WatchUI = GetComponentInChildren<Canvas>().gameObject;
        WatchUI.SetActive(false);

        sunMask = LayerMask.GetMask("SUN");

        StartCoroutine("OnTriggerEnter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll)
    {
            angle = UnityEngine.Random.Range(1, 12);

            handPivot.localEulerAngles = new Vector3(0, 0, angle * 30);
        while (coll.CompareTag("RIGHTHAND"))
        {           
            Debug.Log("들어와썽!");
            WatchUI.SetActive(true);
            m_ArrowSlider[0].gameObject.SetActive(true);
            
            //12 개의 시간 방향 중 랜덤하게 1개
            coll.enabled = false;
            
        }
        StartCoroutine("WaitRaycast");
    }
}
