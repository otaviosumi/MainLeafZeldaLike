using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject cameraObject;
    public GameObject playerObject;

    //public List<Transform> FixedCameraPositionList = new List<Transform>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }



    public void SetFixedCamera(Transform cameraFixedPosition)
    {
        //GameObject cameraObject = Camera.main.gameObject;
        cameraObject.GetComponent<MouseLook>().enabled = false;
        cameraObject.GetComponent<Camera>().fieldOfView = 90;
        cameraObject.transform.parent = cameraFixedPosition;
        cameraObject.transform.localPosition = Vector3.zero;
        cameraObject.transform.localRotation = Quaternion.identity;
        //Debug.Log("Rotation: " + Mathf.Ceil(cameraFixedPosition.localEulerAngles.y));
        playerObject.transform.localRotation = Quaternion.Euler(0f, Mathf.Ceil(cameraFixedPosition.localEulerAngles.y), 0f);
    }

    public void UnsetFixedCamera()
    {
        cameraObject.GetComponent<MouseLook>().enabled = true;
        cameraObject.GetComponent<Camera>().fieldOfView = 60;
        cameraObject.transform.parent = playerObject.transform;
        cameraObject.transform.localPosition = new Vector3(0f, 2f, -2f);
        cameraObject.transform.localRotation = Quaternion.Euler(10f, 0f, 0f);
    }
}
