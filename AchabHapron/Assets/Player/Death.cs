using UnityEngine;

public class Death : MonoBehaviour
{
    public CameraController cameraController;
    public Transform MobyDick;

    public GameObject deathImage;
    public GameObject ViseurAndObjectif;
    public GameObject Timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            cameraController.cameraLocked = true;
            ViseurAndObjectif.SetActive(false);
            
            Timer.SetActive(false);
            
            deathImage.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            MobyDick.localPosition = new Vector3(MobyDick.localPosition.x, MobyDick.localPosition.y, MobyDick.localPosition.z - 5);
        }
    }
}
