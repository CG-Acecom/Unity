using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Brick : MonoBehaviour
{
    public static int breackableCount = 0;

    private int maxHits;    
    private int timesHit;
    private bool isBreakable;

    private LevelManager levelmanager;
    //private Ball _refBall;

    [SerializeField]
    private Sprite[] hitSprites;

    //[SerializeField]
    //private GameObject _refMessage;

    [SerializeField]
    private GameObject smoke;

    [SerializeField]
    private AudioClip crack;

    //[SerializeField]
    //private Text _refText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
            HandleHits();
        Debug.Log(breackableCount);
        //this.gameObject.SetActive(true);
        //_refMessage.SetActive(true);
        //Destroy(_refBall);
        //StartCoroutine(WaitTime());
    }

    void HandleHits()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            breackableCount--;
            levelmanager.BrickDestroyed();

            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule psmain = ps.main;
        psmain.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }else
        {
            Debug.LogError("Missing Sprite");
        }
    }
    /*IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
    }*/

    // Use this for initialization
    void Start () {
        timesHit = 0;
        maxHits = hitSprites.Length + 1;
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breackableCount++;
        }
        //_refBall = GameObject.FindObjectOfType<Ball>();
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
    }

    // TODO
    void SimulateWin()
    {
        levelmanager.LoadNextLevel();
    }
    //// Update is called once per frame
    //void Update () {

    //}
}