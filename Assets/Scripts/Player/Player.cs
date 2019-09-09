using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    public float walkSpeed = 4f; // walkSpeed stores walking speed of player
    public float runSpeed = 6f; // runSpeed stores running speed of player
    public float jumpHeight = 8f; // jumpSpeed stores jump height of player
    public float gravity = 30f; // graivity stores gravitation physics
    public bool canMove; // canMove stores whether the player can move or not
    public Joystick joystick; // joystick stores joystick

    private float _currentSpeed; // _currentSpeed stores the current speed of the player
    private float _currentJumpHeight; // _currentJumpHeight stores the current jump height of player
    private bool _isJumping; // _isJumping stores whether the player is in the air or not
    private CharacterController controller; // controller stores CharacterController player
    private Vector3 moveDirection; // moveDirection stores the direction of the player
    private PlatformManager platform; // platform stores PlatformManager
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get CharacterController from player
        canMove = false; // canMove is set to false because player can't move yet
        _isJumping = false; // _isJumping is set to false because player is on the ground
        _currentSpeed = walkSpeed; // _currentSpeed is set to walk speed
        platform = GameObject.Find("GameManager").GetComponent<PlatformManager>(); // Get PlatformManager from GameManager
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) // if player able to move
        {
            if (platform.PC) // if it is for PC
            {
                float inputH = Input.GetAxis("Horizontal"); // inputH stores Horizontal input (w, up arrow, s and down arrow).
                float inputV = Input.GetAxis("Vertical"); // inputV stores Vertical input (a, left arrow, d and right arrow).
                Movement(inputH, inputV, _currentSpeed); // Movement function is called. 
                Jump(); // Jump function is called
                Run(); // Run function is called
            }

            if (platform.Mobile)
            {
                Movement(joystick.Horizontal, joystick.Vertical, _currentSpeed); // Movement function is called.
            }

            moveDirection.y -= gravity * Time.deltaTime; // moveDirection.y stores the gravity value.
            controller.Move(moveDirection * Time.deltaTime); // move controller to moveDirection value, this will make the player move.
        }
    }

    private void Movement(float inputH, float inputV, float speed) // Movement function consists of 3 parameters, inputH, inputV and speed.
    {
        Vector3 direction = new Vector3(inputH, 0f, inputV); // direction stores new coordinates, when player presses horizontal or vertical inputs or when player move joystick.
        direction = transform.TransformDirection(direction); // direction stores the direction of the player facing to. 
        moveDirection.x = direction.x * speed; // moveDirection.x stores direction.x, this makes the game player x coordinates matches to vertical input or vertical position of joystick. It'll then * by speed to move the game player quickly in the x direction.
        moveDirection.z = direction.z * speed; // same thing but for y position. 
    }

    public void Jump() // Jump function
    {
        if (canMove) // when player can move.
        {      
            if (controller.isGrounded) // when player is on the ground.
            {
                if (platform.PC) // if it is in PC platform.
                {
                    bool inputJump = Input.GetButtonDown("Jump"); // inputJump stores Jump input (space bar).
                    if (inputJump) // if space bar is pressed. 
                    {
                        _isJumping = true; // _isJumping is set to true because player is about to jump.
                        _currentJumpHeight = jumpHeight; // _currentJumpHeight stores jumpHeight.
                    }
                }

                if (platform.Mobile) // if it is in Mobile platform.
                {
                    _isJumping = true; // // _isJumping is set to true because player is about to jump.
                    _currentJumpHeight = jumpHeight; // _currentJumpHeight stores jumpHeight.
                }

                moveDirection.y = 0f; // moveDirection.y is set to 0 because player is in the air, so gravitation should be off.

                if (_isJumping) // if player is jumping
                {
                    moveDirection.y = _currentJumpHeight; // moveDirection.y stores _currentJumpHeight.
                    _isJumping = false; // while the player is in the air, _isJumping is set to false
                }
            }
        }
    }

    public void Run()
    {
        if (canMove) // if player can move
        {
            if (platform.PC) // if it is in PC platform
            {
                bool inputRun = Input.GetKeyDown(KeyCode.LeftShift); // inputRun stores Left Shift key (when it is held down)
                if (inputRun) // if Left Shift key is held down
                {
                    _currentSpeed = runSpeed; // _currentSpeed set to runSpeed.
                }
            }

            if (platform.Mobile) // if it is in Mobile platform
            {
                _currentSpeed = runSpeed; // _currentSpeed set to runSpeed.
            }
        }
    }

    public void Walk()
    {
        if (canMove) // if player can move
        {
            if (platform.PC) // if it is in PC platform
            {
                bool inputWalk = Input.GetKeyUp(KeyCode.LeftShift); // inputRun stores Left Shift key (when it is released)
                if (inputWalk) // if Left Shift key is released
                {
                    _currentSpeed = walkSpeed; // _currentSpeed set to walkSpeed.
                }                
            }
            if (platform.Mobile) // if it is in Mobile platform
            {
                _currentSpeed = walkSpeed; // _currentSpeed set to walkSpeed.
            }
        }
    }
}
