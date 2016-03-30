using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject enemy001;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("setEnemies", 0, 1.0f);
    }

    // Update is called once per frame
    void Update ()
    {
    }

    private void setEnemies ()
    {
        this.instantiateEnemy001();

        //Debug.Log(Time.realtimeSinceStartup + "-" + Mathf.Round(Time.realtimeSinceStartup));
        //if (Mathf.Round(Time.realtimeSinceStartup) == 5) {
        //    this.instantiateEnemy001();
        //}
    }

    private void instantiateEnemy001()
    {
        Vector3 spawnPosition = this.getSpawnPosition();
        Instantiate(enemy001, spawnPosition, Quaternion.identity);
    }

    private Vector3 getSpawnPosition ()
    {
        float   screenWidth     = Camera.main.pixelWidth;
        float   screenHeight    = Camera.main.pixelHeight;
        Vector3 spawnPosition   = new Vector3(screenWidth, screenHeight, 0);

        // Choose the side where it will spawn
        switch (((int)Random.Range(0f, 4f)) + 1)
        {
            case 1:
                // top side
                spawnPosition = new Vector3(screenWidth, Random.Range(0f, screenHeight), 0);
                break;
            case 2:
                // right side 
                spawnPosition = new Vector3(Random.Range(0f, screenWidth), screenHeight, 0);
                break;
            case 3:
                // down side
                spawnPosition = new Vector3(0, Random.Range(0f, screenHeight), 0);
                break;
            case 4:
                // left side
                spawnPosition = new Vector3(Random.Range(0f, screenWidth), 0, 0);
                break;
            case 5:
                // left side
                spawnPosition = new Vector3(Random.Range(0f, screenWidth), 0, 0);
                break;
        }

        spawnPosition = Camera.main.ScreenToWorldPoint(spawnPosition);
        return new Vector3(spawnPosition.x, spawnPosition.y, 0);
    }
}
