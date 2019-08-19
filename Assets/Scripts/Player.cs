using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed;
    public float jumpSpeed = 8f;
    public float gravity = -30f;
    public Joystick joystick;
    public Combat combat;

    private float _currentSpeed;
    private float _currentJumpHeight;
    private bool _isJumping;
    //private bool _walk; ~~~~TESTING~~~~
    //private bool _run; ~~~~TESTING~~~~
    private static bool _canMove;
    private CharacterController controller;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        combat = GetComponent<Combat>();
        _canMove = true;
        _isJumping = false;
        _currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // ~~~~~ USING KEYBOARD FOR MOVEMENT ~~~~~
        //float inputH = Input.GetAxis("Horizontal"); ~~~~TESTING~~~~
        //float inputV = Input.GetAxis("Vertical"); ~~~~TESTING~~~~

        if (_canMove)
        {
            Vector3 inputDir = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            // ~~~~~ UNCOMMENT THE LINE BELOW IF USING KEYBOARD FOR MOVEMENT ~~~~~~
            //Vector3 inputDir = new Vector3(inputH, 0, inputV); ~~~~TESTING~~~~
            inputDir = transform.TransformDirection(inputDir);

            #region Coding History
            /*  ~~~~TESTING~~~~
            if (_walk)
            {
                _currentSpeed = walkSpeed;
                _run = false;
            }

            if (_run)
            {
                _currentSpeed = runSpeed;
                _walk = false;
                Debug.Log("RUUUUNNN");
            }
                ~~~~TESTING~~~~
            */
            #endregion

            Move(inputDir.x, inputDir.z, _currentSpeed);

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

    public void Jump()
    {
        if (controller.isGrounded)
        {
            _isJumping = true;
            _currentJumpHeight = jumpSpeed;

            moveDirection.y = 0f;

            if (_isJumping)
            {
                moveDirection.y = _currentJumpHeight;
                _isJumping = false;
            }
        }
    }

    public void Run()
    {
        _currentSpeed = runSpeed;
    }

    public void Walk()
    {
        _currentSpeed = walkSpeed;
    }

    public void Aim()
    {
        Debug.Log("Aim");
    }

    public void Shoot()
    {
        combat.Shoot();
    }
}
