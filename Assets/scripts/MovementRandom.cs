using UnityEngine;
using System.Collections;

public class MovementRandom : MonoBehaviour {

    [SerializeField]
    private float velocity = 1.0f;

    private Vector3 positionTarget = new Vector3(0f, 0f, 0f);

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("changeDirection", 0.5f, 2.5f);
    }

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
        this.gameObject.transform.position = new Vector3(
            Mathf.Lerp(this.gameObject.transform.position.x, positionTarget.x, velocity * Time.deltaTime),
            Mathf.Lerp(this.gameObject.transform.position.y, positionTarget.y, velocity * Time.deltaTime),
            0
        );
    }

    private void changeDirection ()
    {
        this.positionTarget = Camera.main.ScreenToWorldPoint(new Vector3(
             Random.Range(0, Camera.main.pixelWidth),
             Random.Range(0, Camera.main.pixelHeight),
             0
        ));
    }
}
