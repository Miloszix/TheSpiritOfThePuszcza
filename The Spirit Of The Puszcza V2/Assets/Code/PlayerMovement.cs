using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    public Rigidbody2D rigidbody;

    public Animator animator;

    public Transform obj;
    public Camera maincamera;
    Vector2 objpos;
    Vector2 mousepos;

    float mousex;
    float mousey;

    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        objpos = obj.transform.position;//gets player position
	    mousepos = Input.mousePosition;//gets mouse postion
	    mousepos = maincamera.ScreenToWorldPoint (mousepos);
	    mousex = mousepos.x - objpos.x;//gets the distance between object and mouse position for x
	    mousey = mousepos.y - objpos.y;//gets the distance between object and mouse position for y  if you want this.


        animator.SetFloat("Horizontal", mousex);
        animator.SetFloat("Vertical", mousey);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate() 
    {
        rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
    }
}
