using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text)),
RequireComponent(typeof(Counter))]
public class ValueRenderer : MonoBehaviour
{
    private Counter _counter;
    private TMP_Text _label;

    private void Awake()
    {
        _counter = GetComponent<Counter>();
        _label = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _counter.Changed += Change;
    }

    private void OnDisable()
    {
        _counter.Changed -= Change;
    }

    private void Change(int value)
    {
        _label.text = value.ToString("");
    }
}
