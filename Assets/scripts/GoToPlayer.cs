using UnityEngine;
using System.Collections;

public class GoToPlayer : MonoBehaviour {

    [SerializeField]
    private float velocity = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player"))
        {
            this.movement();
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
