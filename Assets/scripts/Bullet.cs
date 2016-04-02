using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float velocity = 35f;

    // Use this for initialization
    void Start ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        this.transform.Translate(0, Time.deltaTime * this.velocity, 0, Space.Self);

        // Destroy the bullet when it is out of bounds of screen
        if (isOutOfScreen()) {
            Destroy(this.gameObject);
        }
    }

    private bool isOutOfScreen ()
    {
        Vector3 posbullet  = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        float screenWidth  = Camera.main.pixelWidth;
        float screenHeight = Camera.main.pixelHeight;

        if (posbullet.x < 0 || posbullet.x > screenWidth || posbullet.y < 0 || posbullet.y > screenHeight ) {
            return true;
        }

        return false;
    }
}