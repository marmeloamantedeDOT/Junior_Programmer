using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager5 gameManager5;

    public int difficulty;

    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(SetDifficulty);

        gameManager5 = GameObject.Find("Game Manager").GetComponent<GameManager5>();
    }

    void SetDifficulty()
    {
        gameManager5.StartGame(difficulty);

        Debug.Log(gameObject.name + " was clicked");
    }
}