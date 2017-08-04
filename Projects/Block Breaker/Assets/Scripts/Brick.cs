using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Brick : MonoBehaviour
{

    [SerializeField]
    private GameObject _refBall;

    [SerializeField]
    private GameObject _refMessage;

    //[SerializeField]
    //private Text _refText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(this.gameObject);
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
    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
}