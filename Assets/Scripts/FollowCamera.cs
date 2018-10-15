using UnityEngine;
using System.Collections;

public abstract class FollowCamera : MonoBehaviour
{
    public Transform target;
    public bool followTarget = true;
    public bool mouseControl;
    public bool gamepadControl = true;
    public float dampingSpeed = 5f;                           // Camera speed when follow the target. 

    public event InputDeviceAxisEvent InputHandleAxisMethod;  // Camera must be controll using what input methed (mouse, gamepad, both);

    protected Vector3 centerOffset = Vector3.zero;
    protected Vector2 axisInput;

    public delegate void InputDeviceAxisEvent();

    public virtual void Start()
    {
        centerOffset = transform.position - target.position;

        if (mouseControl)
            InputHandleAxisMethod += GetMouseAxisInput;
        if (gamepadControl)        
            InputHandleAxisMethod += GetGamePadAxisInput;        
    }
    
    // Update is called once per frame
    public virtual void LateUpdate()
    {
        if (!followTarget)
            return;
        axisInput = Vector2.zero;
        InputHandleAxisMethod();

        FollowTarget();    
    }

    public abstract void FollowTarget();

    public void GetMouseAxisInput()
    {
        axisInput.x += Input.GetAxis("Mouse X");
        axisInput.y += Input.GetAxis("Mouse Y");
    }

    public void GetGamePadAxisInput()
    {
        axisInput.x += Input.GetAxis("Horizontal Right ThumbStick");
        axisInput.y += Input.GetAxis("Vertical Right ThumbStick");
    }
}
