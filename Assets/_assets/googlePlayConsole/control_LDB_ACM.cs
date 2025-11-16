using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_LDB_ACM : MonoBehaviour
{
    public void onclickLeaderboards()
    {
        GooglePlayManager.Instance.ShowLeaderboardsUI();
    }
    public void onclickAchievements()
    {
        GooglePlayManager.Instance.ShowAchievementsUI();
    }    

}
