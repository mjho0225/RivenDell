using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class LaserController : MonoBehaviour {
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
    public LineRenderer line;
    public LineRenderer line2;

    public float maxDistance = 10.0f;

    //라인의 기본색
    public Color color = Color.red;
    public Color color2 = Color.white;
    public Color clickedColor = Color.green;

    //Raycast 변수
    private RaycastHit hit;
    private Transform tr;

    private GameObject currButton;
    private GameObject prevButton;

    bool lineCreate = false;

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

    void Update () {
        if(Physics.Raycast(tr.position, tr.forward, out hit, maxDistance, 1 << 12) && trigger.GetStateDown(righthand)){
            Debug.Log("파레트검출1");
            Debug.Log("힛포인트:" + hit.point);
            DrawLine();
        }
        if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance, 1 << 12) && trigger.GetState(righthand))
        {
            Debug.Log("파레트검출");
            Vector3 position = hit.point;
            //position += tr.position;

            ++line2.positionCount;
            line2.SetPosition(line2.positionCount - 1, position);
        }

        if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance, 1<<5)) {
            //CreateLine();
            
            
            
            line.SetPosition (1, new Vector3(0,0, hit.distance));

        }
        if (Physics.Raycast (tr.position, tr.forward, out hit, maxDistance, 1 << 9)) {
            //if (Physics.Raycast (tr.position, tr.forward, out hit, maxDistance, 1 >> 5)) {
                //CreateLine();
                
                
                
                line.SetPosition (1, new Vector3 (0, 0, hit.distance));

                //버튼일경우에만 실행
                if (hand == SteamVR_Input_Sources.RightHand) {
                    currButton = hit.collider.gameObject;
                    if (currButton != prevButton) {
                        //모든 버튼에게 포커스아웃 이벤트를 전달(이벤트 생성, 발생)
                        OnLaserExit ();
                        //현재 가리키고 있는 버튼정보를 포함한 이벤트를 모두 전달
                        OnLaserEnter (hit.collider.gameObject);

                        prevButton = currButton;
                    }
                    //트리거 버튼 클릭의 이벤트를 처리
                    if (trigger.GetStateDown (hand)) {
                        Debug.Log ("Clicked !!!!");
                        //prevButton = null;
                        ExecuteEvents.Execute (currButton, new PointerEventData (EventSystem.current), ExecuteEvents.pointerClickHandler);
                    }
                //}
            }
        } else {
            if (prevButton != null) {
                OnLaserExit ();
                prevButton = null;
            }
        }
    }

    public void CreateLine () {

        line = this.gameObject.AddComponent<LineRenderer> ();

        line.useWorldSpace = false;
        line.receiveShadows = false;

        line.positionCount = 2;
        line.SetPosition (0, Vector3.zero);
        line.SetPosition (1, new Vector3 (0, 0, maxDistance));

        line.startWidth = 0.002f;
        line.endWidth = 0.0001f;

        //메터리얼 생성
        Material mt = new Material (Shader.Find ("Unlit/Color"));
        mt.color = this.color;

        line.material = mt;

    }

    void DrawLine()
    {
        Debug.Log("그렸습니다!");
        float lineWidth2 = 0.1f;
        //라인을 드로잉하기위한 게임오브젝트를 생성
        GameObject lineObject = new GameObject("Line");
        //라이렌더러 컴포넌트를 추가
        line2 = lineObject.AddComponent<LineRenderer>();
        //머티리얼 생성
        Material mt2 = new Material(Shader.Find("Unlit/Color"));
        mt2.color = color2;

        
    //속성설정
        //line2.useWorldSpace = false; //로컬좌표
        line2.positionCount = 1;
        line2.numCapVertices = 20; //끝부분을 부드럽게 처리
        line2.startWidth = lineWidth2; //라인 폭
        line2.endWidth = lineWidth2;
        line2.material = mt2;

        Vector3 position = hit.point;
        //position += tr.position;
        line2.SetPosition(0, position);
    }
}