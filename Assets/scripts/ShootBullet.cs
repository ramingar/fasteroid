using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour
{

    [SerializeField]
    private float speed = 0.5f;

    [SerializeField]
    private float timeToShoot = 3.0f;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject cannon;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("shootBullet", 1, this.timeToShoot);
    }

    private void Update ()
    {
        // Look at the player
        Transform player     = GameObject.Find("Player").gameObject.transform;
        Vector3   difference = player.position - transform.position;
        float     rotationZ  = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90f;
        transform.rotation   = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }

    private void shootBullet()
    {
        Vector3 positionPlayer = GameObject.Find("Player").gameObject.transform.position;
        GameObject bulletClone = (GameObject) Instantiate(this.bullet, cannon.gameObject.transform.position, this.gameObject.transform.rotation);

        bullet.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, positionPlayer, Time.deltaTime * this.speed);
    }
}