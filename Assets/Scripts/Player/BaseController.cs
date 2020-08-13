using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    
    public float sideSpeed = 8f, forwardSpeed = 15f;

    public float accelerated = 15f, deaccelerated = 10f;

    public float lowSoundPitch, normalSoundPitch, highSoundPitch;

    public AudioClip engineOnSound, engineOffSound;


    protected Vector3 speed;
    protected float rotationSpeed = 10f;


    private bool isSlow;

    private AudioSource soundManager;
    


    void Awake()
    {
        this.speed = new Vector3(0f, 0f, this.forwardSpeed);

        //Debug.Log($"Awake.Speed: {this.speed}");

        this.soundManager = this.GetComponent<AudioSource>();
    }

    protected enum MoveSpeedLevel
    {
        Slow, Normal, Fast
    }
    protected void Move(MoveSpeedLevel speedLevel = MoveSpeedLevel.Normal)
    {
        if(speedLevel == MoveSpeedLevel.Slow)
        {
            if (!this.isSlow)
            {
                this.isSlow = true;

                this.soundManager.Stop();
                this.soundManager.clip = this.engineOffSound;
                this.soundManager.volume = 0.5f;
                this.soundManager.Play();
            }

            this.speed = new Vector3(speed.x, 0f, this.deaccelerated);
        }
        else if (speedLevel == MoveSpeedLevel.Normal)
        {
            if (this.isSlow)
            {
                this.isSlow = false;

                this.soundManager.Stop();
                this.soundManager.clip = this.engineOnSound;
                this.soundManager.volume = 0.3f;
                this.soundManager.Play();
            }

            this.speed = new Vector3(speed.x, 0f, this.forwardSpeed);
        }
        else if (speedLevel == MoveSpeedLevel.Fast)
        {
            //if (!this.isSlow)
            //{
            //    this.isSlow = true;

            //    this.soundManager.Stop();
            //    this.soundManager.clip = this.engineOffSound;
            //    this.soundManager.volume = 0.5f;
            //    this.soundManager.Play();
            //}

            this.speed = new Vector3(speed.x, 0f, this.accelerated);
        }

    }

    protected void MoveForward()
    {
        this.speed = new Vector3(0f, 0f, this.speed.z);
    }

    protected void MoveSide(bool left)
    {
        this.speed = new Vector3((left ? -this.sideSpeed : this.sideSpeed) / 2f, 0f, this.speed.z);
    }
    
}
