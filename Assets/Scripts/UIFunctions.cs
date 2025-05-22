using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIFunctions : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private TextMeshProUGUI playerName;
    [SerializeField]
    private TMP_InputField inputField;


    [SerializeField] private GameObject instructionsPanel; // 🔹 Your "Instructions" UI object

    private bool isInstructionsOpen = false;

    void Start()
    {
        MusicManager.Instance.PlayMusic("MainMenu");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getPlayerName()
    {
        string name = inputField.text;
        Debug.Log("test");
        playerName.text = name; // This will help us view the name of the playerName text
    }
    public void newGame()
    {
        //SceneManager.LoadScene("Tutorial");
        SceneController.instance.LoadScene("Tutorial");

        MusicManager.Instance.PlayMusic("MainTheme");

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ToggleInstructions()
    {
        if (instructionsPanel == null) return;

        isInstructionsOpen = !isInstructionsOpen;
        instructionsPanel.SetActive(isInstructionsOpen);
    }
}
