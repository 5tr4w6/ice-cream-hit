using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //public static GameController Instance { get; private set; }

    public int spoonCount;

    public int currentSpoon;

    [Header("Spoon Spawning")]
    [SerializeField]
    private Vector2 spoonSpawnPosition;

    public GameObject spoonObject;

    [Header("Spoon Count Display")]
    public GameObject panelSpoons;

    public GameObject iconSpoons;

    [SerializeField]
    private Color usedSpoonIconColor;

    [Header("UI Elements")]
    public GameObject gameWonText;

    public TextMeshProUGUI buildIndexText;

    public GameObject restartButton;

    public GameObject nextButton;

    private void Start()
    {
        buildIndexText.text = ("Level: " + SceneManager.GetActiveScene().name);

        gameWonText.SetActive(false);
        restartButton.SetActive(false);
        SetInitialDisplaySpoonCount(spoonCount);
    }

    public void SetInitialDisplaySpoonCount(int count)
    {
        spoonCount = count;
        currentSpoon = 1;
        for (int i = 0; i < spoonCount; i++)
        {
            Instantiate(iconSpoons, panelSpoons.transform);
        }
        SpawnSpoon();
    }

    public void DecrementDisplayedSpoonCount()
    {
        var spoon = panelSpoons.transform.GetChild(currentSpoon - 1);
        spoon.GetComponent<Image>().color = usedSpoonIconColor;
        spoon.tag = "UsedIconSpoon";
    }

    public void SpawnSpoon()
    {
        Instantiate(spoonObject, spoonSpawnPosition, Quaternion.identity);
    }

    public void OnSuccessfulSpoonHit()
    {
        if (currentSpoon + 1 <= spoonCount)
        {
            SpawnSpoon();
            currentSpoon++;
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Angel")
                return;
                
            GameOverSequence();
        }
    }

    public void GameOverSequence()
    {
        gameWonText.SetActive(true);
    }

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void NextLevel()
    {
        nextButton.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
