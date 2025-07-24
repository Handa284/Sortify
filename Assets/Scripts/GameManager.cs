using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> daftarPrefabSampah; 
    public Transform posisiMuncul; 
    public TextMeshProUGUI  teksSkor; 

    private int skor = 0;

    void Start()
    {
        teksSkor.text = "Skor: " + skor;
        InvokeRepeating("MunculkanSampah", 1f, 2f);
    }

    void MunculkanSampah()
    {
        int randomIndex = Random.Range(0, daftarPrefabSampah.Count);

        GameObject sampahUntukDimunculkan = daftarPrefabSampah[randomIndex];

        Instantiate(sampahUntukDimunculkan, posisiMuncul.position, Quaternion.identity);
    }

    public void JawabanBenar()
    {
        skor = skor + 10;
        teksSkor.text = "Skor: " + skor;
    }

    public void JawabanSalah()
    {
        Debug.Log("SALAH! GAME OVER!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}