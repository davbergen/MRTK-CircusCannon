using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime = 1f;

    //private float birthtime;

    // Start is called before the first frame update
    void Start()
    {
        //birthtime = Time.fixedTime;
        Object.Destroy(this.gameObject, lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(Time.fixedTime - birthtime > lifetime)   //i expired
        //{
        //    this.Destroy();
        //}
    }
}
