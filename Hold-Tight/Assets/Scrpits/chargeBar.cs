using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class chargeBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public GameObject rHoldPoint, lHoldPoint;
    public float currentCharge,colorRate, lastHeight;


    Color curColor;
    void Start()
    {
        colorRate = 0;
    }
    private void Update()
    {
        colorRate += 0.002f;

        curColor = new Color(1/currentCharge*colorRate*4, currentCharge*0.05f, 0);
        fill.color = curColor;

    }
    private void FixedUpdate()
    {
        TakeDamage(.02f);
        if (currentCharge <= 0)
        {
            lastHeight = rHoldPoint.transform.parent.transform.position.y;
            Destroy(rHoldPoint.GetComponent<FixedJoint>());
            Destroy(lHoldPoint.GetComponent<FixedJoint>());

            rHoldPoint.transform.parent.transform.DOMoveZ(0.3f, 0.05f);
            lHoldPoint.transform.parent.transform.DOMoveZ(0.3f, 0.05f);
        }
    }            

    

   
    public void TakeDamage(float damage)
    {
        currentCharge -= damage;
        slider.value = currentCharge;
    }

    public void TakeCharge(float battery)
    {
        currentCharge += battery;
        slider.value = currentCharge;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "battery")
        {
            TakeCharge(1);
        }

    }
}

