using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLevelManager : MonoBehaviour {

    #region References

    [SerializeField]
    private PlayerController Player;
    [SerializeField]
    private Text LoseText;
    [SerializeField]
    private GameObject ExplosionPref;

    private Vector3 PlayerPosition;
    private Quaternion PlayerQuaternion;
    private bool Once = false;

    #endregion

    // Update is called once per frame
    void Update () {
        if (Player != null)
        {
            PlayerPosition = Player.gameObject.transform.position;
            PlayerQuaternion = Player.gameObject.transform.rotation;
        }

        if (Player.health <= 0 && !Once)
        {
            GameObject Explosion = Instantiate(ExplosionPref, PlayerPosition, PlayerQuaternion);
            StartCoroutine(WaitForLoad());
            Once = !Once;
        }

	}

    private IEnumerator WaitForLoad()
    {
        yield return new WaitForSeconds(1);
        LoseText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Lose");
    }
}
