using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public static string  Field= "https://www.walmart.com/ip/Les-Adolescents-Coeur-d-Or-2nd-Edition-Paperback-9781927538036/406060447";

	public void OpenLink()
	{
		Application.OpenURL(Field);
	}

	public static void OpenLinkJS()
	{
#pragma warning disable CS0618 // Type or member is obsolete
        Application.ExternalEval("window.open('"+Field+"');");
#pragma warning restore CS0618 // Type or member is obsolete
    }

	public void OpenLinkJSPlugin()
	{
		#if !UNITY_EDITOR
		openWindow(Field);
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}