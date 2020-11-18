using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovemnetSystem : MonoBehaviour
{
    public LayerMask theGround;
    public LayerMask TheWalls;
    public LayerMask UI;
    public NavMeshAgent Player;
    private Touch initTouch = new Touch();
    public Camera playerCamera;
    public float playerOrientation_X = 0f;
    public float playerOrientation_Y = 0f;
    private Vector3 OriginalRotat;
    public float PlayerRotateSpeed = 0.1f;
    public float playerDirection = -1;
    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;


    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern bool IsMobile();
    public bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
#endif
        return false;
    }
    public bool isMobilee = false;
    private void Start()
    {
        xAngle = 0;
        yAngle = 0;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
        bool deviceIsIpad = SystemInfo.deviceType.ToString().ToLower().Contains("iPad");
        print(SystemInfo.deviceType.ToString().ToLower());
        if (isMobile())
        {
            variableJoystick.gameObject.SetActive(true);
            isMobilee = true;
        }
        else if(deviceIsIpad || SystemInfo.deviceType == DeviceType.Unknown)
        {
            variableJoystick.gameObject.SetActive(true);
            isMobilee = true;
        }
       else if (SystemInfo.deviceType==DeviceType.Desktop)
        {
            variableJoystick.gameObject.SetActive(false);
            isMobilee = false;
        }
    }

    private void FixedUpdate()
    {
        // playerMove();
        if (isMobilee)
        {
            // PlayerMovement();
            if (playerMobileMOving)
            {
                Player.velocity = playerCamera.transform.forward * playerSpeed * Time.deltaTime;

            }
        }
        else
        {
            playerMove();
        }

    }
    public void NewMobile()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                FirstPoint = Input.GetTouch(0).position;
                xAngleTemp = xAngle;
                yAngleTemp = yAngle;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                SecondPoint = Input.GetTouch(0).position;
                xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
            }
        }
    }
    public void MObileNavigations()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = initTouch.position.x - touch.position.x;
                float deltaY = initTouch.position.y - touch.position.y;
                playerOrientation_X -= deltaY * Time.deltaTime * PlayerRotateSpeed * playerDirection;
                playerOrientation_Y += deltaX * Time.deltaTime * PlayerRotateSpeed * playerDirection;
                playerOrientation_X = Mathf.Clamp(playerOrientation_X, -45f, 45f);
                playerCamera.transform.eulerAngles = new Vector3(playerOrientation_X, playerOrientation_Y, 0);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }
    bool canMOve = true;
    public void SetPlayerMOve(bool state)
    {
        canMOve = state;
    }
    public GameObject variableJoystick;
    public Rigidbody rb;
    public float playerSpeed;
    Vector3 direction;
    bool playerMobileMOving = false;
    public void PlayerMovement()
    {
        playerMobileMOving = true;
    }

    public void StopPlayer()
    {
        Player.velocity = Vector3.zero;
        playerMobileMOving = false;

    }



    public Transform FootSteps;
    public CursorMode curserModes;
    public void playerMove()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0) && canMOve)
            {
                            
                if (Physics.Raycast(myRay, out hit, 7, theGround))
                {
                    Player.SetDestination(hit.point);
                }
            }
            else
            {
                if (!isPointToUI) { 
                
               
                    if (Physics.Raycast(myRay, out hit,10, theGround) && Input.GetMouseButton(0) == false)
                    {
                        Cursor.SetCursor(null, Vector2.zero,CursorMode.Auto);
                        FootSteps.gameObject.SetActive(true);
                        FootSteps.position = new Vector3(hit.point.x, FootSteps.position.y, hit.point.z);
                    }

                    else
                    {
                        Cursor.SetCursor(MobileOrientation.mycursorHeadTexture, Vector2.zero,curserModes);
                        FootSteps.gameObject.SetActive(false);

                    }
                }
            }
           
        }
       
    }
    bool isPointToUI=false;
    public void CursorInUI(bool state)    {
        isPointToUI = state;
        if (state)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            FootSteps.gameObject.SetActive(false);

        }

    }
    public void PC_MOve_Arrows()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Player.velocity = playerCamera.transform.forward * playerSpeed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            Player.velocity = playerCamera.transform.right * -1 * playerSpeed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            Player.velocity = playerCamera.transform.forward * -1 * playerSpeed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            Player.velocity = playerCamera.transform.right * playerSpeed * Time.deltaTime;

        }
    }
    public static bool IsDoubleTap()
    {
        bool result = false;
   

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch(0).deltaTime;
            float DeltaPositionLenght = Input.GetTouch(0).deltaPosition.magnitude;

            if (DeltaTime > 0 && DeltaTime < 1 && DeltaPositionLenght < 1)
                result = true;
        }
        return result;
    }

}
