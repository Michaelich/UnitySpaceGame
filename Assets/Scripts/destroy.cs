using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public GameObject obj;
    public GameObject player;
    private float fire_temp = 2f;
    public float fire_rate = 4f;
    public float BulletForce = 15f;
    private bool flag = false;
    private float randomNoise = 0f;
    private int randomNoise2 = 0;
    
    void Fire()
    {
        randomNoise2 =  Random.Range(1,StartGame.difficulty+2);
        if(randomNoise2>=2){
        GameObject bullet = ObjectPool.SharedInstance3.GetPooledObject3();
        randomNoise2 =  Random.Range(1,StartGame.difficulty+2);
        if (bullet != null)
        {
            bullet.transform.position = obj.transform.position + new  Vector3(0.5f,0.4f,1.4f);
            if(StartGame.difficulty>=3 && randomNoise2 >=3)
            {
            bullet.transform.LookAt(player.transform);
            }
            else
            {
                bullet.transform.rotation= new Quaternion(0,1,0,0);
            }
            bullet.SetActive(true);
        } 
        
            bullet.GetComponent<Rigidbody>().velocity= bullet.transform.forward*(BulletForce+0.1f*StartGame.difficulty);
        }
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {   
        if (obj.transform.position.z > 0 && obj.transform.position.z < 6 && obj.transform.position.x < 8 && obj.transform.position.x > -8)
        {
            flag=true;
        }
        if (flag==true && (obj.transform.position.z < -3 || obj.transform.position.z > 7 || obj.transform.position.x < -8 || obj.transform.position.x > 8))
        {
            StartGame.enemy_counter -= 1;
            obj.SetActive(false);
            flag = false;
        }
        randomNoise = Random.Range(1,10)/7;
        if(Time.time > fire_temp && StartGame.difficulty>=2)
            {
                fire_temp = Time.time+fire_rate+randomNoise;
                Fire();
            }
    }
    // Update is called once per frame
    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag.Equals("Bullet")==true)
        {
            obj.SetActive(false);
            flag=false;
            StartGame.enemy_counter-=1;
            StartGame.Score += StartGame.difficulty;
        }
    }
}
