using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
 
    public void StartGame (InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene("Circus_Charlie");
    }
}
