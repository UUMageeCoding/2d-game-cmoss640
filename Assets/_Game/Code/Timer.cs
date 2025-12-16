using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class Timer : MonoBehaviour
{

    public float StormTimer;
    [SerializeField] public TextMeshProUGUI TimerLabel;
    [SerializeField] public Light LightningLight;
    public bool TimerRunning = false;
    public int LightningNum;
    public Animator Lightning;
    [SerializeField] GameObject GameoverScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimerRunning = true;
        Lightning = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StormTimer > 0 && TimerRunning == true)
        {
            StormTimer -= Time.deltaTime;
            TimerLabel.text = StormTimer.ToString("F2");

        }

        else if (StormTimer <= 0 && TimerRunning == true)
        {
            TimerRunning = false;
            GameoverScreen.SetActive(true);
        }

    } }
