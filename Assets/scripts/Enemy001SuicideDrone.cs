using UnityEngine;
using System.Collections;

public class Enemy001SuicideDrone : MonoBehaviour {
    private float velocity = 1.0f;

    // Use this for initialization
    void Start ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        Vector3 positionPlayer = GameObject.Find("Player").gameObject.transform.position;
        /*
        this.gameObject.transform.Translate(
            Mathf.Lerp(this.gameObject.transform.position.x, positionPlayer.x, 5),
            Mathf.Lerp(this.gameObject.transform.position.y, positionPlayer.y, 5),
            0
        );
        */
        this.gameObject.transform.position = new Vector3(
            Mathf.Lerp(this.gameObject.transform.position.x, positionPlayer.x, velocity * Time.deltaTime),
            Mathf.Lerp(this.gameObject.transform.position.y, positionPlayer.y, velocity * Time.deltaTime),
            0
        );
        Debug.Log(this.gameObject.transform.position);
    }
}
