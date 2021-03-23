using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_around_object : MonoBehaviour
{
    private class aliaser
    { 
            public float coord { get; set; }
    }
    public Transform center;
    public float distance;
    public enum axis
    {
        const_x,
        const_y,
        const_z
    };
    public axis ax;
    public float period;
    public float phase;
    private float time;
    private aliaser rot1, rot2, cons, cent1, cent2, cent3;
    private aliaser X, Y, Z, centx, centy, centz;
    private float startdif;
    //private float cent1, cent2;
    
    // Start is called before the first frame update
    void Start()
    {
        rot1 = new aliaser();
        rot2 = new aliaser();
        cons = new aliaser();
        cent1 = new aliaser();
        cent2 = new aliaser();
        cent3 = new aliaser();


        if (ax == axis.const_y)
        {
            X = rot1;
            Y = cons;
            Z = rot2;
            startdif = center.position.y - transform.position.y;
            cons.coord = transform.position.y;
            centx = cent1;
            centy = cent3;
            centz = cent2;
        }
        if (ax == axis.const_x)
        {
            X = cons;
            Y = rot1;
            Z = rot2;
            startdif = center.position.x - transform.position.x;
            cons.coord = transform.position.x;
            centx = cent3;
            centy = cent1;
            centz = cent2;
        }
        if (ax == axis.const_z)
        {
            X = rot1;
            Y = rot2;
            Z = cons;
            startdif = center.position.z - transform.position.z;
            cons.coord = transform.position.z;
            centx = cent1;
            centy = cent2;
            centz = cent3;
        }
        time = period*phase/360;
    }

    // Update is called once per frame
    void Update()
    {
        centx.coord = center.position.x;
        centy.coord = center.position.y;
        centz.coord = center.position.z;
        time += Time.deltaTime;
        rot1.coord = cent1.coord - distance * Mathf.Sin(time * 2 * Mathf.PI / period);
        rot2.coord = cent2.coord - distance * Mathf.Cos(time * 2 * Mathf.PI / period);
        cons.coord = cent3.coord + startdif;
        //Debug.Log(time);
        //float rot = (360 * time / period);
        //transform.eulerAngles = new Vector3(0,rot,0);
        transform.position = new Vector3(X.coord, Y.coord, Z.coord);
    }
}
