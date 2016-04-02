using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    [System.Serializable]
    private struct Timeline
    {
        public string time;
        public GameObject enemy;
    }
    [SerializeField]
    private Timeline[] timeline;

    private int timelineIndex = 0;
    
    private void Update ()
    {
        if (this.timelineIndex < timeline.Length && Mathf.Round(Time.time).ToString() == timeline[this.timelineIndex].time)
        {
            Instantiate(timeline[this.timelineIndex].enemy, this.getSpawnPosition(), Quaternion.identity);
            this.timelineIndex++;
        }
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
