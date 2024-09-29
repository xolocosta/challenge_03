using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer sprR;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;

    private bool left, right, up, down;

    private void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Inputs();
        Move();
    }

    private void Inputs(){
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        up = Input.GetKey(KeyCode.W);
        down = Input.GetKey(KeyCode.S);
    }

    private void Move(){
        if (left){
            Movement(new Vector3(-1,0,0));
        }else if(right){
            Movement(new Vector3(1,0,0));
        }

        if (up){
            Movement(new Vector3(0,1,0));
        }else if(down){
            Movement(new Vector3(0,-1,0));
        }

        if (left || right || down || up) {
            Walk();
        }else{
            Idle();
        }

        RotateSprite();
    }

    private void Walk(){
        anim.SetBool("onWalk", true);
    }

    private void Idle(){
        anim.SetBool("onWalk", false);
    }

    private void RotateSprite(){
        if (left){
            Rotate(-1);
        }else if(right){
            Rotate(1);
        }
    }

    private void Rotate(float angle){
        transform.localScale = new Vector3(angle, 1.0f, 1.0f);
    }

    private void Movement(Vector3 direction){
        // transform.position += direction * speed * Time.deltaTime;
        rb.AddForce(direction * speed * Time.deltaTime);
    }
}
