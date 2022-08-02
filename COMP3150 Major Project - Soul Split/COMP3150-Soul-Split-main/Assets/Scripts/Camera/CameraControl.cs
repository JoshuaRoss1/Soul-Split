using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    PlayerInput inputControls;
    //float mouseScrollY;

    public float defaultSize = 3f;
    public float zoomOutSize = 5f;
    private float increment;
    private float currentSize;
    private Camera cameraControl;

    /* Ok so the input is read in the Scrolling function. It would be easiest to use the placeholder function and feed
     * that into the input reading. To help you understand the input reading goes like this.
     * 
     * inputControls.actions["INSERT ACTION HERE"].performed += CONTEXT => INSERT FUNCTION HERE
     * 
     * So add your stuff into the placeholder function then replace the last part of the input reading after the lambda =>
     * with the function.
     * 
     * So it would be inputControls.actions["MouseScrollY"].performed =+ ctx => PLACEHOLDERFUNCTION();
     * 
     * Then the function will execute when the mouse wheel is scrolling.
     * One last thing, the values of the scrolling wheel are:
     *      Mouse Scrolling Up: 120
     *      Mouse Scrolling Down: -120
     *      No Scrolling: 0
     * No idea why it's 120 but it is what it is haha
     */



    void Awake()
    {
        inputControls = player.GetComponent<PlayerInput>();
        cameraControl = this.GetComponent<Camera>();
        if (defaultSize > zoomOutSize){
            defaultSize = zoomOutSize -2;
        }
        increment = (zoomOutSize - defaultSize) / 10;
    }

    void Update()
    {
        Scrolling();


        //Debug.Log(transform.position.z);
    }

    void Scrolling()
    {
        //This gets the input action and when it's performed it calls the function at the end.
        //What this does at the moment is it reads the float value from the scrolling mouse and stores is in mouseScrollY
        inputControls.actions["MouseScrollY"].performed += ctx => Zoom(ctx.ReadValue<float>());
    }

    //PLACEHOLDER FUNCTION
    void Zoom(float y)
    {
        if (y > 0) //up
        {
            IncrementScroll(true);
        }
        else if (y < 0) //down
        {
            IncrementScroll(false);
        }
        else
        {
            //Debug.Log("=0");
        }
    }

    void IncrementScroll(bool zoomIn)
    {
        currentSize = cameraControl.orthographicSize;
        if (zoomIn && currentSize > defaultSize)
        {
            cameraControl.orthographicSize = currentSize -= increment;
        }
        if (!zoomIn && currentSize < zoomOutSize)
        {
            cameraControl.orthographicSize = currentSize += increment;
        }
    }

    #region - Enable / Disable InputControls

    private void OnEnable()
    {
        inputControls.actions.Enable();
    }

    private void OnDisable()
    {
        inputControls.actions.Disable();
    }

    #endregion
}
