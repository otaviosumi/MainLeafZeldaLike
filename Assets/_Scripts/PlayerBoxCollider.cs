using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxCollider : MonoBehaviour
{
    public Transform boxCheck;
    //public GameObject box;
    public float boxDistance = 0.4f;

    public GameObject boxToMove = null;
    private void Update()
    {
        var colliders = Physics.OverlapSphere(boxCheck.position, boxDistance);

        if (Input.GetMouseButtonDown(0))
        {
            foreach (Collider coll in colliders)
            {
                if (coll.gameObject.tag == "Box")
                {
                    boxToMove = coll.gameObject;
                    break;
                }
            }
            Debug.Log(boxToMove);
            if (boxToMove != null)
            {
                boxToMove.GetComponent<Rigidbody>().useGravity = false;
                boxToMove.GetComponent<Collider>().enabled = false;
                boxToMove.transform.parent = boxCheck;
                boxToMove.transform.localRotation = Quaternion.identity;
                Vector3 defaultPos = new Vector3(boxToMove.transform.localScale.x / 2f, -boxToMove.transform.localScale.x / 2f, boxToMove.transform.localScale.z / 2f);
                boxToMove.transform.localPosition = defaultPos;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (boxToMove != null)
            {
                boxToMove.GetComponent<Rigidbody>().useGravity = true;
                boxToMove.GetComponent<Collider>().enabled = true;
                boxToMove.transform.parent = null;
            }
            boxToMove = null;
        }
    }

}
