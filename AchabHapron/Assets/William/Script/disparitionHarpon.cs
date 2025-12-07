using UnityEngine;

public class disparitionHarpon : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 3f); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        Destroy(gameObject);
    }
}
