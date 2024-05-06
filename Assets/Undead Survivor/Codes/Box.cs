using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        StartCoroutine(KillAllRoutine());
    }

    IEnumerator KillAllRoutine()
    {
        GameManager.instance.enemyCleaner.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.enemyCleaner.SetActive(false);
        gameObject.SetActive(false);
    }
}
