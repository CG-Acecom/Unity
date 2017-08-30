using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;
    private Text myText;

    void Start()
    {
        myText=GetComponent<Text>();
        Reset();
    }

    public void Score (int points) {
        score += points;
        myText.text = score.ToString();
	}
	
	// Update is called once per frame
	public static void Reset () {
        score = 0;
	}
}
