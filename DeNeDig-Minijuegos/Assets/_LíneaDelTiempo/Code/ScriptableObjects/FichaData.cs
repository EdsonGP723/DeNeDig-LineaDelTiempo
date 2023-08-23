
using UnityEngine;

[CreateAssetMenu(fileName ="New Ficha", menuName = "Ficha")]
public class FichaData : ScriptableObject
{
    [SerializeField] private int level;
    [SerializeField] private int index;
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private Sprite image; 

    public int Level { get { return level; } }

    public int Index { get { return index; } }

    public string Title { get { return title; } }

    public string Description { get { return description; } }

    public Sprite Image { get { return image; } }
}
