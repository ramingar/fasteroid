using UnityEngine;
using System.Collections;

public class ControlPlayer : MonoBehaviour
{
    [SerializeField]
    private float velocity = 15;

    [SerializeField]
    private GameObject cannon;

    [SerializeField]
    private GameObject bullet;

    // Use this for initialization
    void Start ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        // Position
        this.movePlayer();

        // Rotation
        this.rotatePlayer();

        if (Input.GetMouseButtonUp(0)) {
            this.shootBullet();
        }
    }

    // FUNCTIONS!!
    private void movePlayer()
    {
        this.gameObject.transform.Translate(new Vector3(
            Input.GetAxis("Horizontal") * velocity * Time.deltaTime,
            Input.GetAxis("Vertical") * velocity * Time.deltaTime,
            0
        ), Space.World);

        // RANGE OF MOVEMENT FOR THE PLAYER
        Vector3 posPlayer  = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        float screenWidth  = Camera.main.pixelWidth;
        float screenHeight = Camera.main.pixelHeight;
        float radiusPlayer = 18f;

        this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Mathf.Clamp(posPlayer.x, radiusPlayer, screenWidth - radiusPlayer),
                Mathf.Clamp(posPlayer.y, radiusPlayer, screenHeight - radiusPlayer),
                0
            )
        );
        this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
    }

    private void rotatePlayer()
    {
        // GET ROTATION ACCORDING TO THE MOUSE POSITION
        Vector3 mouse          = Camera.main.ScreenToWorldPoint(Input.mousePosition);                         // mouse position according to our camera
        Vector2 mousePosition  = new Vector2(mouse.x, mouse.y);                                               // mouse position in Vector2
        Vector2 playerPosition = new Vector2(this.transform.position.x, this.transform.position.y);           // player position in Vector2

        // we apply the Law of Cosines to get the angle
        float a = mousePosition.x - playerPosition.x;                                                         // a side
        float c = mousePosition.y - playerPosition.y;                                                         // another side
        float b = Vector2.Distance(playerPosition, mousePosition);                                            // hypotenuse (podríamos aplicar pitágoras... pero Unity tiene una función que nos lo calcula)
        float angle = Mathf.Acos((float) (((a * a) + (b * b) - (c * c)) / (2.0 * a * b))) * 180 / Mathf.PI;   // "(* 180 / Mathf.PI)" -> convert from radians to degrees

        if (c < 0) {                                                                                          // it's over 180º, that is, cursor is below our player
            angle = 180 + (180 - angle);                                                                      // we add the excess of degrees to 180º
        }

        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);                               // apply the angle to the rotation
    }

    private void shootBullet()
    {
        GameObject bulletClone = (GameObject) Instantiate(bullet, this.cannon.transform.position, this.cannon.transform.rotation);
    }
}