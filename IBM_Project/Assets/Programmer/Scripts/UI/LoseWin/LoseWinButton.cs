using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWinButton : MonoBehaviour
{
    public float Scalar;
    private RectTransform canvas;
    private GameObject Menu;
    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>();
        Menu = GameObject.Find("Menu");
    }
    public void MoveMainMenu()
    {
        Destroy(Menu);
        SceneManager.LoadScene(0);
    }
    private void OnGUI()
    {
        float size = Mathf.Min(canvas.sizeDelta.x, canvas.sizeDelta.y) * (Scalar / 100.0f);
        this.transform.localScale = new Vector2(size, size);
    }

}
