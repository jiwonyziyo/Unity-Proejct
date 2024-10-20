using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text stageCountText;
    public Text playerCountText;
    public Text GameClearText;
    


    // Start is called before the first frame update
    void Start()
    {
        GameClearText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void GetItem(int count)
    {
        playerCountText.text = count.ToString();
    }
    public void ShowGameCleatText()
    {
        GameClearText.gameObject.SetActive(true);
    }
    void Awake ()
    {
        stageCountText.text = "/ " + totalItemCount;

    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag =="Player")
            SceneManager.LoadScene(stage);
    }
    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
