using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    // Singleton instance for easy global access
    public static CameraShaker Instance { get; private set; }

    private Vector3 _originalLocalPos;
    private float _currentShakeDuration = 0f;
    private float _currentShakeMagnitude = 0f;

    private void Awake()
    {
        // Enforce the Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple CameraShakers found. Destroying the newest one.");
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        // Store the initial local position so we can return to it
        _originalLocalPos = transform.localPosition;
    }

    private void Update()
    {
        if (_currentShakeDuration > 0)
        {
            // Apply random displacement based on the magnitude
            transform.localPosition = _originalLocalPos + Random.insideUnitSphere * _currentShakeMagnitude;
            
            // Decrease the timer
            _currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            // Reset variables and snap back to the original position when done
            _currentShakeDuration = 0f;
            transform.localPosition = _originalLocalPos;
        }
    }

    // Triggers a camera shake from anywhere in your project.
    // <param name="duration">How long the shake lasts in seconds.</param>
    // <param name="magnitude">The strength or intensity of the shake.</param>
    public void Shake(float duration, float magnitude)
    {
        _currentShakeDuration = duration;
        _currentShakeMagnitude = magnitude;
    }
}
