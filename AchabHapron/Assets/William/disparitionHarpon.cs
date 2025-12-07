using UnityEngine;

public class disparitionHarpon : MonoBehaviour
{

    void Start()
    {
        // 1. Disparaît naturellement après 5 secondes si on ne touche rien
        Destroy(gameObject, 5f); 
    }

    void OnCollisionEnter(Collision collision)
    {
        // 2. Disparaît IMMÉDIATEMENT si on touche n'importe quelle surface
        Destroy(gameObject);
    }
}
