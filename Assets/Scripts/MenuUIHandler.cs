using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI bestScoreText;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if(GameManager.instance)
        {
            bestScoreText.text = "Best Score : " + GameManager.instance.bestScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        gameManager.SetPlayerName(playerName.text);
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
