using UnityEngine;

public class Throwing : MonoBehaviour
{
    [SerializeField] GameObject Weapon;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
    {
         Instantiate(Weapon, transform.position, Quaternion.identity);

    }
    }
}