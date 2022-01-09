using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject PlayerModel;
	public CharacterController controller;
	public Animator playerAnimator;

	public float speed = 12f;
	public float gravity = -9.81f;
	public float jumpHeight = 3f;

	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	public Vector3 velocity;
	public bool isGrounded;

    void Update()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}
        
		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");

		//Debug.Log("X: " + x + "Z: " + z);

        #region Animations tags
        if(z != 0 || x != 0)
        {
			if(z > 0)
            {
				if (x > 0)
				{
					PlayerModel.transform.localRotation = Quaternion.Euler(new Vector3(0f, 45, 0f));
				}
				if (x < 0)
				{
					PlayerModel.transform.localRotation = Quaternion.Euler(new Vector3(0f, 315f, 0f));
				}
				if(x == 0)
                {
					PlayerModel.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                }
            }else if(z < 0)
            {
				if (x > 0)
				{
					PlayerModel.transform.localRotation = Quaternion.Euler(new Vector3(0f, 135f, 0f));
				}
				if (x < 0)
				{
					PlayerModel.transform.localRotation = Quaternion.Euler(new Vector3(0f, 225f, 0f));
				}
				if (x == 0)
				{
					PlayerModel.transform.localRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
				}
            }else if(x > 0)
            {
				PlayerModel.transform.localRotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
            }else if(x < 0)
            {
				PlayerModel.transform.localRotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
            }
			playerAnimator.SetInteger("Vertical", 1);
        }
        else
        {
			//PlayerModel.transform.localRotation = Quaternion.Euler(Vector3.zero);
			playerAnimator.SetInteger("Vertical", 0);
		}

		playerAnimator.SetBool("airborne", !isGrounded);

        #endregion

        Vector3 move = transform.right * x + transform.forward * z;
		//Debug.Log(move);
		//controller.Move(move * speed * Time.deltaTime);
		controller.SimpleMove(move * speed);

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * (-2f) * gravity);
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
	}

}
