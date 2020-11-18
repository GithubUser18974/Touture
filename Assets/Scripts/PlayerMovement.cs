using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed, rotationSpeed, rotationSmoothniss;
    //public Animator animator;
    float verticalValue;
    public Transform cam;
    //public GameObject menuCanvas;
    private static PlayerMovement _instance;
    public bool canMove = true;
    //public CharacterController CC;
    //public Transform[] startPosition_transform;
    //public Transform defaultPosition;

    public static PlayerMovement Instance

    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerMovement>();
            }

            return _instance;
        }
    }



    void Start()
    {
        //animator = GameObject.FindGameObjectWithTag(PlayerPrefs.GetString("userAv")).GetComponent<Animator>();
      //  CC = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //int startFromWhere = PlayerPrefs.GetInt("pos");
        //if (startFromWhere == -1)
        //{
        //    transform.position = defaultPosition.position;
        //    transform.rotation = defaultPosition.rotation;
        //}
        //else
        //{
        //    transform.position = startPosition_transform[startFromWhere].position;
        //    transform.rotation = startPosition_transform[startFromWhere].rotation;
            
        //}
    }
    public AudioSource adu;
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            verticalValue = Input.GetAxis("Vertical");
            //animator.SetFloat("run", verticalValue);
            if (verticalValue > 0)
            {
               transform.position += transform.forward * verticalValue * moveSpeed * Time.deltaTime;
                transform.localRotation = Quaternion.Lerp(transform.localRotation, cam.rotation, rotationSmoothniss * Time.deltaTime);
                //if (adu.enabled == false)
                //{
                //    adu.enabled = true;
                //    if (adu.isPlaying == false)
                //    {
                //        adu.Play();
                //    }
                //}
                // CC.Move(new Vector3(verticalValue * moveSpeed * Time.deltaTime,0, 0 ));

            }
            else
            {
                //adu.enabled = false;
            }
        }
        else
        {
           
                //adu.enabled = false;
            
        }
    }
}
