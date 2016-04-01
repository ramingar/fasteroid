using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

    private void Update()
    {
        // Look at the player
        if (GameObject.Find("Player")) {
            Transform player = GameObject.Find("Player").gameObject.transform;
            Vector3 difference = player.position - transform.position;
            float rotationZ = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90f;
            this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        }
    }
}
