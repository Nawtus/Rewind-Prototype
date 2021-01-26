using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{
    public bool isRewinding;
    public List<Vector3> positions = new List<Vector3>(500); 
    public MovementScript movement;



    private void FixedUpdate()
    {
        if (!isRewinding)
        {
            SavePositions();
            movement.enabled = true;
        }
        else
        {
            movement.enabled = false;
        }
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RewindToLastPosition());
        }
    }



    void SavePositions()
    {
        if (positions.Count >= positions.Capacity)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                positions.Remove(positions[0]);
            }
        }
        else
        {
            positions.Add(transform.position);
        }
    }



    private IEnumerator RewindToLastPosition()
    {
        isRewinding = true;
        for (int i = positions.Count - 1; i >= 0; i--)
        {
            transform.position = Vector3.Lerp(transform.position, positions[i], movement.Speed * Time.deltaTime);
            positions.Remove(positions[i]);
            yield return new WaitForEndOfFrame();
        }
        isRewinding = false;
    }
}
