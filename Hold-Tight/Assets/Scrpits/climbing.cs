using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class climbing : MonoBehaviour
{
    public GameObject rHand, lHand;
    public float speed;
    public int totaCoilSpringCount;

    bool rightMove,leftMove;
    float rTimer,lTimer;
    float rStartPos, lStartPos;
    float rLastPos, lLastPos;

    // Start is called before the first frame update
    private void Awake()
    {
        rHand.transform.DOMoveZ(0.3f, 0.05f);
        lHand.transform.DOMoveZ(0.3f, 0.05f);

    }
    void Start()
    {
        rHand.transform.DOMoveZ(0.1f, 0.05f);

        rStartPos = rHand.transform.position.y;
        lStartPos = lHand.transform.position.y;

        rightMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (rightMove)
        {
            

            rTimer += 0.005f;
            rHand.transform.position = new Vector3(rHand.transform.position.x, rStartPos + Mathf.PingPong(rTimer*speed, 1f), rHand.transform.position.z);

        }
        else if (leftMove)
        {
            

            lTimer += 0.005f;
            lHand.transform.position = new Vector3(lHand.transform.position.x, lStartPos + Mathf.PingPong(lTimer*speed, 1f), lHand.transform.position.z);
        }

        if (Input.GetMouseButtonDown(0)&&rightMove)
        {
            rHand.transform.DOMoveZ(0.3f, 0.1f);
            lHand.transform.DOMoveZ(0.1f, 0.1f);
            rHand.GetComponent<BoxCollider>().enabled = true;
            lHand.GetComponent<BoxCollider>().enabled = false;

            rightMove = false;
            rLastPos = rHand.transform.position.y;

            lHand.transform.DOMoveY(rLastPos, 0.3f).OnComplete(()=>rBoolChanger());
        }
        else if (Input.GetMouseButtonDown(0)&&leftMove)
        {
            rHand.transform.DOMoveZ(0.1f, 0.1f);
            lHand.transform.DOMoveZ(0.3f, 0.1f);
            rHand.GetComponent<BoxCollider>().enabled = false;
            lHand.GetComponent<BoxCollider>().enabled = true;

            leftMove = false;
            lLastPos = lHand.transform.position.y;

            rHand.transform.DOMoveY(lLastPos, 0.3f).OnComplete(() => lBoolChanger());

        }
    }

    void rBoolChanger()
    {       
        lStartPos = rLastPos;
        lTimer = 0;
        leftMove = true;
    }
    void lBoolChanger()
    {
        rStartPos = lLastPos;
        rTimer = 0;
        rightMove = true;
    }
}
