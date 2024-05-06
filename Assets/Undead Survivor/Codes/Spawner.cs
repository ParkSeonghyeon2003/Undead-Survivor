using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public float levelTime;

    int level;
    float timer;
    float bossTimer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        levelTime = GameManager.instance.maxGameTime / GoogleSheetManager.spawnData.Length - 1;
    }

    void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        timer += Time.deltaTime;
        bossTimer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / levelTime), GoogleSheetManager.spawnData.Length - 1);

        if (timer > GoogleSheetManager.spawnData[level].spawnTime) {
            timer = 0;
            Spawn();
        }
        if (bossTimer > GoogleSheetManager.spawnData[3].spawnTime)
        {
            bossTimer = 0;
            BossSpawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(GoogleSheetManager.spawnData[level]);
    }
    void BossSpawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(GoogleSheetManager.spawnData[3]);
    }
}

