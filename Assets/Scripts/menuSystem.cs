using UnityEngine;
using UnityEngine.SceneManagement;

public class menuSystem : MonoBehaviour
{
    [SerializeField] private string newScene = "SampleScene";   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Start button event
    public void startButton_Event()
    {
        SceneManager.LoadScene(newScene);
    }



}
