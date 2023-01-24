using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFallow : MonoBehaviour
{
    public GameObject target;
    public Vector3 dist;
    public float speed;

    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,target.transform.position.y,transform.position.z) + dist, Time.deltaTime * speed);
    }
        
}
