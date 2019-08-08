using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float RunSpeed;
    public float jumpSpeed = 8f;
    public float gravity = -30f;
    public bool _aboutToJump = false;
    public Joystick joystick;
    public Jump jump;
    [SerializeField] public CharacterController controller;
    [SerializeField] public Vector3 moveDirection;

    private float _currentSpeed;
    private float _currentJumpHeight;
    private bool _isJumping;    
    private static bool _canMove;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        _canMove = true;
        _currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        bool inputJump = Input.GetButtonDown("Jump");

        if (_canMove)
        {
            Vector3 inputDir = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            inputDir = transform.TransformDirection(inputDir);
            Move(inputDir.x, inputDir.z, _currentSpeed);

            if (controller.isGrounded)
            {
                jump.OnMouseDown();

                moveDirection.y = 0f;

                if (_isJumping)
                {
                    moveDirection.y = _currentJumpHeight;
                    _isJumping = false;
                }
            }


            moveDirection.y += gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    private void Move(float inputH, float inputV, float speed)
    {
        Vector3 direction = new Vector3(inputH, 0f, inputV);
        moveDirection.x = direction.x * speed;
        moveDirection.z = direction.z * speed;
    }

    public void Jump(float height)
    {
        _isJumping = true;
        _aboutToJump = false;
        _currentJumpHeight = height;
    }
}
