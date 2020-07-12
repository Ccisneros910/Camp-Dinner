using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroImageSwitcher : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] images;
    [SerializeField] private AudioSource audio;
    [SerializeField] private SO_DialogueNode starterNode;
    public int sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(starterNode);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SwitchScene(int num)
    {
        if(num == 2)
        {
            SceneManager.LoadScene(sceneToLoad);
            return;
        }
        spriteRenderer.sprite = images[num];
        audio.Stop();
    }
}
