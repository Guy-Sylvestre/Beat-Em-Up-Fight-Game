using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMovement : MonoBehaviour
{
    //Declaration de variable interface
    private Rigidbody myBody;
    private CharacterAnimation player_Anim;

    //Declaration de variable public
    public float walk_Speed = 3f;
    public float z_Speed = 1.5f;

    //Declaration de variable private
    private float rotation_Y = -90f;
    private float rotation_Speed = 15f;

    void Awake(){
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }



    void Update()
    {
       RotatePlayer();
       AnimatePlayerWalk();
    }


    void FixedUpdate()
    {
        DetectMovement();
    }


    void DetectMovement()
    {
        float axeX = Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_Speed);
        float axeZ = Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-z_Speed);

        myBody.velocity = new Vector3(axeX, myBody.velocity.y, axeZ);
    }//Movement


    void RotatePlayer()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, rotation_Y, 0f);
        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f);
        }

    }//Rotation


    void AnimatePlayerWalk()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            player_Anim.Walk(true);
        }else
        {
            player_Anim.Walk(false);
        }
    }//Animate plyer walk


}//class
