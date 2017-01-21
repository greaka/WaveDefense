﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;

public class MoveObjekts : MonoBehaviour
{
    public int speed;
    public int EnemyCount;
    public int health;
    public GameObject enemyPrefab;

    private PlayerStats playerStats;

    public Vector3[] positiona = new Vector3[5];

    public List<GameObject> Enemies = new List<GameObject>();

    public List<GameObject> DeadEnemies = new List<GameObject>();

    //public GameObject Waypoint;

    // Use this for initialization
    public void Start()
    {
        //hier die Weg punkte eintragen die die minions laufen sollen
        playerStats = GetComponent<PlayerStats>();

        for (var i = 0; i < EnemyCount; i++)
        {
            GameObject myGameObject = Instantiate(enemyPrefab);
            Enemies.Add(myGameObject);
            var myscript = myGameObject.GetComponent<Enemy>();
            myscript.Die += playerStats.OnEnemyDeath;
            myscript.Die += EnemyDeath;
        }

    }

    public void EnemyDeath(Enemy instance)
    {
        DeadEnemies.Add(instance.gameObject);
        Enemies.Remove(instance.gameObject);
    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
        {
            Sprite.Destroy(gameObject);
        }

        Vector3 position = this.transform.position;
        //Vector3 position1 = Waypoint.transform.position;
        int x = (int)position.x;
        int y = (int)position.y;
        position.x = x;
        position.y = y;/*
        if (n < positiona.Length)
        {
            for (int i = speed; i > 0; i--)
            {
                if (position.x < positiona[n].x)
                {
                    position.x++;
                }
                else if (position.x > positiona[n].x)
                {
                    position.x--;
                }
                else if (position.y < positiona[n].y)
                {
                    position.y++;
                }
                else if (position.y > positiona[n].y)
                {
                    position.y--;
                }

                else if(position.x==positiona[n].x&& position.y == positiona[n].y)
                {
                    n++;
                }



                this.transform.position = position;

            }

        }*/
    }
}


