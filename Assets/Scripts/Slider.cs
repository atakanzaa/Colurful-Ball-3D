using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public Vector3 pos1; //sol taraftaki bir nokta
    public Vector3 pos2; //sag taraftaki bir nokta
    public float speed;
    private void FixedUpdate()
    {
        gameObject.GetComponent<Transform>().localPosition = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time*speed,1));
    }
}
