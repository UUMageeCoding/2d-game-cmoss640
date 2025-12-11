using UnityEngine;

public class Hammer : MonoBehaviour
{

    [SerializeField] GameObject Destruction;
    [SerializeField] AudioSource SoundEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundEffect.pitch = Random.Range(0.8f, 1.2f);
        SoundEffect.Play();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(Destruction, transform.position, transform.rotation);
        Destroy(gameObject);
        if (PlatformerController.Score > 0)
        {
            PlatformerController.Score -= 1;
        }
    }

}