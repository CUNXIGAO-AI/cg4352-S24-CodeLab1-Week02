using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float targetSpeed = 5;
    public TextMeshProUGUI currentSpeedUI;
    public TextMeshProUGUI targetSpeedUI;
    private string[] scenes = { "Level01", "level02" };
    private int currentSceneIndex = 0;
    private string sceneState = "isPlaying";
    public Rigidbody rbTrain;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeedUI.text = "Your current speed:" + rbTrain.velocity.magnitude.ToString("F1") + "KM/H";
        targetSpeedUI.text = "Your target speed:" + targetSpeed + "KM/H";
        
        switch (sceneState)
        {
            case "isPlaying":
                if (rbTrain.velocity.magnitude >= targetSpeed)
                {
                    sceneState = "goToTheNextScene";
                }
                break;
            
            case "goToTheNextScene":
                targetSpeed += 2;
                currentSceneIndex = 1 - currentSceneIndex;
                SceneManager.LoadScene(scenes[currentSceneIndex]);
                sceneState = "isPlaying";
                break;
                
        }
            
    }
}
