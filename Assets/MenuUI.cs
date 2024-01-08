using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    GameObject inputField; // This should be the input parent field and not the child text field. See this post for more details. 190
// Start is called before the first frame update
void Start()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }
    public void GetName()
    {
        MenuManager.instance.Name = inputField.GetComponent<TMP_InputField>().text;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
