using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private const int Left = 0;
    
    private Coroutine _coroutine;
    private int _value;
    private float _delay = 0.5f;

    public event UnityAction<int> Changed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(Left))
        {
            if (_coroutine is null)
            {
                _coroutine = StartCoroutine(Counting());
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator Counting()
    {
        bool isWorking = true;
        var delay = new WaitForSeconds(_delay);

        while (isWorking)
        {
            _value++;

            Changed?.Invoke(_value);
            
            yield return delay;
        }
    }
}
