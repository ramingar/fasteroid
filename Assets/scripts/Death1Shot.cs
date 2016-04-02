using UnityEngine;
using System.Collections;

public class Death1Shot : MonoBehaviour {

    [SerializeField]
    private GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        if ("bullet" == collision.gameObject.tag)
        {
            Vector3 posCollision = contact.point;
            Quaternion rotCollision = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Instantiate(explosion, posCollision, rotCollision);
            Destroy(gameObject);
        }
    }
}
