using UnityEngine;

public class Death : MonoBehaviour
{
    public CameraController cameraController;
    public GameObject deathImage;
    public Transform MobyDick;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            cameraController.cameraLocked = true;
            deathImage.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            MobyDick.localPosition = new Vector3(MobyDick.localPosition.x, MobyDick.localPosition.y, MobyDick.localPosition.z - 5);
        }
    }
}
