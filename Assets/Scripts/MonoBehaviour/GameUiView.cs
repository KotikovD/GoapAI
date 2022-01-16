using System;
using System.Collections;
using Entitas.Unity;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(EntityLink))]
public class GameUiView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _inventoryText;
    [SerializeField] private TextMeshProUGUI _agentText;
    
    public void SetInventoryText(string text)
    {
        _inventoryText.text = text;
    }
    
    public void SetAgentText(string text)
    {
        _agentText.text = text;
    }

    public void ClearAgentView()
    {
        SetAgentText("");
    }  
    
    public void ClearAllUi()
    {
        SetAgentText("");
        SetInventoryText("");
    }
    
    
    
}
