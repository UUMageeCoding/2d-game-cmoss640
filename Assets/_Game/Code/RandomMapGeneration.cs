using UnityEngine;

public class RandomMapGeneration : MonoBehaviour
{
    private int StructureNum;
    [SerializeField] private GameObject Structure1;
    [SerializeField] private GameObject Structure2;
    [SerializeField] private GameObject Structure3;
    [SerializeField] private GameObject Structure4;
    [SerializeField] private GameObject Structure5;
    [SerializeField] private GameObject Structure6;
    [SerializeField] private GameObject Structure7;

    private void Awake()
    {
        StructureNum = Random.Range(1, 8);

        switch (StructureNum)
        {
            case 1:
                Structure1.SetActive(true);
                break;
            case 2:
                Structure2.SetActive(true);
                break;
            case 3:
                Structure3.SetActive(true);
                break;
            case 4:
                Structure4.SetActive(true);
                break;
            case 5:
                Structure5.SetActive(true);
                break;
            case 6:
                Structure6.SetActive(true);
                break;
            case 7:
                Structure7.SetActive(true);
                break;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
