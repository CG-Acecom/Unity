using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizards : MonoBehaviour
{

    public Text guessText;

    int max = 1000;
    int min = 1;
    int guess;
    int formerGuess=1001;
    int maxGuessesAllowed = 5;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        max = max + 1;
        NextGuess();
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }

    public void GuessCorrect()
    {
        StartGame();
    }

    /*void NextGuess()
    {
        //guess = (max + min) / 2;
        guess = Random.Range(min, max);
        print("Next guess is " + guess);
        guessText.text = guess.ToString();
    }*/

    void NextGuess()
    {
        do
        {
            guess = Random.Range(min, max);
            print("Next guess is " + guess);
        } while (guess == formerGuess);
        formerGuess = guess;
        maxGuessesAllowed = maxGuessesAllowed - 1;
        guessText.text = guess.ToString();
        if (maxGuessesAllowed <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

}