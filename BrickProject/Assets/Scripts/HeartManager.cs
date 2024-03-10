using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Reference to EasyManager
    private EasyManager easyManager;

    private void Start()
    {
        // Find the EasyManager instance in the scene
        easyManager = FindObjectOfType<EasyManager>();
        if (easyManager == null)
        {
            Debug.LogError("EasyManager not found in the scene.");
            return;
        }

        // Update UI based on initial lives
        Update();
    }

    private void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < hearts.Length && i < easyManager.lives; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}
