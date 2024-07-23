using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quets : MonoBehaviour
{
    
    [SerializeField] private GameObject dialog;
    [SerializeField] private GameObject[] dialogPanels;
    [SerializeField] private GameObject interractionUI;

    private bool active, next;
    private int current = 0;

    private void Start(){
        foreach (Transform child in dialog.transform) {
            dialogPanels = Append(dialogPanels, child.gameObject);
        }
    }

    private GameObject[] Append(GameObject[] array, GameObject item){
        GameObject[] result = new GameObject[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = array[i];
        }
        result[result.Length - 1] = item;
        return result;
    }

    private void Inputs(){
        if (active){
            next = Input.GetKeyDown(KeyCode.Space);
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.tag == "Player"){
            active = true;
            interractionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player"){
            active = false;
            interractionUI.SetActive(false);
            current = 0;
        }
    }

    private void Logic(){
        if (next){
            current++;
            if (current > dialogPanels.Length - 1){
                current = 0;
            }
        }
    }

    private void Draw(){
        for (int i = 0; i < dialogPanels.Length; i++)
        {
            dialogPanels[i].SetActive(false);
            if (i == current){
                dialogPanels[i].SetActive(true);
            }
        }
    }

    private void Update(){
        Inputs();
        Logic();
        Draw();
    }

}
