using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class DrawMgr : MonoBehaviour
{
    [Header("Controller SetUp")]
    //오른손 컨트롤러값
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;
    //트리거 버튼 액션값 할당
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    //6DOF(6 Degree of freedom) 센서값의 액션
    public SteamVR_Action_Pose pose = SteamVR_Actions.default_Pose;

    [Header("Line Setup")]
    private LineRenderer line;
    public float lineWidth = 0.01f;
    public Color lineColor = Color.white;

    private Transform parentTr;

    #region  UNITY_CALL_BACK

    // Start is called before the first frame update
    void Start()
    {
        parentTr = transform.parent.transform;
        //CreateLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetStateDown(rightHand))
        {
            CreateLine();
        }

        if (trigger.GetState(rightHand))
        {
            //컨트롤러의 위치값
            Vector3 position = pose.GetLocalPosition(rightHand);
            position += parentTr.position; //CameraRig위치를 추적

            ++line.positionCount;
            line.SetPosition(line.positionCount - 1, position);
        }
    }

    // void OnTriggerEnter(Collider coll)
    // {
    //     if (coll.CompareTag("COLOR"))
    //     {
    //         Image img = coll.gameObject.GetComponentsInChildren<Image>()[1];
    //         lineColor = img.color;
    //     }
    // }
    #endregion

    #region  USER_FUNCTION
    void CreateLine()
    {
        //라인을 드로잉하기위한 게임오브젝트를 생성
        GameObject lineObject = new GameObject("Line");
        //라이렌더러 컴포넌트를 추가
        line = lineObject.AddComponent<LineRenderer>();
        //머티리얼 생성
        Material mt = new Material(Shader.Find("Unlit/Color"));
        mt.color = lineColor;

        //속성설정
        line.useWorldSpace = false; //로컬좌표
        line.positionCount = 1;
        line.numCapVertices = 20; //끝부분을 부드럽게 처리
        line.startWidth = lineWidth; //라인 폭
        line.endWidth = lineWidth;
        line.material = mt;


        Vector3 position = pose.GetLocalPosition(rightHand);
        position += parentTr.position;  //CameraRig 위치 + 오른손의 위치
        line.SetPosition(0, position);
    }

    #endregion
}