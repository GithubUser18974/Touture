using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapStadsButtons;
    public Transform player;
    public NavMeshAgent playerAgent;
    public void GotoStand(Transform standPos)
    {
        player.position = standPos.position;
        playerAgent.SetDestination(standPos.position);
    }
    public void Search(Text searchInputField)
    {
        if (string.IsNullOrEmpty(searchInputField.text))
        {
            HideAllTheMapButtons(true);
        }
        else
        {
            HideForSearch(searchInputField.text);
        }
    }
    public void HideAllTheMapButtons(bool state)
    {
        foreach (GameObject i in mapStadsButtons)
        {
            i.SetActive(state);
        }
    }
    public void HideForSearch(string userInput)
    {
        foreach (GameObject i in mapStadsButtons)
        {
            if (i.name.ToLower().Contains(userInput.ToLower()))
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }
        }
    }
}
