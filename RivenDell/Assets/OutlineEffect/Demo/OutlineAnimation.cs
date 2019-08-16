using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

namespace cakeslice
{
    public class OutlineAnimation : MonoBehaviour
    {
        bool pingPong = false;
        bool touching = false;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Color c = GetComponent<OutlineEffect>().lineColor0;
            Color m = GetComponent<OutlineEffect>().lineColor2;

            if (pingPong)
            {
                c.a += Time.deltaTime;
                m.a += Time.deltaTime;
                if(c.a >= 1 || m.a >=1)
                    pingPong = false;
            }
            else
            {
                c.a -= Time.deltaTime;
                m.a -= Time.deltaTime;
                if(c.a <= 0 || m.a <=0)
                    pingPong = true;
            }

            c.a = Mathf.Clamp01(c.a);
            m.a = Mathf.Clamp01(m.a);
            
            GetComponent<OutlineEffect>().lineColor0 = c;
            GetComponent<OutlineEffect>().lineColor2 = m;
            GetComponent<OutlineEffect>().UpdateMaterialsPublicProperties();
        }
       

    }
}