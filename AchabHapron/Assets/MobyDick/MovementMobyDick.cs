using TMPro;
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

    [Header("Contact Harpon")]
    public ParticleSystem bloodParticle;
    public TextMeshProUGUI textPenseePerso;

    public AudioClip bruitWhale;
    public Transform player;

    private int compteurHit = 0;

    private string text2 = "J'ai vu des signes partout et je me dis que Moby Dick m’envoie des avertissements.";
    private string text3 = "Elle me suit, elle me connaît, mais personne d’autre à bord ne veut l'admettre.";
    private string text4 = "Je sais que c’est elle ou moi, et je refuse d’attendre qu’elle frappe la première.";

    void Start()
    {
        AudioSource.PlayClipAtPoint(bruitWhale, player.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Harpon"))
        {
            compteurHit++;
            if (compteurHit >= 1)
                textPenseePerso.text = text2;
            if (compteurHit >= 2)
                textPenseePerso.text = text3;
            if (compteurHit >= 3)
                textPenseePerso.text = text4;

            bloodParticle.transform.position = transform.position;
            bloodParticle.Play();

            Destroy(collision.gameObject);
            
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 12);
        }
    }

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