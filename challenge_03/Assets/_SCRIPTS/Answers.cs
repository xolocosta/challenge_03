using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI textUI;
    
    private string answer;
    
    public void SetAnswer(string value){
        textUI.text = value;
    }

    public string GetAnswer(){
        return answer;
    }

    public void SetVisibility(bool set)
    {
        if (set)
            textUI.text = answer;
        else
            textUI.text = "";
    }
}
