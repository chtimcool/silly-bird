using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private AudioClip[] _audios;

    private Rigidbody _rb;
    private Animator _animator;
    private int _bonus;
    private AudioSource _source;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * _force, ForceMode.Impulse);
            _source.PlayOneShot(_audios[0]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Potoloc"))
        {
            _animator.Play("Death");
            UserEnterFace.action.Invoke();
            _source.PlayOneShot(_audios[1]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonus"))
        {
            _bonus++;
            _text.text = _bonus.ToString();
            Destroy(other.gameObject);
            _source.PlayOneShot(_audios[Random.Range(2, 6)]);
        }
    }
}
