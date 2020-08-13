using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : BaseController
{
    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.MovementController();
    }
    void FixedUpdate()
    {
        this.MoveVehicle();

        //Debug.Log($"Speed: {this.speed}");
    }



    void MoveVehicle()
    {
        this.rb.MovePosition(this.rb.position + this.speed * Time.deltaTime);
    }

    void MovementController()
    {
        if(
            Input.GetKey(KeyCode.LeftArrow) || 
            Input.GetKey(KeyCode.A))
        {
            this.MoveSide(true);
        }
        if (
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.D))
        {
            this.MoveSide(false);
        }
        if (
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.W))
        {
            Move(MoveSpeedLevel.Fast);
        }
        if (
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.S))
        {
            Move(MoveSpeedLevel.Slow);
        }






        if (
            Input.GetKeyUp(KeyCode.LeftArrow) ||
            Input.GetKeyUp(KeyCode.A))
        {
            MoveForward();
        }
        if (
            Input.GetKeyUp(KeyCode.RightArrow) ||
            Input.GetKeyUp(KeyCode.D))
        {
            MoveForward();
        }


        if (
            Input.GetKeyUp(KeyCode.UpArrow) ||
            Input.GetKeyUp(KeyCode.W))
        {
            Move(MoveSpeedLevel.Normal);
        }

        if (
            Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.S))
        {
            Move(MoveSpeedLevel.Normal);
        }
    }
}
