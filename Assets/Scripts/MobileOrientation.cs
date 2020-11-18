using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MobileOrientation : MonoBehaviour
{
    public GameObject PC_MainMenu;
    public GameObject mobile_MainMenu;
    public static GameObject currentMainMenu;

    public Texture2D cursorHeadTexture;
    public Texture2D cursorFootTexture;
    public static Texture2D mycursorHeadTexture;
    public static Texture2D mycursorFootTexture;

    [Header("Enter 0 or 1 for this.. mouse-left=0, mouse-right=1 ")]
    public int mouserotateionControler = 1;
    public static int rotateControler;

    public Image CardStand;
    public static  Image myCardStand;

    private void Start()
    {
        if (DeviceType.Desktop == SystemInfo.deviceType)
        {
            currentMainMenu = PC_MainMenu;
        }
        else if (DeviceType.Handheld == SystemInfo.deviceType)
        {
            currentMainMenu = mobile_MainMenu;
        }
        else
        {
            currentMainMenu = mobile_MainMenu;

        }
        mycursorFootTexture = cursorFootTexture;
        mycursorHeadTexture = cursorHeadTexture;
        myCardStand = CardStand;
        if (mouserotateionControler >= 1)
            rotateControler = 1;
        else
            rotateControler = 0;
    }
    public ScreenOrientation screenOrientation;
    private void Awake()
    {
        Screen.orientation = screenOrientation;
    }
  
    public void GoToScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    public void GoToScene(string _Name)
    {
        SceneManager.LoadScene(_Name);
    }
}
