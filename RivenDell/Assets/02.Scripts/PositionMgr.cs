using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PositionMgr : MonoBehaviour
{
    public GameObject[] objPosition;

    bool touch = false;
    
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < objPosition.Length; i++) ;
        if (touch) ;
    }

    //물체가 오면 붙잡아라.
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("OBJECT"))
        {
            //물체를 붙잡아라.
        }
    // 다시 그랩(클릭)이 되면 물체를 때라.
    }
   

}
