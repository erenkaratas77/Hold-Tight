using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ground : MonoBehaviour
{
    public GameObject fallingClimber, mainClimber; 
    public camFallow camfallow;
    public LevelManager levelManager;
    public ParticleSystem lightning, respawn, blood;
    public chargeBar bar;

    bool again=true;
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && again)
        {
            if(bar.lastHeight<10 || counter < 4)
            {
                blood.Play();
                levelManager.fail();
                again = false;
            }
            else
            {
                camfallow.target = fallingClimber;
                lightning.Play();
                respawn.Play();
                fallingClimber.SetActive(true);
                counter = mainClimber.GetComponentInParent<climbing>().totaCoilSpringCount;
                fallingClimber.transform.DOMoveY((bar.lastHeight * counter) / 10, 3).OnComplete(() => finish());
                mainClimber.GetComponentInParent<climbing>().enabled = false;

                Destroy(mainClimber);

                again = false;

            }
            
        }
    }

    void finish()
    {
        camfallow.target = null;
        levelManager.win();
        fallingClimber.AddComponent<Rigidbody>();
    }
}
