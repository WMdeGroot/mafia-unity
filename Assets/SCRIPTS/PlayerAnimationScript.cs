using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    private Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isCrouchedHash;
    int isIdleAimHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isCrouchedHash = Animator.StringToHash("isCrouched");
        isIdleAimHash = Animator.StringToHash("idleAim");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool backwardPressed = Input.GetKey("s");
        bool runPressed = Input.GetKey("left shift");
        bool crouchPressed = Input.GetKey("left ctrl");
        bool aimPressed = Input.GetMouseButton(1);

        //if statement (walking)
        if (!isWalking && (forwardPressed || leftPressed || rightPressed || backwardPressed))
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && (!forwardPressed && !leftPressed && !rightPressed && !backwardPressed))
        {
            animator.SetBool(isWalkingHash, false);
        }

        //if statement (running)
        if (!isRunning && (forwardPressed && runPressed || leftPressed && runPressed || rightPressed && runPressed || backwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);

        }
        if (isRunning && (!forwardPressed && !runPressed || !leftPressed && !runPressed || !rightPressed && !runPressed || !backwardPressed && !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }

        //if statement (crouching)
        if (crouchPressed)
        {
            animator.SetBool(isCrouchedHash, true);
        }
        if (!crouchPressed)
        {
            animator.SetBool(isCrouchedHash, false);
        }

        //if statement (idleAim)
        if (aimPressed)
        {
            animator.SetBool(isIdleAimHash, true);
        }
        if (!aimPressed || (forwardPressed || leftPressed || rightPressed || backwardPressed))
        {
            animator.SetBool(isIdleAimHash, false);
        }
    }
}
