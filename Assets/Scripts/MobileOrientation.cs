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
    public Vector2 hotSpot = Vector2.zero;
    public static Texture2D mycursorHeadTexture;
    public static Texture2D mycursorFootTexture;


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
