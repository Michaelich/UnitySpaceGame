using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    public Transform ship;
    public float sidewaysForce = 1f;
    public float forwardForce = 0.8f;
    public float BulletForce = 1500f;
    private bool flag = true;
    private float fire_temp = 0;
    public float fire_rate = 0.25f;
    public canvasManager CM;

    void Fire()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.rotation = new  Quaternion(0,0.707f,0,0.707f);
            bullet.transform.position = ship.position + new  Vector3(-0.075f,0,1.2f);
            bullet.SetActive(true);
        } 
        bullet.GetComponent<Rigidbody>().velocity= new Vector3(0,0,BulletForce);
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(flag)
        {
            if (Input.GetKey("d"))
            {
                rb.AddForce(sidewaysForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(-sidewaysForce*Time.deltaTime,0,0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("w"))
            {
                rb.AddForce(0,0,sidewaysForce*Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("s"))
            {
                rb.AddForce(0,0,-sidewaysForce*Time.deltaTime, ForceMode.VelocityChange);
            }
            if(Time.time > fire_temp)
            {
                fire_temp = Time.time+fire_rate;
                Fire();
            }
        }
    }
    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag.Equals("UFO")==true)
        {
            flag=false;
            CM.Ending();
        }
        
        if(target.gameObject.tag.Equals("Laser")==true)
        {
            flag=false;
            CM.Ending();
        }
        
    }
}
