using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Joystickv2 : MonoBehaviour
{

    //-45X   -135X
    //-52Y   -124Y      FB
    private float maxClamp = 35f;
    private float minClamp = -35f;

    private float speed = 100f;

    [SerializeField] private float forwardBackwardTilt = 0;
    [SerializeField] private float sideToSlideTilt = 0;
    [SerializeField] private Quaternion originalRotation;
    [SerializeField] private XRSimpleInteractable simple;
    [SerializeField] private GameObject topJoystick;
    [SerializeField] private GameObject cockpit;
    private float speedRotateLR = 17f;
    private float speedRotateFB = 17f;
    private GameObject usedGo;

    private bool isGrab = false;

    private void Awake()
    {
        originalRotation = transform.localRotation;
    }
    private void OnEnable()
    {
        simple.selectEntered.AddListener(UsingJoystick);
        simple.selectExited.AddListener(DropJoystick);
    }

    private void OnDisable()
    {
        simple.selectEntered.RemoveListener(UsingJoystick);
        simple.selectExited.RemoveListener(DropJoystick);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrab)
        {
            transform.LookAt(usedGo.transform.position, transform.up); //le joystick regarde l'objet qui l'utilise (dans ce cas la manette)
            
            
            /*float xClamped = Mathf.Clamp(transform.localEulerAngles.x, minClamp, maxClamp);
            float yClamped = Mathf.Clamp(transform.localEulerAngles.y, minClamp, maxClamp);
            transform.localEulerAngles = new Vector3(xClamped,yClamped,0);*/


            forwardBackwardTilt = topJoystick.transform.rotation.eulerAngles.z;
            if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
            {
                forwardBackwardTilt = Mathf.Abs(forwardBackwardTilt - 360);
                Debug.Log("Backward" + forwardBackwardTilt);
            }
            else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
            {
                Debug.Log("forward" + forwardBackwardTilt);
            }

            sideToSlideTilt = topJoystick.transform.rotation.eulerAngles.y;
            if (sideToSlideTilt < 355 && sideToSlideTilt > 290)
            {
                sideToSlideTilt = Mathf.Abs(sideToSlideTilt - 360);
                Debug.Log("Right" + sideToSlideTilt);
            }
            else if (sideToSlideTilt > 5 && sideToSlideTilt < 74)
            {
                Debug.Log("left" + sideToSlideTilt);
            }
        }

    }

    private void UsingJoystick(SelectEnterEventArgs args)
    {
        usedGo = args.interactorObject.transform.gameObject; //recupere l'objet qui interagit
        isGrab = true;
    }

    private void DropJoystick(SelectExitEventArgs args)
    {
        transform.localRotation = originalRotation;
        sideToSlideTilt = 0;
        forwardBackwardTilt = 0;
        usedGo = null;
        isGrab = false;
    }

    /*public static float RestrictAngle(float angle, float angleMin, float angleMax)
    {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;
        return angle;
    }*/



    private void OnTriggerStay(Collider other)
    {
       if (other.gameObject.CompareTag("ZDFront"))
        {
            cockpit.transform.Rotate(new Vector3( -speedRotateFB,0,0) * Time.deltaTime, Space.World);
        }

        else if (other.gameObject.CompareTag("ZDLeft"))
        {
            cockpit.transform.Rotate(new Vector3(0,-speedRotateLR,0) * Time.deltaTime, Space.World);
        }

        else if (other.gameObject.CompareTag("ZDBack"))
        {
            cockpit.transform.Rotate(new Vector3(speedRotateFB,0,0) * Time.deltaTime, Space.World);
        }

        else if (other.gameObject.CompareTag("ZDRight"))
        {
            cockpit.transform.Rotate(new Vector3(0, speedRotateLR, 0) * Time.deltaTime, Space.World);
        }

        cockpit.transform.eulerAngles = new Vector3(cockpit.transform.eulerAngles.x, cockpit.transform.eulerAngles.y, 0);
    }
}
