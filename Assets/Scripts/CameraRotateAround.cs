using UnityEngine;

public class CameraRotateAround : MonoBehaviour {

	private Vector2 _rotateDelta;
	private float _direction;

	[SerializeField] private Transform _target;
	[SerializeField] private Vector3 _offset;
	[SerializeField] private float _sensitivity;
	[SerializeField] private float _limit; 
	void Start () 
	{
		_limit = Mathf.Abs(_limit);
		if(_limit > 90) _limit = 90;
		SwipeController.SwipeEvent += CheckSwipe;
	}
	void Update ()
	{
			CalculateSwipe();
	}
	private void CalculateSwipe()
	{
		_rotateDelta.x = transform.localEulerAngles.y + _direction * _sensitivity;
		transform.localEulerAngles = new Vector3(-_rotateDelta.y, _rotateDelta.x, 0);
		transform.position = transform.localRotation * _offset + _target.position;
		if (Input.touchCount > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended)
			{
				ResetSwipe();
			}
		}
	}
	protected void CheckSwipe(SwipeController.SwipeType type)
	{
		if (type == SwipeController.SwipeType.LEFT)
			_direction = -1;
		else if (type == SwipeController.SwipeType.RIGHT)
			_direction = 1;
	}

	private void ResetSwipe()
	{
		_direction = 0;
	}
}