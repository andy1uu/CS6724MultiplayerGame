using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Normal.Realtime;


public class PermissionsManager : MonoBehaviour {
    public GameObject XRRig;
    public GameObject MainCamera;
    public GameObject CameraOffset;
    public GameObject LeftController;
    public GameObject RightController;
    public GameObject RightControllerOffset;
    public GameObject LeftControllerOffset;

    public GameObject VRHat;

    public bool heightToggle = false;
    public float height;

    public bool leftHandToggle = false;

    public bool rightHandToggle = false;

    // Start is called before the first frame update
    void Start() {
        // Place hat above player
        VRHat.transform.SetParent(XRRig.transform);
    }

    // Update is called once per frame
    void Update() {

        // Keep Hat Above Head
        VRHat.transform.position = MainCamera.transform.position;

        // Turns the VR Hat of the player on or off based on the boolean
        VRHat.SetActive(heightToggle);
    }

    public void HeightToggleOn() {
        heightToggle = true;
        Debug.Log("The height on method has been executed");
        Debug.Log("Height Toggle: " + heightToggle);
    }
    public void HeightToggleOff()
    {
        heightToggle = false;
        Debug.Log("The height off method has been executed");
        Debug.Log("Height Toggle: " + heightToggle);
    }
}
