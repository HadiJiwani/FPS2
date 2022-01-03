using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LOST : MonoBehaviour
{

    public Rigidbody2D rb;
    
    private void OnCollisionEnter2D()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
