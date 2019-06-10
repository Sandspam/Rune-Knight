using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject starPrefab;
    public Vector3 center;
    public Vector3 size;
    public float starSpawnTime;
    private float starTimer;
    public int starsToSpawn;

    private void Start()
    {
        for (int i = 0; i < starsToSpawn; i++)
        {
            SpawnStar();
        }

        starTimer = starSpawnTime;
    }

    private void Update()
    {
        /*starTimer -= Time.deltaTime;
        if(starTimer <= 0)
        {
            starTimer = starSpawnTime;
            SpawnStar();
        }*/
    }

    void SpawnStar()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));

        GameObject instance = Instantiate(starPrefab, pos, Quaternion.identity);

        float randomizedInt = Random.Range(0.01f, 0.03f);
        instance.transform.localScale = new Vector3(randomizedInt, randomizedInt, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
