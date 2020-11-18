using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityTemplateProjects;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    public SimpleCameraController cameraController;

    bool isMobilee = false;
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
#endif
        return false;
    }
    private void Start()
    {
        if (isMobile())
        {
            variableJoystick.gameObject.SetActive(true);
            cameraController.enabled = false;
            isMobilee = true;
        }
        else
        {
            variableJoystick.gameObject.SetActive(false);
            cameraController.enabled = true;
            isMobilee = false;
        }
    }
    float tempX = 0.0f;
    public void FixedUpdate()
    {
        //tempX = Mathf.Clamp(variableJoystick.Vertical, -20f, 20f);

        //Vector3 direction = Vector3.up * variableJoystick.Horizontal + Vector3.left * tempX;

        //transform.localEulerAngles += (direction * speed * Time.deltaTime);


        //direction = Vector3.left * variableJoystickLeft.Vertical;
        //transform.localEulerAngles += (direction * speed * Time.deltaTime);
        // rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (isMobilee)
        {
            Test();
        }

    }
    float playerOrientation_X, playerOrientation_Y;
    public void Test()
    {

        playerOrientation_X -= variableJoystick.Vertical * Time.deltaTime * speed ;
        playerOrientation_Y += variableJoystick.Horizontal * Time.deltaTime * speed ;
        playerOrientation_X = Mathf.Clamp(playerOrientation_X, -35f, 35f);
         transform.eulerAngles = new Vector3(playerOrientation_X, playerOrientation_Y, 0);
    }
}