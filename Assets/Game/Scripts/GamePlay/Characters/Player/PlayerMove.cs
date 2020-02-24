using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : CharacterMove
{
    private int _touchIndex = -1;
    private Vector3 _targetPosition;
    private Camera _cam;
    private Ray _ray;
    private Plane _xy;
    private float _distance;
    private Transform Trans;
 
    [SerializeField] public float moveSpeed = 10;
    [SerializeField] public float moveSpeedMax = 50;
    [SerializeField] private float RangeMoveX = 3;
    [SerializeField] private float RangeMoveY = 5;
    [SerializeField] private int stepMove = 100;
    [SerializeField] private bool move1;

    private bool _isDown;
    private Vector3 _oldMousePosition;
    private bool isTouching;

    void Awake() {
        Trans = transform;
        _cam = Camera.main;
        _xy = new Plane(Vector3.forward, new Vector3(0, 0, 0));
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            _touchIndex = 0;

        RangeMoveX = GamePlayConfig.borderW / 2;
        RangeMoveY = GamePlayConfig.borderH / 2;
    }

    public bool CanMoveControl() {
        GetInput();
        return isTouching;
    }

    public bool HasMoveControlComplete() {
        GetInput();
        return !isTouching;
    }

    private void GetInput() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject(_touchIndex)) {
            _oldMousePosition = GetMousePosition();
            if (!isTouching) {
                isTouching = true;
                //EventDispatcher.Instance.Dispatch(EventKey.START_INPUT_TOUCH_DOWN);
            }
            _targetPosition = transform.position;
        } else if (Input.GetMouseButtonUp(0)) {
            if (isTouching) {
                isTouching = false;
                //EventDispatcher.Instance.Dispatch(EventKey.START_INPUT_TOUCH_UP);
            }
        }
    }

    public void MoveControl() {
        if (Input.GetMouseButton(0) && isTouching) {
            var mousePosition = GetMousePosition();
            moveSpeed = moveSpeedMax;
            if (move1) {
                _targetPosition += (mousePosition - _oldMousePosition) * moveSpeed;

            } else {
                _targetPosition = mousePosition;
            }
            // Fix move            

            if (_targetPosition.x > RangeMoveX) {
                _targetPosition.x = RangeMoveX;
            } else if (_targetPosition.x < -RangeMoveX) {
                _targetPosition.x = -RangeMoveX;
            }

            if (_targetPosition.y > RangeMoveY) {
                _targetPosition.y = RangeMoveY;
            } else if (_targetPosition.y < -RangeMoveY) {
                _targetPosition.y = -RangeMoveY;
            }
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, stepMove * Time.deltaTime);
            _oldMousePosition = mousePosition;
        } else {
            moveSpeed = 0;
        }
    }

    Vector3 GetMousePosition() {
#if UNITY_EDITOR
        return GetWorldPositionOnPlane(Input.mousePosition);
#else
        return GetWorldPositionOnPlane(Input.touches[0].position);
#endif
    }

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition) {
        _ray = _cam.ScreenPointToRay(screenPosition);
        _xy.Raycast(_ray, out _distance);
        return _ray.GetPoint(_distance);
    }

}
