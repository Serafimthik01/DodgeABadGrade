using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject noEscape;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 realPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = realPos;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ShowNoEsc());
        }
    }

    IEnumerator ShowNoEsc()
    {
        noEscape.SetActive(true);
        yield return new WaitForSeconds(2);
        noEscape.SetActive(false);
    }
}