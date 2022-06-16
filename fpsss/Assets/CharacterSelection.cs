using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;

    public int selectedCharacter = 0;

    [SerializeField]
    private Text selectedNameText;

    [SerializeField]
    private Text selectedClassText;

    private void Start()
    {
        selectedNameText.text = characters[selectedCharacter].GetComponent<Character>().characterName.ToString();
        selectedClassText.text = characters[selectedCharacter].GetComponent<Character>().characterClass.ToString();
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        selectedNameText.text = characters[selectedCharacter].GetComponent<Character>().characterName.ToString();
        selectedClassText.text = characters[selectedCharacter].GetComponent<Character>().characterClass.ToString();
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
            selectedCharacter += characters.Length;
        characters[selectedCharacter].SetActive(true);
        selectedNameText.text = characters[selectedCharacter].GetComponent<Character>().characterName.ToString();
        selectedClassText.text = characters[selectedCharacter].GetComponent<Character>().characterClass.ToString();
    }

    public void StartGame()
    {
        Debug.Log("Wybrano postac: " + selectedCharacter);
        SceneManager.LoadScene(1);
    }
}