using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Animator catapultAnimator;
    public BallLauncherScript ballLauncherScript;
    public GameObject[] levels;
    public GameObject levelParent;
    int actualLevel;

	// Use this for initialization
	void Start () {
        actualLevel = 0;
        LoadLevel();
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space))
        {
            catapultAnimator.SetTrigger("shoot");
            Invoke("CallShot",0.15f);
        }
	}

    public void LevelOk()
    {
        actualLevel++;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("kill"))
            Destroy(go);
        LoadLevel();
    }

    void LoadLevel()
    {
        foreach (Transform son in levelParent.transform)
            Destroy(son.gameObject);
        var newlevel = Instantiate(levels[actualLevel], new Vector3(0,0,0), levelParent.transform.rotation, levelParent.transform);
        newlevel.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    void CallShot()
    {
        ballLauncherScript.ShootRock();
    }
}
