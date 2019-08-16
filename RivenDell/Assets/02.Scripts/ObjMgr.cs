using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.Events;


public class ObjMgr : MonoBehaviour
{

    public GameObject tr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("POSITION"))
        {
            Debug.Log("부모로부터 벗어났습니다.");
            transform.parent = transform.parent.parent;
            DestroyObj();
            
        }
    }
    private void DestroyObj()
    {
        if (transform.parent.parent == CompareTag("Player"))
        {
            Debug.Log("파괴되었습니다.");
            Destroy(tr);
        }

    }
}
