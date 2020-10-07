using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deatheffect : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DeathEffect());
    }

    public IEnumerator DeathEffect()
    {

        yield return new WaitForSeconds(1);
        Destroy(gameObject);


    }
}
