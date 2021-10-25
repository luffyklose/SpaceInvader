////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: BulletMangager.cs
//Author: Zihan Xu
//Student Number: 101288760
//Last Modified On : 10/18/2021
//Description : Class for bullet manager. Manager all the bullets using object pool
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public BulletFactory bulletFactory;
    public int MaxBullets;

    private Queue<GameObject> m_bulletPool;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fuction Name: Start
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Build a bullet pool when the game starts
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        _BuildBulletPool();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fuction Name: BuildBulletPool
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Build a bullet pool using queue based on max bullets number which is set by player
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void _BuildBulletPool()
    {
        // create empty Queue structure
        m_bulletPool = new Queue<GameObject>();

        for (int count = 0; count < MaxBullets; count++)
        {
            var tempBullet = bulletFactory.createBullet();
            m_bulletPool.Enqueue(tempBullet);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fuction Name: GetBullet
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Get a bullet from bullet pool and set it to passed position
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = m_bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fuction Name: HasBullets
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Check if there's any bullet in bullet pool
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool HasBullets()
    {
        return m_bulletPool.Count > 0;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Fuction Name: ReturnBullet
    //Author: Zihan Xu
    //Student Number: 101288760
    //Last Modified On : 10/18/2021
    //Description : Put a bullet from active to bullet pool
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        m_bulletPool.Enqueue(returnedBullet);
    }
}
