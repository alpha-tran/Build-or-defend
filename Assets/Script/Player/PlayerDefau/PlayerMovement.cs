using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 3.5f;
    public float jumpHeight = 18f;
    public float jumpDuration = 0.85f;
    public float gravity = 9.8f;

    private float jumpTime = 0f;
    private bool isJumping = false;
    private bool isSprinting = false;
    private bool isCrouching = false;

    private float horizontal;
    private float vertical;
    private bool jump;
    private bool crouch;
    private bool sprint;

    public Animator anim;
    public CharacterController controller;

    private void Start()
    {
        if (anim == null) Debug.LogWarning("Animator component missing. Animations won't work.");
    }

    private void Update()
    {
        GetInputs();
        if (crouch) isCrouching = !isCrouching;
        if (controller.isGrounded && anim != null) HandleAnimations();
        if (jump && controller.isGrounded) isJumping = true;
        DetectHeadHit();
    }

    private void FixedUpdate()
    {
        Vector3 move = CalculateMovement();
        controller.Move(move);
    }

    private void GetInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetButtonDown("Jump");
        sprint = Input.GetButton("Fire3");
        crouch = Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.JoystickButton1);
    }

    private void HandleAnimations()
    {
        anim.SetBool("crouch", isCrouching);
        anim.SetBool("run", controller.velocity.magnitude > 0.9f);
        isSprinting = controller.velocity.magnitude > 0.9f && sprint;
        anim.SetBool("sprint", isSprinting);
        anim.SetBool("air", !controller.isGrounded);
    }

    private Vector3 CalculateMovement()
    {
        float speedMod = isSprinting ? sprintSpeed : (isCrouching ? -moveSpeed * 0.5f : 0);
        float moveX = horizontal * (moveSpeed + speedMod) * Time.deltaTime;
        float moveZ = vertical * (moveSpeed + speedMod) * Time.deltaTime;
        float moveY = 0;

        if (isJumping)
        {
            moveY = Mathf.SmoothStep(jumpHeight, jumpHeight * 0.3f, jumpTime / jumpDuration) * Time.deltaTime;
            jumpTime += Time.deltaTime;
            if (jumpTime >= jumpDuration)
            {
                isJumping = false;
                jumpTime = 0;
            }
        }

        moveY -= gravity * Time.deltaTime;

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        forward *= moveZ;
        right *= moveX;

        if (moveX != 0 || moveZ != 0)
        {
            float angle = Mathf.Atan2(forward.x + right.x, forward.z + right.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), 0.15f);
        }

        return new Vector3(0, moveY, 0) + forward + right;
    }

    private void DetectHeadHit()
    {
        Vector3 center = transform.TransformPoint(controller.center);
        float hitDist = controller.height / 2f * 1.1f;
        if (Physics.Raycast(center, Vector3.up, hitDist))
        {
            jumpTime = 0;
            isJumping = false;
        }
    }
}
