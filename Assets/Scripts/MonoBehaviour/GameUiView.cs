using Entitas.Unity;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(EntityLink))]
public class GameUiView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _inventoryText;
    [SerializeField] private TextMeshProUGUI _agentText;
    [SerializeField] private TextMeshProUGUI _agentPlanText;
 
    
    public void SetInventoryText(string text)
    {
        _inventoryText.text = text;
    }
    
    public void SetAgentText(string text)
    {
        _agentText.text = text;
    }

    public void SetAgentPlanText(string text)
    {
        _agentPlanText.text = text;
    }
    
    public void ClearAgentPlanView()
    {
        SetAgentPlanText("");
    }
    
    public void ClearAgentView()
    {
        SetAgentText("");
        SetAgentPlanText("");
    }  
    
    public void ClearAllUi()
    {
        SetAgentText("");
        SetInventoryText("");
        SetAgentPlanText("");
    }
    
    
    
}
