using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private PlayerController player;
    
    [SerializeField]
    private GameObject enemies;
    
    [SerializeField] 
    private TextMeshProUGUI startText;

    private TouchControls _touchControls;

    private void Awake()
    {
        enemies.SetActive(false);
        
        _touchControls = new TouchControls();
        _touchControls.Touch.TouchPress.performed += Play;
    }
    
    private void OnEnable()
    {
        _touchControls.Enable();
    }

    private void OnDisable()
    {
        _touchControls.Disable();
    }

    private void Play(InputAction.CallbackContext context)
    {
        _touchControls.Touch.TouchPress.performed -= Play;
        
        startText.gameObject.SetActive(false);
        
        enemies.SetActive(true);
        player.Enable();
    }
}