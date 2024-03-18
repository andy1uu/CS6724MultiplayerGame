using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class VolleyballBehavior : MonoBehaviour
{
    public Transform launchPoint;
    public string volleyBallName;
    public float power = 100;

    public void FireWeapon()
    {
        GameObject volleyBall = Realtime.Instantiate(volleyBallName, launchPoint.position, launchPoint.rotation);
        volleyBall.GetComponent<Rigidbody>().AddForce(launchPoint.forward * power);
    }
}
