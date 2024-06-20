using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TextCounter : MonoBehaviour
{
    private const int Left = 0;
    
    private TMP_Text _label;
    private float _delay = 0.5f;
    private int _counter;
    private Coroutine _coroutine;

    private void Awake()
    {
        _label = GetComponent<TMP_Text>();
        _label.text = _counter.ToString("");
    }

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
            _label.text = _counter++.ToString("");
            
            yield return delay;
        }
    }
}
