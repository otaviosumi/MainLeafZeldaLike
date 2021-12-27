using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxCollider : MonoBehaviour
{
    public Transform boxCheck;
    public float boxDistance = 0.4f;

    public GameObject boxToMove = null;
    private void Update()
    {
        var colliders = Physics.OverlapSphere(boxCheck.position, boxDistance);
        foreach(Collider coll in colliders)
        {
            if(coll.gameObject.tag == "Box")
            {
                boxToMove = coll.gameObject;
                break;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(boxToMove);
            if (boxToMove != null)
            {
                boxToMove.GetComponent<Rigidbody>().useGravity = false;
                boxToMove.transform.parent = boxCheck.transform;
                //boxToMove.transform.position = Vector3.zero;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (boxToMove != null)
            {
                boxToMove.GetComponent<Rigidbody>().useGravity = true;
                boxToMove.transform.parent = null;
                boxToMove = null;
            }
        }
    }

}
