using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchController : MonoBehaviour
{
    public Vector3 crouchLocalScale;
    public GameObject playerObject;
    public float crouchHeight;
    public float crouchYSize;
    public CharacterController crouchCharacterController;

    private Vector3 originalLocalScale;
    private CharacterController originalCharacterController;
    void Start()
    {
        originalLocalScale = playerObject.transform.localScale;
        originalCharacterController = playerObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerObject.transform.localScale = crouchLocalScale;
            playerObject.transform.localPosition = new Vector3(playerObject.transform.localPosition.x, crouchLocalScale.y, playerObject.transform.localPosition.z);

            crouchCharacterController.height = crouchHeight;
            crouchCharacterController.center = new Vector3(0f, crouchYSize, 0f);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerObject.transform.localScale = originalLocalScale;
            playerObject.transform.localPosition= Vector3.zero;

            crouchCharacterController.height = 2f;
            crouchCharacterController.center = new Vector3(0f, 1f, 0f);
        }
    }
}
