using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Valve.VR;

public class InterfaceManager : MonoBehaviour {
    public GameObject XRRig;
    public GameObject MainCamera;

    public GameObject LeftLaser;
    public GameObject RightLaser;

    public bool heightToggle = false;
    public bool voiceToggle = false;
    public bool wingspanToggle = false;
    public bool ipdToggle = false;
    public bool geolocationToggle = false;
    public bool squatDepthToggle = false;
    public bool armLengthsToggle = false;
    public bool handednessToggle = false;
    public bool trackingRateToggle = false;

    // Start is called before the first frame update
    void Start() {
        // Place hat above player
        //VRUIHatObject.transform.SetParent(XRRig.transform);
    }

    // Update is called once per frame
    void Update() {
        // Keep hat above head
        //VRUIHatObject.transform.position = MainCamera.transform.position;
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

    public void VoiceToggleOn()
    {
        voiceToggle = true;
        Debug.Log("The voice on method has been executed");
        Debug.Log("Voice Toggle: " + voiceToggle);
    }
    public void VoiceToggleOff()
    {
        voiceToggle = false;
        Debug.Log("The voice off method has been executed");
        Debug.Log("Voice Toggle: " + voiceToggle);
    }

    public void WingspanToggle(bool b) {
        wingspanToggle = b;
    }
    public void IPDToggle(bool b) {
        ipdToggle = b;
    }
    public void GeolocationToggle(bool b) {
        geolocationToggle = b;
    }
    public void SquatDepthToggle(bool b) {
        squatDepthToggle = b;
    }
    public void ArmLengthsToggle(bool b) {
        armLengthsToggle = b;
    }
    public void HandednessToggle(bool b) {
        handednessToggle = b;
    }
    public void TrackingRateToggle(bool b) {
        trackingRateToggle = b;
    }
}
