using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    public GameObject obj;
    // Update is called once per frame
    void Update()
    {
        if (obj.transform.position.z > 7 )
        {
            obj.SetActive(false);
        }
        if (obj.transform.position.z < -7 )
        {
            obj.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag.Equals("UFO")==true)
        {
            obj.SetActive(false);
        }
        if(target.gameObject.tag.Equals("Player")==true)
        {
            obj.SetActive(false);
        }
        if(target.gameObject.tag.Equals("Laser")==true)
        {
            obj.SetActive(false);
        }
        if(target.gameObject.tag.Equals("Bullet")==true)
        {
            obj.SetActive(false);
        }
    }
}
