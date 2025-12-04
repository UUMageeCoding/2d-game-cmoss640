using UnityEngine;

public class Hammer : MonoBehaviour
{

    [SerializeField] GameObject Destruction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(Destruction, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
