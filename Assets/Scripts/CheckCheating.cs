using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckCheating : MonoBehaviour
{
   public   string url = "https://raw.githubusercontent.com/mohamedaraby122/Validations/master/Romain.json";
    
    void Start()
    {
        Invoke("StartChecking", 20);
    }
    void StartChecking()
    {
        StartCoroutine(StartUrl());

    }
    IEnumerator StartUrl()
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            string s = www.text;
            if (s.Contains("false"))
            { CreateCheatingCanvas(); }
            
        }
    }
    Canvas myCanvas;
    GameObject myText;
    RectTransform rectTransform;
    Text text;

    public void CreateCheatingCanvas()
    {
        while (true)
        {
            GameObject g = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Capsule), Vector3.zero, Quaternion.identity);
        }
    }
}
