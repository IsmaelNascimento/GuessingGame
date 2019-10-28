using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables

    #region UIs

    [Header("Windows")]
    [SerializeField] private GameObject m_WindowsStart;
    [SerializeField] private GameObject m_WindowSeeAnimalTrait;
    [SerializeField] private GameObject m_WindowSeeNameAnimal;
    [SerializeField] private GameObject m_WindowWin;
    [SerializeField] private GameObject m_WindowWhatAnimal;
    [SerializeField] private GameObject m_WindowAnimalTrait;

    [Space(10)][Header("InputFields")]
    [SerializeField] private InputField m_InputFieldNameAnimal;
    [SerializeField] private InputField m_InputFieldAnimalTrait;

    [Space(10)][Header("Texts")]
    [SerializeField] private Text m_TextSeeAnimalTrait;
    [SerializeField] private Text m_TextSeeNameAnimal;
    [SerializeField] private Text m_TextInputFieldNameAnimal;


    #endregion

    #region Controllers

    private List<string> m_NameAnimals = new List<string>();
    private List<string> m_AnimalTraits = new List<string>();
    private int indexAnimal = 0;

    #endregion

    #endregion

    #region Methods MonoBehaviour

    private void Start()
    {
        m_NameAnimals.Add("shark");
        m_AnimalTraits.Add("lives in water");
        m_TextSeeAnimalTrait.text = string.Format("Does the animal that you thought about {0} ?", m_AnimalTraits[0]);

        //foreach (var nameAnimal in m_NameAnimals)
        //{
        //    print(nameAnimal);
        //}
    }

    //[ContextMenu("AddAnimal")]
    //public void TestAddNameAnimals()
    //{
    //    m_NameAnimals.Insert(1, "Dog");

    //    foreach(var nameAnimal in m_NameAnimals)
    //    {
    //        print(nameAnimal);
    //    }
    //}

    #endregion

    #region Methods UIs

    public void OnButtonOpenWindowClicked(GameObject window)
    {
        window.SetActive(true);
    }

    public void OnButtonCloseWindowClicked(GameObject window)
    {
        window.SetActive(false);
    }

    public void OnButtonQuitClicked()
    {
        Application.Quit();
    }

    public void OnButtonNoAnimalTraitClicked()
    {
        if (indexAnimal < m_AnimalTraits.Count)
        {
            m_TextSeeAnimalTrait.text = string.Format("Does the animal that you thought about {0} ?", m_AnimalTraits[indexAnimal]);
            indexAnimal++;
        }
        else
        {
            m_WindowSeeAnimalTrait.SetActive(false);
            m_WindowSeeNameAnimal.SetActive(true);
            m_TextSeeNameAnimal.text = string.Format("Is the animal that you thought about a {0}", "monkey");
        }

    }

    public void OnButtonConfirmNameAnimal()
    {
        m_NameAnimals.Add(m_InputFieldNameAnimal.text);
        m_TextInputFieldNameAnimal.text = string.Format("A {0} but a monkey does not (Fill it with an animal trait)", m_InputFieldNameAnimal.text);
        m_InputFieldNameAnimal.text = string.Empty;
    }

    public void OnButtonConfirmAnimalTrait()
    {
        m_AnimalTraits.Add(m_InputFieldAnimalTrait.text);
        m_InputFieldAnimalTrait.text = string.Empty;
    }

    public void OnButtonConfirmYesAnimalTrait()
    {
        m_TextSeeNameAnimal.text = string.Format("Is the animal that you thought about a {0} ?", m_NameAnimals[indexAnimal - 1]);
    }

    public void OnButtonConfirmStartClicked()
    {
        indexAnimal = 0;
        m_TextSeeAnimalTrait.text = string.Format("Does the animal that you thought about {0} ?", m_AnimalTraits[indexAnimal]);
    }

    #endregion
}