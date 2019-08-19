﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class LaserController : MonoBehaviour
{
    //나는 먼저 접속하는녀석을 왼손컨트롤러로 하고싶다

    //연결된 컨트롤러를 저장할 변수
    public SteamVR_Input_Sources hand;

    //왼손 컨트롤러
    public SteamVR_Input_Sources lefthand = SteamVR_Input_Sources.LeftHand;
    //오른손 컨트롤러
    public SteamVR_Input_Sources righthand = SteamVR_Input_Sources.RightHand;

    //접속한 컨트롤러
    public SteamVR_Behaviour_Pose pose;
    //트리거 버튼 클릭의 액션값
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    

    //동적으로 생성할 라인랜더러
    private LineRenderer line;

    public float maxDistance = 10.0f;

    //라인의 기본색
    public Color color = Color.blue;
    public Color clickedColor = Color.green;

    //Raycast 변수
    private RaycastHit hit;
    private Transform tr;

    private GameObject currButton;
    private GameObject prevButton;

    //델리게이트 선언부
    #region
    //LaserEnter
    public delegate void LaserEnterHandler (GameObject obj);
    public static event LaserEnterHandler OnLaserEnter;

    //LaserExit
    public delegate void LaserExitHandler ();
    public static event LaserExitHandler OnLaserExit;
    #endregion

    //Pointer 객체를 저장할 변수
    //public Transform pointer;

    // Start is called before the first frame update
    void Start () {
        //접속한 컨트롤러가 왼손/오른손인지 판별
        pose = GetComponent<SteamVR_Behaviour_Pose> ();
        hand = pose.inputSource;

        tr = GetComponent<Transform> ();

        CreateLine();
    }

    void Update() {
        if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance))
        {
            line.SetPosition(1, new Vector3(0, 0, hit.distance));
            Debug.Log("1");

            //버튼일경우에만 실행
            if (hit.collider.gameObject.layer == 9 && hand == SteamVR_Input_Sources.RightHand)
            {
                Debug.Log("2");
                currButton = hit.collider.gameObject;
                if (currButton != prevButton)
                {
                    Debug.Log("3");
                    //모든 버튼에게 포커스아웃 이벤트를 전달(이벤트 생성, 발생)
                    OnLaserExit();
                    //현재 가리키고 있는 버튼정보를 포함한 이벤트를 모두 전달
                    OnLaserEnter(hit.collider.gameObject);

                    prevButton = currButton;
                }
                //트리거 버튼 클릭의 이벤트를 처리
                if (trigger.GetStateDown(hand))
                {
                    ExecuteEvents.Execute(currButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                }
            }
        }            
        else
        {
            if (prevButton != null)
            {
                OnLaserExit();
                prevButton = null;
            }
        }
    }

    void CreateLine()
    {
        line = this.gameObject.AddComponent<LineRenderer>();

        line.useWorldSpace = false;
        line.receiveShadows = false;

        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0, 0, maxDistance));

        line.startWidth = 0.03f;
        line.endWidth = 0.005f;

        //메터리얼 생성
        Material mt = new Material(Shader.Find("Unlit/Color"));
        mt.color = this.color;

        line.material = mt;
        
    }
}