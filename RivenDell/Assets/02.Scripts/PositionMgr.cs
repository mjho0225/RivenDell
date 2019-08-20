using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using cakeslice;

public class PositionMgr : MonoBehaviour
{
    public MeshRenderer tf;
    public 
    
    bool touchin = false;
      
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("OBJECT"))
        {
            //물체를 생성해라.(메쉬를 켜라)
            tf.enabled = true;           
            Debug.Log("생성되었습니다.");
            gameObject.GetComponent<Outline>().enabled = false;

            //UI를 띄워라.

        }
        
    
    }
   

}
