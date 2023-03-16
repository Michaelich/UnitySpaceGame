using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public static int difficulty=0;
    public float enemyForce = 1000f;
    public float upperbound = 8;
    public float leftbound = -7;
    public float rightbound = 7;
    public static int enemy_counter = 0;
    public float upenemy;
    public float sideenemy;
    private float pos_temp;
    public static int Score=0;
    public static int HighScore=415;
    private int param;
    private int offset;
    public int checker;

    void Start()
    {
        enemy_counter = 0;
        difficulty = 0;
        Score = 0;
    }

    void level(int offset, int param, int diff)
    {
        GameObject enemy = ObjectPool.SharedInstance2.GetPooledObject2();
        if (enemy != null)
        {
            enemy_counter+=1;
            if (param==0 || param==2)
            {
                pos_temp = Random.Range(2f,4f);
                
                if(param==0)
                {
                    enemy.transform.position = new Vector3(leftbound-offset,-0.4f,pos_temp);
                    enemy.transform.rotation = new Quaternion(0,0,0,1);
                    enemy.SetActive(true);
                    enemy.GetComponent<Rigidbody>().velocity= new Vector3(3+0.1f*diff,0,0);
                }
                else
                {
                    enemy.transform.position = new Vector3(rightbound+offset,-0.4f,pos_temp);
                    enemy.transform.rotation = new Quaternion(0,0,0,1);
                    enemy.SetActive(true);
                    enemy.GetComponent<Rigidbody>().velocity= new Vector3(-3-0.1f*diff,0,0);
                }
                
            }
            else
            {
                pos_temp = Random.Range(-4f,4f);
                
                enemy.transform.position = new Vector3(pos_temp,-0.4f,upperbound+offset);
                enemy.transform.rotation = new Quaternion(0,0,0,1);
                enemy.SetActive(true);
                enemy.GetComponent<Rigidbody>().velocity= new Vector3(0,0,-2-0.2f*diff);
            }
            
        } 
    }

    IEnumerator loadenemies()
    {
        upenemy = difficulty + 4;
        sideenemy = difficulty * 2;
        param=1;
        offset=0;
        for (int i=0; i<upenemy; i++)
        {
            level(offset, param, difficulty);
            offset+=2;
        }
        param=0;
        offset=0;
        for (int i=0; i<sideenemy; i++)
        {
            level(offset, param, difficulty);
            offset+=2;
        }
        param=2;
        offset=0;
        for (int i=0; i<sideenemy; i++)
        {
            level(offset, param,difficulty);
            offset+=2;
        }
        difficulty+=1;
        yield return new WaitForSeconds(0.25f);
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        checker=enemy_counter;
        if(enemy_counter <= 0)
        {
            StartCoroutine(loadenemies());
        }
    }  
    
}
