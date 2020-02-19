using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    private int _touchIndex = -1;
    private Vector3 _targetPosition;
    private Camera _cam;
    private Ray _ray;
    private Plane _xy;
    private float _distance;

    private Transform Trans;
 
    [SerializeField] public float MoveSpeed = 10;
    [SerializeField] public float MaxMoveSpeed = 50;
    [SerializeField] private float RangeMoveX = 3;
    [SerializeField] private float RangeMoveY = 5;
    [SerializeField] private int stepMove = 100;
    [SerializeField] private bool move1;

    [SerializeField]
    private float _screenDpi;

    private bool _isDown;
    private Vector3 _oldMousePosition;

    private bool _isLock;
    void Awake() {
        Trans = transform;
        _cam = Camera.main;
        _xy = new Plane(Vector3.forward, new Vector3(0, 0, 0));
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            _touchIndex = 0;

        _screenDpi = Screen.width / 720f;
        RangeMoveX = GamePlayConfig.borderW / 2;
        RangeMoveY = GamePlayConfig.borderH / 2;
    }

    void OnEnable() {
        _isLock = true;

    }

    void OnDisable() {
    }

    private void CallOnRevive() {
        _isLock = false;
    }
    private void OnStartAttack() {
        _isLock = true;
    }


    void Update() {
        if (!_isLock) return;

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject(_touchIndex)) {
            _oldMousePosition = GetMousePosition();
            _isDown = true;

            if (!move1) {
                _targetPosition = Trans.position;
            }
        } else if (Input.GetMouseButtonUp(0)) {
            _isDown = false;
        }

        if (Input.GetMouseButton(0) && _isDown) {
            var mousePosition = GetMousePosition();
            MoveSpeed = MaxMoveSpeed;

            if (move1) {
                _targetPosition = (mousePosition + Vector3.up);
            } else {
                _targetPosition += (mousePosition - _oldMousePosition) * MoveSpeed;
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

            //var rig = Physics2D.Raycast(Trans.position, (_targetPosition - Trans.position).normalized, 100 * Time.deltaTime);
            Trans.position = Vector2.MoveTowards(Trans.position, _targetPosition, stepMove * Time.deltaTime);
            //TODO: Create raycast to check enemy

            //if(rig)
            //    Debug.Log("hit enemy dont dead");

            _oldMousePosition = mousePosition;
        } else {
            MoveSpeed = 0;
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
