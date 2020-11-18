using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class NearMe : MonoBehaviour
{

   public GameObject pdfCanvas;
    //[Header("Drag and drop Stand Video ")]
    //public MediaPlayer audioSource;
    bool amIN = false;
    [Header("Enter video Name MUST be MP4 ")]
    public string StandVideoURL;
    [Header("Enter Customer Link ")]
    public Sprite StandCardURL;
    [Header("Enter Document Link ")]
    public string StandDocumentURL;
    [Header("Drag and drop  Thmubnail ")]
    public Sprite Thumpnai;
    [Header("Dont Change")]
    public Image MainSourceThumpnail;
    private void Start()
    {
        amIN = false;
        pdfCanvas = MobileOrientation.currentMainMenu;
        MainSourceThumpnail.sprite = Thumpnai;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"&&amIN==false)
        {
            amIN = true;
            if (MobileOrientation.currentMainMenu.activeSelf == false)
            {
                MobileOrientation.currentMainMenu.SetActive(true);
            }
            //if (audioSource.enabled == false)
            //{
            //    audioSource.enabled = true;
            //    audioSource.Play();

            //}
        }
        OnlineVideoManager.URL = StandVideoURL;
        OnlineVideoManager.DocumentURL = StandDocumentURL;
        MobileOrientation.myCardStand.sprite = StandCardURL;
    }

    private void OnTriggerExit(Collider other)
    {
        amIN = false;
        //audioSource.enabled = false;
        //audioSource.Pause();
        OnlineVideoManager.URL = null;
        OnlineVideoManager.CardURL = null;
        OnlineVideoManager.DocumentURL = null;
        MobileOrientation.currentMainMenu.SetActive(false);

    }
    public void SetZone(GameObject zone)
    {
        NearMe neer = zone.gameObject.GetComponent<NearMe>();
      
            if (MobileOrientation.currentMainMenu.activeSelf == false)
            {
            MobileOrientation.currentMainMenu.SetActive(true);
            }
        OnlineVideoManager.URL = neer.StandVideoURL;
        OnlineVideoManager.DocumentURL = neer.StandDocumentURL;

        MobileOrientation.myCardStand.sprite = neer.StandCardURL;
    }
    public void DenyZone()
    {
        OnlineVideoManager.URL = null;
        OnlineVideoManager.CardURL = null;
        OnlineVideoManager.DocumentURL = null;
        MobileOrientation.currentMainMenu.SetActive(false);
    }
}
