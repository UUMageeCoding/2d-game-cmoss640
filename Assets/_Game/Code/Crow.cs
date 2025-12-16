using UnityEngine;
using System.Collections;
public class Crow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animator anim;
    [SerializeField] private AudioClip WingFlap;
    [SerializeField] private AudioClip Caw;
    [SerializeField] private GameObject Storm;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
 

    void OnTriggerEnter2D(Collider2D Collider)
    {
        anim.SetTrigger("Startled");
        Physics2D.IgnoreCollision(Collider, gameObject.GetComponent<CircleCollider2D>());
    }


    void StartleSound()
    {
        AudioSource.PlayClipAtPoint(Caw, transform.position, 1f);
    }

    void FlightSound()
    {
        AudioSource.PlayClipAtPoint(WingFlap, transform.position, 1f);
    }
}
