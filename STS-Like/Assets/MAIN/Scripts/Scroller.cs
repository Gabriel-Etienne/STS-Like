using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _image;
    [SerializeField] private float _x, _y;

    public static Action<float, Vector2> OnScroll;      // to scroll a definite amount of time
    public static Action<Vector2> OnScrollInfinitely;   // to scroll until the stop action is called
    
    public static Action OnScrollStop;                  // to call to stop any scroll
    public static Action OnScrollStopped;               // to call when any scroll has been stopped
    
    private float _duration = 1f;
    private Coroutine _scrollRoutine;

    private void OnEnable()
    {
        OnScroll += Scroll;
        OnScrollInfinitely += ScrollInfinitely;
        OnScrollStop += StopScroll;
    }

    private void OnDisable()
    {
        OnScroll -= Scroll;
        OnScrollInfinitely -= ScrollInfinitely;
        OnScrollStop -= StopScroll;
    }

    private void Start()
    {
        // test
        OnScrollInfinitely?.Invoke(new Vector2(_x, _y));
    }

    private void Scroll(float duration, Vector2 scrollPos)
    {
        _duration = duration;
        _x = scrollPos.x;
        _y = scrollPos.y;
        
        if (_scrollRoutine != null)
            StopCoroutine(_scrollRoutine);
        _scrollRoutine = StartCoroutine(ScrollRoutine());
    }

    private void ScrollInfinitely(Vector2 scrollPos)
    {
        _x = scrollPos.x;
        _y = scrollPos.y;
        
        if (_scrollRoutine != null)
            StopCoroutine(_scrollRoutine);
        _scrollRoutine = StartCoroutine(ScrollInfinitelyRoutine());
    }

    private void StopScroll()
    {
        if (_scrollRoutine != null)
            StopCoroutine(_scrollRoutine);
        
        OnScrollStopped?.Invoke();
    }
    
    private IEnumerator ScrollRoutine()
    {
        float timer = 0;

        while (timer < _duration)
        {
            timer += Time.deltaTime;
            _image.uvRect = new Rect(_image.uvRect.position +  new Vector2(_x, _y) * Time.deltaTime, _image.uvRect.size);
            yield return null;
        }
        
        OnScrollStopped?.Invoke();
    }

    private IEnumerator ScrollInfinitelyRoutine()
    {
        while (true)
        {
            _image.uvRect = new Rect(_image.uvRect.position +  new Vector2(_x, _y) * Time.deltaTime, _image.uvRect.size);
            yield return null;
        }
    }
    
}
