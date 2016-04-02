using UnityEngine;
using System.Collections;

public class BulletExplossion : MonoBehaviour {

    void Start ()
    {
        InvokeRepeating("explode", 3f, 0f);
    }

    private void explode ()
    {
        this.gameObject.transform.localScale.Scale(this.gameObject.transform.localScale);
    }
}
