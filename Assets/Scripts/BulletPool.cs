using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {

    public GameObject objToSpawn;
    private Queue<GameObject> pool;
    private int poolSize = 10;

    // Start is called before the first frame update
    void Start() {
        pool = new Queue<GameObject>();
        for (int i=0; i<poolSize; i++) {
            GameObject obj = Instantiate(objToSpawn);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public void SpawnBullet(Vector2 position, Vector2 velocity) {
        // Check if pool is empty for some reason
        if (pool.Count == 0) return;

        GameObject obj = pool.Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
        obj.GetComponent<Rigidbody2D>().velocity = velocity;
        pool.Enqueue(obj);
    }

    public void Reset() {
        foreach (GameObject obj in pool) {
            obj.SetActive(false);
        }
    }
}
