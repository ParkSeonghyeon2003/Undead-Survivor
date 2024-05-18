using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++) {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index) //, string type
    {
        GameObject select = null;

        // ... 선택한 풀의 놀고 있는 게임오브젝트 접근
        foreach (GameObject item in pools[index]) {
            if (!item.activeSelf) {
                // ... 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ... 못 찾았으면?
        if (!select) {
            // ... 새롭게 새성하고 select 변수에 할당
            select = Instantiate(prefabs[index], transform);
            //if(type == "Boss")
            //    select.name = "Boss";
            pools[index].Add(select);
        }

        return select;
    }
}
