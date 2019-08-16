using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveController : MonoBehaviour
{
    public SteamVR_Input_Sources hand = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Action_Boolean touchPad = SteamVR_Actions.default_Touchpad;
    //data type
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;

    public SteamVR_Action_Vector2 touchPosition = SteamVR_Actions.default_TouchpadPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetStateDown(hand))
        {
            Debug.Log("Click Trigger Button");
        }
        if (touchPad.GetState(hand))
        {
            Vector2 pos = touchPosition.GetAxis(hand);
            Debug.LogFormat("TouchPad Touch{0}/{1}", pos.x, pos.y);

        }
    }
}
