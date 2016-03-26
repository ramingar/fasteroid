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
        Vector3 positionPlayer = GameObject.Find("Player").gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(
            Mathf.Lerp(this.gameObject.transform.position.x, positionPlayer.x, velocity * Time.deltaTime),
            Mathf.Lerp(this.gameObject.transform.position.y, positionPlayer.y, velocity * Time.deltaTime),
            0
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        var pos: Vector3 = contact.point;
        Instantiate(explosionPrefab, pos, rot);
        Destroy(gameObject);
        */

        ContactPoint contact    = collision.contacts[0];
        if ("bullet" == collision.other.tag) {
            Vector3 posCollision = contact.point;
            Quaternion rotCollision = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Instantiate(explosion, posCollision, rotCollision);
            Destroy(gameObject);
        }
    }
}
