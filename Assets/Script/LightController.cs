using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LightController : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private int num = 0;
    private Renderer _renderer;
    private float _alfa = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(_renderer.material.color.a <= 0.0f))
        {
            _alfa = 0.0f;
            _renderer.material.color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, _alfa);
        }

        if (num == 1)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                ColorChange();
            }
        }
        if (num == 2)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ColorChange();
            }
        }
        if (num == 3)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                ColorChange();
            }
        }
        if (num == 4)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                ColorChange();
            }
        }
        _alfa -= speed * Time.deltaTime;
    }

    private void ColorChange()
    {
        _alfa = 0.3f;
        _renderer.material.color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, _alfa);
    }
}
