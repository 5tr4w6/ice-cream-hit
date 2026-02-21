using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class StartScreen : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string originalText = "HELLO WORLD";
    private char[] scrambledText;
    private float revealSpeed = 0.2f; // Adjust for faster/slower reveal
    void Start()
    {
        // Scramble the text
        scrambledText = originalText.ToCharArray().OrderBy(c => Random.value).ToArray();
        textMeshPro.text = new string(scrambledText);

        // Start revealing letters
        StartCoroutine(RevealText());
    }
    IEnumerator RevealText()
    {
        char[] currentText = scrambledText.ToArray(); // Copy scrambled text

        for (int i = 0; i < originalText.Length; i++)
        {
            currentText[i] = originalText[i]; // Reveal letter at correct position
            textMeshPro.text = new string(currentText);
            yield return new WaitForSeconds(revealSpeed);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            SceneManager.LoadScene("1");
        }
    }
}
