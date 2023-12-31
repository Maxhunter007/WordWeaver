using System;
using UnityEngine;

public class LetterContainer : MonoBehaviour
{
    public Letter ContainedLetter;

    private LetterManager _letterManager;
    private Camera _cam;
    private void Start()
    {
        _cam = Camera.main;
        _letterManager = FindObjectOfType<LetterManager>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(_cam.ScreenPointToRay(_cam.WorldToScreenPoint(transform.position)), 20, ~(1<<5));
        if (hit.collider && hit.collider.gameObject.CompareTag("Letter"))
        {
            var letter = hit.collider.gameObject.GetComponent<Letter>();
            letter.SnapToContainer(this);
            ContainedLetter = letter; 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Letter"))
        {
            ContainedLetter = other.GetComponent<Letter>();
            ContainedLetter.SnapToContainer(this);
            _letterManager.OnNextUpdate += _letterManager.CheckForSolution;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Letter"))
        {
            var letter = other.GetComponent<Letter>();
            if (letter.Equals(ContainedLetter))
            {
                ContainedLetter = null;
            }
            letter.ReleaseSnap(this);
            if (letter.IsInHand)
            {
                letter.DisableGravity();
            }
        }
        _letterManager.OnNextUpdate += _letterManager.CheckForSolution;
    }
}
