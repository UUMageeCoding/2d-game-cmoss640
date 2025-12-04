using Unity.VisualScripting;
using UnityEngine;

public class CameraSpotter : MonoBehaviour
{

    public GameObject camHead;
    public Animator anim;
    [SerializeField] private GameObject CameraHead;
    [SerializeField] private GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = camHead.GetComponent<Animator>();
        //anim.SetBool("IsSpotted", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (anim.GetBool("IsSpotted") == false){
            anim.SetBool("IsSpotted", true);
            CameraHead.transform.LookAt(Player.transform);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (anim.GetBool("IsSpotted") == true)
        {
            anim.SetBool("IsSpotted", false);
        }
    }
}
