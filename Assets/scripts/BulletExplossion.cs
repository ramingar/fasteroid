using UnityEngine;
using System.Collections;

public class BulletExplossion : MonoBehaviour {

    [SerializeField]
    private float timeToExplode = 1.5f;

    private bool markToExplode = false;

    void Start()
    {
        InvokeRepeating("explode", this.timeToExplode, 1f);
        InvokeRepeating("destroy", this.timeToExplode + 0.5f, 1f);
    }

    void Update()
    {
        if (this.markToExplode)
        {
            this.gameObject.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
            Destroy(this.gameObject.GetComponent<Bullet>());
        }
    }


    private void explode()
    {
        this.markToExplode = true;
    }

    private void destroy()
    {
        Destroy(this.gameObject);
    }
}
