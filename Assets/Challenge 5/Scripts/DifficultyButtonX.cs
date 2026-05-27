using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX : MonoBehaviour
{
    private Button button;

    public GameManagerX gameManagerX;
    public int difficulty;

    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");

        gameManagerX.StartGame(difficulty);
    }
}