using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider rearRight;
    [SerializeField] WheelCollider rearLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform rearRightTransform;
    [SerializeField] Transform rearLeftTransform;

    public float acceleration = 500f;
    public float breakingForce = 500f;
    public float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //forward/reverse
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        //Brake
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breakingForce;
        }else
        {
            currentBreakForce = 0f;
        }
        //Acceleration
        rearRight.motorTorque = currentAcceleration;
        rearLeft.motorTorque = currentAcceleration;

        //apply braking force to all wheels
        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        rearRight.brakeTorque = currentBreakForce;
        rearLeft.brakeTorque = currentBreakForce;

        //take care of the steering
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        //Update wheel meshes
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(rearRight, rearRightTransform);
        UpdateWheel(rearLeft, rearLeftTransform);

    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        // Get wheel collider state
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);


        trans.position = position;
        trans.rotation = rotation;
    }
}
