using UnityEngine;
using System.Collections;

public class LanceurHarpon : MonoBehaviour
{
    public GameObject harponPrefab;
    public float forceTir = 30f;
    public float tempsRecharge = 1f;
    
    private bool dispoTir = true;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && dispoTir)
        {
            StartCoroutine(TirerEtRecharger());
        }
    }

    IEnumerator TirerEtRecharger()
    {
        dispoTir = false;

        GameObject harpon = Instantiate(harponPrefab, transform.position + transform.forward, transform.rotation);
        
        Rigidbody rb = harpon.GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * forceTir;

        while (harpon != null)
        {
            yield return null;
        }

        yield return new WaitForSeconds(tempsRecharge);

        dispoTir = true;
        Debug.Log("Harpon prêt !");
    }
}