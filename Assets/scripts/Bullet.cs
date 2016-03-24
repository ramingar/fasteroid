using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private float velocity = 35f;

    // Use this for initialization
    void Start ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        this.transform.Translate(0, Time.deltaTime * this.velocity, 0, Space.Self);
    }
}