using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Explore Time", menuName = "Explore Time/Explore Time")]
public class ExploreTimeSO : ScriptableObject {
    [SerializeField]
    int maxExploreTime = 3;
    [SerializeField]
    int currentExploreTime = 3;

    public List<Sprite> exploreTimeSprites = new List<Sprite>();

    public int MaxExploreTime
    {
        get { return maxExploreTime; }
    }

    public int CurrentExploreTime
    {
        get { return currentExploreTime; }
        set
        {
            currentExploreTime = value;
            if (currentExploreTime < 0)
            {
                currentExploreTime = 0;
            }
            else if (currentExploreTime > maxExploreTime)
            {
                currentExploreTime = maxExploreTime;
            }
        }
    }

}
