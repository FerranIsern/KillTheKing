using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Animator catapultAnimator;
    public BallLauncherScript ballLauncherScript;
    public GameObject[] levels;
    public GameObject levelParent;
    int actualLevel;

    public GameObject alertPanel;
    public Text rockCount;
    public Text alertText;

    public bool detected = false;

    bool canshoot;
    int numberOfRocks;

	// Use this for initialization
	void Start () {
        actualLevel = 0;
        LoadLevel();

        canshoot = true;

        numberOfRocks = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (detected)
        {
            if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space))
            {
                if (canshoot && numberOfRocks > 0)
                {
                    canshoot = false;
                    catapultAnimator.SetTrigger("shoot");
                    Invoke("CallShot",0.15f);
                    Invoke("Reload", 1);

                    if (actualLevel > 0)
                    {
                        numberOfRocks--;
                        rockCount.text = numberOfRocks.ToString();
                    }
                }
            }
        }
	}

    void Reload()
    {
        canshoot = true;
    }

    public void LevelOk()
    {
        actualLevel++;
        alertPanel.gameObject.SetActive(false);

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("kill"))
            Destroy(go);
        LoadLevel();

        numberOfRocks = 3;
        rockCount.text = numberOfRocks.ToString();
    }

    void LoadLevel()
    {

        foreach (Transform son in levelParent.transform)
            Destroy(son.gameObject);
        var newlevel = Instantiate(levels[actualLevel], new Vector3(0,0,0), levelParent.transform.rotation, levelParent.transform);
        newlevel.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        if (actualLevel == 2)
        {
            DisplayAlert("Wood items can be moved by your shots!");
        }
        else if (actualLevel == 3)
        {
            DisplayAlert("Stone pillars won't move and can stop your shots.");
        }
        else if (actualLevel == 4)
        {
            DisplayAlert("If you can't reach the king try pushing a barrel on him.");
        }

    }

    void DisplayAlert(string text)
    {
        alertPanel.gameObject.SetActive(true);
        alertText.text = text;
        
    }

    void CallShot()
    {
        ballLauncherScript.ShootRock();
    }
}
