using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpsticleVehicle : MonoBehaviour
{

    public float forwardSpeed = 6f;

    private Rigidbody rb;

    public OpsticleSpawner Spawner { get; set; }

    private bool beingDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        var speed = new Vector3(0, 0, -this.forwardSpeed);
        //Debug.Log($"moving at speed: {speed}, rot: {this.rb.rotation}");
        this.rb.MovePosition(this.rb.position + speed * Time.deltaTime);


        if(beingDestroyed == false)
        {
            if(this.Spawner != null)
            {
                this.beingDestroyed = this.transform.position.z < this.Spawner.transform.position.z;

                if (this.beingDestroyed)
                {
                    Destroy(this.gameObject, 2f);

                }
            }
            
        }
    }

}
