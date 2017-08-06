using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Brick : MonoBehaviour
{
    public int maxHits;

    [SerializeField]
    private GameObject _refBall;

    [SerializeField]
    private GameObject _refMessage;

    private int timesHit;
    //[SerializeField]
    //private Text _refText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        //this.gameObject.SetActive(true);
        _refMessage.SetActive(true);
        Destroy(_refBall);
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
    }

    // Use this for initialization
    void Start () {
        timesHit = 0;
    }

    //// Update is called once per frame
    //void Update () {

    //}
}