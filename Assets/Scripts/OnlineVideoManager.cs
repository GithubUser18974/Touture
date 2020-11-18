using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineVideoManager : MonoBehaviour
{
    public MediaPlayer videoPlayers;
    public static string URL = "";
    public static string DocumentURL = "";
    public static Sprite CardURL ;
    string relativePath = "/";
    public string currentURL;
    public GameObject VideoPlayerImage;
    public GameObject exitButton;
    public static MediaPlayer mainVidePlayer;
    public GameObject cardImagePanel;
    private void Start()
    {
        mainVidePlayer = videoPlayers;
    }
    public void PlayThisVedio(string url)
    {
        //if (url.Contains(".mp4"))
        //{
        //    videoPlayers.m_VideoLocation = MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder;
        //    videoPlayers.m_VideoPath = MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder+ url;
        //    videoPlayers.m_VideoLocation = MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder;
        //    //videoPlayers.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, url, true);
        //}
        //else
        //{
        //    //videoPlayers.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder,  url+".mp4", true);
        //    videoPlayers.m_VideoLocation = MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder;
        //    videoPlayers.m_VideoPath = MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder + url+".mp4";
        //    videoPlayers.m_VideoLocation = MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder;
        //}
        if (url.Contains(".mp4"))
            URL=url;
        else
            URL= url+".mp4";
        PlayThisVedioOnTheWall();
    }
    public void PlayThisVedio()
    {
        if (string.IsNullOrEmpty(URL))
        {
            return;
        }
        videoPlayers.m_VideoPath = URL;
        videoPlayers.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, URL, true);
        videoPlayers.Play();
    }
    bool isPlaying = false;
    public void PlayThisVedioOnTheWall()
    {
        isPlaying = !isPlaying;
        if (string.IsNullOrEmpty(URL))
        {
            return;
        }
        if (isPlaying)
        {
            videoPlayers.m_VideoPath = URL;
            videoPlayers.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, URL, true);
            videoPlayers.Play();
            isPlaying = false;
        }

    }
    public void StopVideoAndExit()
    {
        videoPlayers.Pause();
        VideoPlayerImage.SetActive(false);
        exitButton.SetActive(false);
    }
    public void OpenDocument()
    {
        if (string.IsNullOrEmpty(DocumentURL))
        {
            return;
        }
        Link.Field = DocumentURL;
        Link.OpenLinkJS();
    }
    public void OpenCard()
    {
        cardImagePanel.SetActive(true);
       
    }
 
}
