using UnityEngine;

public class TempatSampah : MonoBehaviour
{
    public enum Tipe { Organik, Plastik, B3 }
    public Tipe tipeTempatSampahIni;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Apel"))
        {
            if (tipeTempatSampahIni == Tipe.Organik)
            {
                FindFirstObjectByType<GameManager>().JawabanBenar();
            }
            else
            {
                FindFirstObjectByType<GameManager>().JawabanSalah();
            }
            Destroy(collision.gameObject);
        }
    }
}