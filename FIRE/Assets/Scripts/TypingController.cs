using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypingController : MonoBehaviour
{
    public static TypingController instance;

    private Rigidbody trainRB;

    private float trainAcceleration = 2f;

    private string state = "f";

    public TextMeshProUGUI FIRE;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        trainRB = instance.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case "f":
                if (Input.GetKeyDown(KeyCode.F))
                {
                    state = "i";
                    trainRB.velocity += Vector3.left * trainAcceleration;
                    FIRE.text = "F";
                }
                break;
            
            case "i":
                if (Input.GetKeyDown(KeyCode.I))
                {
                    state = "r";
                    trainRB.velocity += Vector3.left * trainAcceleration;
                    FIRE.text = "FI";
                }
                break;
            
            case "r":
                if (Input.GetKeyDown(KeyCode.R))
                {
                    state = "e";
                    trainRB.velocity += Vector3.left * trainAcceleration;
                    FIRE.text = "FIR";
                }
                break;
            
            case "e":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    state = "f";
                    trainRB.velocity += Vector3.left * trainAcceleration;
                    FIRE.text = "FIRE";
                }
                break;
            
        }
    }
}
