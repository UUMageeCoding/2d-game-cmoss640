using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraSpotter : MonoBehaviour
{

    public GameObject camHead;
    public Animator anim;
    [SerializeField] private GameObject CameraHead;
    [SerializeField] private GameObject Player;
    private bool Spotted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim.SetBool("IsSpotted", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Spotted == true)
        {
            Vector3 direction = Player.transform.position - CameraHead.transform.position;
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            CameraHead.transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        }
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        anim.SetBool("IsSpotted", true);
        Spotted = true;
    }
}
