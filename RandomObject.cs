using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{

    public GameObject prefab1, prefab2, prefab3, prefab4, prefab5, prefab6, prefab7, prefab8, prefab9, prefab10;
    int whatToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        whatToSpawn = Random.Range(1, 10);

        switch (whatToSpawn)
        {
            case 1:
                Instantiate(prefab1, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(prefab2, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(prefab3, transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(prefab4, transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(prefab5, transform.position, Quaternion.identity);
                break;
            case 6:
                Instantiate(prefab6, transform.position, Quaternion.identity);
                break;
            case 7:
                Instantiate(prefab7, transform.position, Quaternion.identity);
                break;
            case 8:
                Instantiate(prefab8, transform.position, Quaternion.identity);
                break;
            case 9:
                Instantiate(prefab9, transform.position, Quaternion.identity);
                break;
            case 10:
                Instantiate(prefab10, transform.position, Quaternion.identity);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
