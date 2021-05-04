using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] UnityEvent<float> swipeAction;

    Vector2 startPos;

    float CalculateAngle(Vector2 _startPos, Vector2 _endPos)
    {
        _endPos -= _startPos;
        float _angle = Vector2.SignedAngle(_endPos, Vector2.up);
        return _angle;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData _evenData)
    {
        startPos = _evenData.position;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData _evenData)
    {
        float _angle = CalculateAngle(startPos, _evenData.position);
        swipeAction.Invoke(_angle);
    }
}
