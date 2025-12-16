using UnityEngine;

public class Pickups : MonoBehaviour
{
    private ThrowingWeapons Throwingweapons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Throwingweapons = GameObject.FindGameObjectWithTag("Throwpoint").GetComponent<ThrowingWeapons>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ThrowingWeapons.HammerCount += 2;
            Destroy(gameObject);
        }
    }
}
