////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: PlayerController.cs
//Author: Zihan Xu
//Student Number: 101288760
//Last Modified On : 10/18/2021
//Description : Class for player
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    [FormerlySerializedAs("horizontalBoundary")] [Header("Boundary Check")]
    public float verticalBoundary;

    [FormerlySerializedAs("verticalSpeed")] [Header("Player Speed")]
    public float verticalSpeed;
    public float maxSpeed;
    public float horizontalTValue;

    [Header("Bullet Firing")]
    public float fireDelay;
    public float fireInterval;
    public GameObject ButtetSpawner;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fuction Name: Start
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Set some necessary parameter
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fucntion Name: Update
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Update every frame. Implement player's move and check if the player touches the border.
    //Fire a bullet when cold down is over.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fuction Name: FireBullet
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Create a new bullet every certain time
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
     private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % fireInterval == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(ButtetSpawner.transform.position);
        }
    }

     ////////////////////////////////////////////////////////////////////////////////////////////////////////
     //Fucntion Name: Move
     //Author: Zihan Xu
     //Student Number: 101288760
     //Last Modified On : 10/18/2021
     //Description : The player's ship moves where the player touches on screen. Or move based on keyboard input
     ////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.y > transform.position.y)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.y < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support
        if (Input.GetAxis("Vertical") >= 0.1f) 
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Vertical") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (m_touchesEnded.y != 0.0f)
        {
           transform.position = new Vector2(transform.position.x,Mathf.Lerp(transform.position.y, m_touchesEnded.y, horizontalTValue));
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(0.0f,direction * verticalSpeed);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fucntion Name: CheckBounds
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Stop when the player's ship touches the border
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void _CheckBounds()
    {
        // check right bounds
        if (transform.position.y >= verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, verticalBoundary, 0.0f);
        }

        // check left bounds
        if (transform.position.y <= -verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, -verticalBoundary, 0.0f);
        }

    }
}
