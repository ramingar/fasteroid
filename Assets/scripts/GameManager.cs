using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    [System.Serializable]
    private struct Timeline
    {
        public string     time;
        public GameObject enemy;
        public string spawnPosition;
    }
    [SerializeField]
    private Timeline[] timeline;

    private int timelineIndex = 0;
    
    private void Update ()
    {
        if (this.timelineIndex < timeline.Length && Mathf.Round(Time.time).ToString() == timeline[this.timelineIndex].time)
        {
            Instantiate(timeline[this.timelineIndex].enemy, this.getSpawnPosition(timeline[this.timelineIndex].spawnPosition), Quaternion.identity);
            this.timelineIndex++;
        }
    }

    private Vector3 getSpawnPosition (string position)
    {
        float   screenWidth     = Camera.main.pixelWidth;
        float   screenHeight    = Camera.main.pixelHeight;
        Vector3 spawnPosition   = new Vector3(0f, 0f, 0f);
        int     positionKey     = 1;

        switch (position) {
            case "top":
                positionKey = 1;
                break;
            case "left":
                positionKey = 4;
                break;
            case "right":
                positionKey = 2;
                break;
            case "":
                positionKey = ((int)Random.Range(0f, 4f)) + 1;
                break;
        }

        // Choose the side where it will spawn
        switch (positionKey) {
            case 1:
                // top side
                spawnPosition = new Vector3(Random.Range(0f, screenWidth), screenHeight, 0);
                break;
            case 2:
                // right side 
                spawnPosition = new Vector3(screenWidth, Random.Range(0f, screenHeight), 0);
                break;
            case 3:
                // down side
                //spawnPosition = new Vector3(0, Random.Range(0f, screenHeight), 0);
                // top side
                spawnPosition = new Vector3(Random.Range(0f, screenWidth), screenHeight, 0);
                break;
            case 4:
                // left side
                spawnPosition = new Vector3(0, Random.Range(0f, screenHeight), 0);
                break;
            case 5:
                // left side
                spawnPosition = new Vector3(0, Random.Range(0f, screenHeight), 0);
                break;
        }

        spawnPosition = Camera.main.ScreenToWorldPoint(spawnPosition);
        return new Vector3(spawnPosition.x, spawnPosition.y, 0);
    }
}
