using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class GoogleSheetManager
{
    const string enemyDataURL = "https://docs.google.com/spreadsheets/d/1hkeJTxClO7M_wVIFX7R5rZ8OjTGmH9WhZzm6r_L7EZM/export?format=tsv";

    [SerializeField]
    public static SpawnData[] spawnData = null;
    
    public static IEnumerator LoadEnemyData()
    {
        UnityWebRequest www = UnityWebRequest.Get(enemyDataURL);
        yield return www.SendWebRequest();

        string enemyData = www.downloadHandler.text;
        Debug.Log(enemyData);
        ParseEnemyData(enemyData);
    }

    public static void ParseEnemyData(string data)
    {
        string[] lines = data.Split('\n');
        spawnData = new SpawnData[lines.Length-1];
        for (int i = 1; i < lines.Length; i++) {
            string[] fields = lines[i].Split('\t');
            SpawnData enemy = new SpawnData()
            {
                spawnTime = float.Parse(fields[1]),
                spriteType = int.Parse(fields[0]),
                health = int.Parse(fields[3]),
                speed = float.Parse(fields[4]),
            };
            spawnData[i-1] = enemy;
        }
    }
}

[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}

// 이 게임을 좀 확장하면서, 어떤 게임 만들고 싶은지 해오고, 간단한거 한 2달정도면 만드는거. 
// 사실 코드 짜는거는 별로 안걸려 . 뭐가 오래 걸리냐? -> 뭔 게임만들지. 
// 에셋 스토어에서 너가 만들게임의 에셋 정하기. 