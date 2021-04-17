using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggleable : MonoBehaviour
{
    private Image _image;

    private SpriteRenderer _spriteRenderer;

    public bool showOnStart = false;

    public float hideDelay = 0f;

    [Header("Read-Only")]
    public bool hidden;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        ShowHide(showOnStart);
    }

    public void Show(bool toggle = true)
    {
        if (!toggle && hideDelay > 0)
            StartCoroutine(HideWithDelay());
        else
            ShowHide(toggle);
    }

    private void ShowHide(bool toggle = true)
    {
        if (_image != null)
            _image.enabled = toggle;

        if (_spriteRenderer != null)
            _spriteRenderer.enabled = toggle;

        for (var x = 0; x < transform.childCount; x++)
        {
            var child = transform.GetChild(x).gameObject;
            child.SetActive(toggle);
        }

        hidden = !toggle;
    }

    private IEnumerator HideWithDelay()
    {
        yield return new WaitForSeconds(hideDelay);
        ShowHide(false);
    }
}
