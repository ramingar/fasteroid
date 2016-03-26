using UnityEngine;
using System.Collections;

public class Enemy001SuicideDrone : MonoBehaviour {
    [SerializeField]
    private float velocity = 1.0f;
    [SerializeField]
    private GameObject explosion;

    // Use this for initialization
    void Start ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        if (GameObject.Find("Player")) {
            this.movement();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact    = collision.contacts[0];
        if ("bullet" == collision.gameObject.tag) {
            Vector3 posCollision = contact.point;
            Quaternion rotCollision = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Instantiate(explosion, posCollision, rotCollision);
            Destroy(gameObject);
        }
    }

    private void movement()
    {
        Vector3 positionPlayer = GameObject.Find("Player").gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(
            Mathf.Lerp(this.gameObject.transform.position.x, positionPlayer.x, velocity * Time.deltaTime),
            Mathf.Lerp(this.gameObject.transform.position.y, positionPlayer.y, velocity * Time.deltaTime),
            0
        );
    }
}
