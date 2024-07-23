using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject target;

    private void Start(){
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Move();
    }

    private void Move(){
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, speed * Time.deltaTime);
    }
}
