using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lMagnet : MonoBehaviour
{
    public GameObject prefSpring, firstSpring;
    public chargeBar bar;
    int spirngCount;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos.Set(0,-0.175f,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "collectableSpring")
        {
            Destroy(other.gameObject);
            addSpring();
        }
        if (other.gameObject.tag == "battery")
        {
            Destroy(other.gameObject);
            bar.TakeCharge(2);
        }
    }
    void addSpring()
    {
        spirngCount += 1;
        GetComponentInParent<climbing>().totaCoilSpringCount += 1;
        var newPrefSpring = Instantiate(prefSpring, new Vector3(0,0,0), new Quaternion(0,0,0,1));
        newPrefSpring.transform.parent = firstSpring.transform;
        newPrefSpring.transform.localRotation = new Quaternion(0,0,0,1);
        newPrefSpring.transform.localPosition = pos*spirngCount;


    }
}
