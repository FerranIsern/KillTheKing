using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Animator catapultAnimator;
    public BallLauncherScript ballLauncherScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space))
        {
            catapultAnimator.SetTrigger("shoot");
            Invoke("CallShot",0.15f);
        }
	}

    void CallShot()
    {
        ballLauncherScript.ShootRock();
    }
}
