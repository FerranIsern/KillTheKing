using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncherScript : MonoBehaviour {

    public GameObject rock;
    public float impulse;

	public void ShootRock ()
    {
        var _rock = Instantiate(rock, transform.position, Quaternion.identity);
        _rock.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * impulse, ForceMode.Impulse);
    }
}
