using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public GameObject[] hazards;
    public Boundary boundary;
    public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public Text scoreText;
	public GameObject restartText;
	public Text gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score;
    private Vector2 xlimits;
    private Vector2 zlimits;
	
	void Start ()
	{
        UpdateSpawnValues();
		gameOver = false;
		restart = false;
        restartText.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        gameOverText.text = "";
		score = 0;
        xlimits = boundary.GetXLimits(12.0f / 15, 12.0f / 15);
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
    void UpdateSpawnValues()
    {
        xlimits = boundary.GetXLimits(12.0f / 15, 12.0f / 15);
        zlimits = boundary.GetZLimits(1, 1.6f);
    }

	void Update ()
	{
		if (restart&& Input.GetKeyDown(KeyCode.R))
		{
	            Restart();
		}
	}

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(xlimits.x, xlimits.y), 0.0f, zlimits.y);
                Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
                restartText.SetActive(true);
                
                //restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
	}
}