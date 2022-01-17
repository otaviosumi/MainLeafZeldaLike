using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomFloor : MonoBehaviour
{
    public UnityEvent enterFixedCamRoom;
    //public UnityEvent exitFixedCamRoom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Entering room...");
            enterFixedCamRoom.Invoke();
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exiting room...");
        exitFixedCamRoom.Invoke();
    }*/
}
