using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

    private void Start()
    {
        
    }

    void Update()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		
		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}
        
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		//Debug.Log("X: " + x + "Z: " + z);

        #region Animations tags
        int Zz = 0;
		int Xx = 0;
		if(z > 0)
        {
			Zz = 1;
        }else if (z < 0)
        {
			Zz = -1;
        }if(x > 0)
        {
			Xx = 1;
        }else if (x < 0)
        {
			Xx = -1;
        }
		playerAnimator.SetInteger("Vertical", Zz);
		playerAnimator.SetInteger("Horizontal", Xx);
		playerAnimator.SetFloat("horizontal", x);
		playerAnimator.SetFloat("vertical", z);

		playerAnimator.SetBool("airborne", !isGrounded);

        #endregion

        Vector3 move = transform.right * x + transform.forward * z;
		

		controller.Move(move * speed * Time.deltaTime);

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * (-2f) * gravity);
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
	}

}
