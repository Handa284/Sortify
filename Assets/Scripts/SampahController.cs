using UnityEngine;
using UnityEngine.InputSystem; 
public class SampahController : MonoBehaviour
{
    public float kecepatanJatuh = 3f;
    
    private Camera mainCamera;
    private bool isDragging = false; 

    // Variabel untuk Input System
    private KontrolPemain controls;

    private void Awake()
    {
        mainCamera = Camera.main;
        
        controls = new KontrolPemain(); 
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
        controls.Gameplay.Sentuh.performed += ctx => MulaiGeser();
        controls.Gameplay.Sentuh.canceled += ctx => BerhentiGeser(); 
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void MulaiGeser()
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(controls.Gameplay.PosisiLayar.ReadValue<Vector2>()));
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isDragging = true;
        }
    }

    private void BerhentiGeser()
    {
        isDragging = false;
    }

    void Update()
    {
        if (!isDragging)
        {
            transform.Translate(Vector2.down * kecepatanJatuh * Time.deltaTime);
        }
        else
        {
            Vector2 touchPosition = controls.Gameplay.PosisiLayar.ReadValue<Vector2>();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, mainCamera.nearClipPlane));
            
            transform.position = new Vector2(worldPosition.x, transform.position.y);
        }

        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}