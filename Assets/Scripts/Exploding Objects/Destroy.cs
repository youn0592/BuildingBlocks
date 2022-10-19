using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public List<GameObject> debris;
    public float destroyStrength = 2.0f;

    public void KillExplode()
    {
        for (int i = 0; i < debris.Count; i++)
        {
            int numX = Random.Range(-5, 5);
            int numY = Random.Range(1, 5);
            Vector3 force = new Vector3(numX * destroyStrength, numY * destroyStrength, 0);
            var Instance = Instantiate(debris[i], transform.position, transform.rotation);
            Instance.GetComponent<Rigidbody2D>().AddForce(transform.up + force, ForceMode2D.Impulse);

            Debug.Log("This is destroyed");

            Destroy(this.gameObject);
        }
    }
}
