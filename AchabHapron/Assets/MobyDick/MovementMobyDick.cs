using UnityEngine;

public class MovementMobyDick : MonoBehaviour
{
    [Header("Paramètres de Mouvement")]
    public float speed = 5f; 
    
    public float minX = -10f; 
    
    public float maxX = 10f; 

    [Header("Direction")]
    [Tooltip("Direction initiale du mouvement (+1 pour droite, -1 pour gauche).")]
    public float direction = 1f;

    void Update()
    {
        float moveDistance = speed * Time.deltaTime * direction;

        float newX = transform.position.x + moveDistance;

        newX = Mathf.Clamp(newX, minX, maxX);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        if (newX == minX || newX == maxX)
        {
            // Inverse la direction : 1 devient -1, et -1 devient 1
            direction *= -1;
        }
    }
}