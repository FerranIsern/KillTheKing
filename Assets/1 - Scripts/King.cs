using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        print("iep");
        if (collision.transform.tag == "kill")
        {
            GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
            gameController.GetComponent<GameController>().LevelOk();
        }
    }
}
