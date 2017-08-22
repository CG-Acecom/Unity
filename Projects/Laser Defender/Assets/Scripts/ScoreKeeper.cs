using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    public int score = 0;
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
	public void Reset () {
        score = 0;
	}
}
