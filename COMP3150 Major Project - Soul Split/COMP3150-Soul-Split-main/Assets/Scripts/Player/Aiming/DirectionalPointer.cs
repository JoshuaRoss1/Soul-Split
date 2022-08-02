using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class DirectionalPointer : MonoBehaviour
{
    PlayerInput mouseControls;
    PlayerInput gamepadControls;
    bool controllerEnabled = true;
    bool keyboardEnabled;
    [HideInInspector]
    public Vector2 lookPosition;
    public Vector2 lookPosition2;
    [HideInInspector]
    public Vector2 direction;
    public Vector2 direction2;

    private void Awake()
    {
        mouseControls = GameObject.Find("Player").GetComponent<PlayerInput>();
        gamepadControls = GameObject.Find("Player").GetComponent<PlayerInput>();

    }

    void Update()
    {        
        gamepadControls.actions["ProjectionAimController"].performed += ctx => lookPosition = ctx.ReadValue<Vector2>();
        direction = new Vector2(lookPosition.x - transform.localPosition.x, lookPosition.y - transform.localPosition.y);
        //Debug.Log(direction.ToString());

        mouseControls.actions["MousePos"].performed += ctx => lookPosition2 = ctx.ReadValue<Vector2>();
        direction2 = Camera.main.ScreenToWorldPoint(lookPosition2) - transform.position;
        //Debug.Log(direction.x.ToString() + ", " + direction.y.ToString());



        InputSystem.onDeviceChange +=
        (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    controllerEnabled = true;
                    break;
                case InputDeviceChange.Disconnected:
                    Debug.Log("Device Unplugged");
                    controllerEnabled = false;
                    break;
                case InputDeviceChange.Reconnected:
                    controllerEnabled = true;
                    break;
                case InputDeviceChange.Removed:
                    // Remove from Input System entirely; by default, Devices stay in the system once discovered.
                    controllerEnabled = false;
                    break;
                default:
                    // See InputDeviceChange reference for other event types.
                    controllerEnabled = true;
                    break;
            }
        };




        // Debug.Log("Controller Enabled?: " + controllerEnabled);

        if (Mathf.Abs(direction.x) < 0.5 && Mathf.Abs(direction.y) < 0.5)
        {
            direction = direction2;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 80 * Time.deltaTime);

    }

    private void OnEnable()
    {
        mouseControls.actions.Enable();
        gamepadControls.actions.Enable();

    }

    private void OnDisable()
    {
        if (gamepadControls != null)
        {
            gamepadControls.actions.Disable();
        }
        if (mouseControls != null)
        {
            mouseControls.actions.Disable();
        }            
    }
}
