using UnityEngine;

public class CharacterCollider2d : MonoBehaviour
{
    public float speed = 0.1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDir, 0.0f, zDir);

        transform.position += moveDirection * speed;
    }
}
