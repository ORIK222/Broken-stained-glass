using UnityEngine;
using UnityEngine.SceneManagement;

public class ChipMover : MonoBehaviour
{
    private StepCounter _stepCounter;
    private AudioSource _audioSource;
    private Camera _camera;

    private Vector3 screenPoint;
    private Vector3 _offset;
    private Vector3 _startPosition;
    private Vector2 _screenBounds;

    private float _offsetZ;

    public void ChipReleased(Vector2 chipPosition)
    {
        /* if (!_gameStarted)
         {
             if ((chipPosition.x > 615 && chipPosition.x < 815) && (chipPosition.y > 315 && chipPosition.y < 525))
             {
                 _gameStarted = true;
                 _repairedArtDebug.gameObject.SetActive(false);
             }
         }*/
    }

    private void Awake()
    {
        _camera = Camera.main;
        _screenBounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.transform.position.z));
        _stepCounter = FindObjectOfType<StepCounter>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _startPosition = transform.position;
    }
    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Tutorial.tutorial.gameObject.activeSelf == true) Tutorial.tutorial.gameObject.SetActive(false);
        }
        //if (_isDisabled) return;
        _offsetZ = Mathf.Repeat(_offsetZ + 0.1f, 1.0f);
        transform.position = new Vector3(transform.position.x, transform.position.y, - _offsetZ);
        screenPoint = _camera.WorldToScreenPoint(transform.position);
        _offset = transform.position - _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    private void OnMouseDrag()
    {
        //if (_isDisabled) return;
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = _camera.ScreenToWorldPoint(cursorPoint) + _offset;
        cursorPosition.x = Mathf.Clamp(cursorPosition.x, -_screenBounds.x, _screenBounds.x);
        cursorPosition.y = Mathf.Clamp(cursorPosition.y, -_screenBounds.y, _screenBounds.y);
        transform.position = cursorPosition;

    }
    private void OnMouseUpAsButton()
    {
        ChipReleased(_camera.WorldToScreenPoint(transform.position));
        if (Analizator.Result == 100) Analizator.IsAnalyze = true;
        if (!MovingToStartPosition()) _audioSource.Play(); 
        if (!MovingToStartPosition() && !GameManager.gameManager.IsTime)
            StepCalculation();
    }
    private bool MovingToStartPosition()
    {
        bool IsMoving = false;
        if(transform.position.x > -5.7f && transform.position.x < -0.5f 
           && transform.position.y > -4f && transform.position.y < 2.7f)
        {
            transform.position = Vector3.Lerp(transform.position, _startPosition, 1.0f);
            IsMoving = true;
        }
        return IsMoving;
    }  
    private void StepCalculation()
    {
        _audioSource.Play();
        _stepCounter.Count--;
        StepsPanel.stepsPanel.StepsCountText.text = _stepCounter.Count.ToString();
        if (_stepCounter.Count <= (int)StepCounter.stepCounter.EndedStepCount)
        {
            StepsPanel.stepsPanel.StepsCountText.GetComponent<Animator>().SetTrigger("Ended");
        }
    } 


}
