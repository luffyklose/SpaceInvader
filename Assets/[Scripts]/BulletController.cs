////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: BulletController.cs
//Author: Zihan Xu
//Student Number: 101288760
//Last Modified On : 10/18/2021
//Description : Class for player's bullets
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IApplyDamage
{
    public float horizontalSpeed;
    public float horizontalBoundary;
    public BulletManager bulletManager;
    public int damage;
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fucntion Name: Start
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Find BulletManager
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fucntion Name: Update
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Update every frame. Implement bullet's move and check if the bullet is out of screen
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fucntion Name: Move
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : The bullet moves toward left every frame
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void _Move()
    {
        transform.position += new Vector3(horizontalSpeed, 0.0f, 0.0f) * Time.deltaTime;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fucntion Name: CheckBounds
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Check if the bullet has moved out of the screen totally
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void _CheckBounds()
    {
        if (transform.position.x > horizontalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fucntion Name: OnTriggerEnter2D
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Check if the bullet collides with enemy's ship. Return to object poll if so.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    public int ApplyDamage()
    {
        return damage;
    }
}
