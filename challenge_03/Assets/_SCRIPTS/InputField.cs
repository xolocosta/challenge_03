using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputField : MonoBehaviour
{
    [SerializeField] private string answer;
    [SerializeField] private GameObject player;

    [SerializeField] private bool active;

    [SerializeField] TMP_InputField inputField;

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        //player.GetComponent<Answers>().SetVisibility(false);

    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.tag == "Player"){
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player"){
            active = false;
            //player.GetComponent<Answers>().SetVisibility(false);
        }
    }

    public void myTextChanged(string newText)
    {
        inputField.onValueChanged.RemoveListener(myTextChanged);

        inputField.text = newText;
        answer = newText;


        inputField.onValueChanged.AddListener(myTextChanged);
    }

    private void Update(){
        inputField.onValueChanged.AddListener(myTextChanged);

        if (active){
            if (Input.GetKeyDown(KeyCode.Space)){
                player.GetComponent<Answers>().SetAnswer(answer);   
                //player.GetComponent<Answers>().SetVisibility(true);
            }
        }
    }
}
