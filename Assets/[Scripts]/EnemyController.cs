////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: EnemyController.cs
//Author: Zihan Xu
//Student Number: 101288760
//Last Modified On : 10/18/2021
//Description : Class for Enemy
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    public float direction;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fucntion Name: Update
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Update every frame. Implement enemy's move and check if the enemy touches the border
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
    //Description : The enemy moves up and down every frame
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void _Move()
    {
        transform.position += new Vector3(0.0f,verticalSpeed * direction * Time.deltaTime, 0.0f);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fucntion Name: CheckBounds
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Change direction when the enemy touches the border of screen
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.y >= verticalBoundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.y <= -verticalBoundary)
        {
            direction = 1.0f;
        }
    }
}
