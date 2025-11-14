using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;

public class GooglePlayManager : MonoBehaviour
{
    public static GooglePlayManager Instance;

    // MỚI: Biến để theo dõi trạng thái đăng nhập
    public bool IsAuthenticated { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            IsAuthenticated = false; // Khởi tạo trạng thái
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayGamesPlatform.Activate();
        SignIn();
    }

    void SignIn()
    {
        // Hàm Authenticate đơn giản, không có tham số đầu tiên
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            Debug.Log("Login successful! Welcome " + Social.localUser.userName);
            IsAuthenticated = true; // Cập nhật trạng thái
        }
        else
        {
            Debug.Log("Login Failed!");
            IsAuthenticated = false; // Cập nhật trạng thái
        }
    }

    // =============================================================
    // CÁC HÀM CŨ CỦA BẠN (ĐƯỢC NÂNG CẤP)
    // =============================================================
    public void UnlockAchievement(string achievementID)
    {
        // Nâng cấp: Chỉ chạy nếu đã đăng nhập
        if (IsAuthenticated)
        {
            PlayGamesPlatform.Instance.ReportProgress(achievementID, 100.0f, (bool success) => {
                if (success) { Debug.Log("Successfully unlocked achievement: " + achievementID); }
                else { Debug.LogError("Failed to unlock achievement: " + achievementID); }
            });
        }
    }

    public void PostScoreToLeaderboard(long score, string leaderboardID)
    {
        // Nâng cấp: Chỉ chạy nếu đã đăng nhập
        if (IsAuthenticated)
        {
            PlayGamesPlatform.Instance.ReportScore(score, leaderboardID, (bool success) => {
                if (success) { Debug.Log("Successfully posted score " + score + " to leaderboard " + leaderboardID); }
                else { Debug.LogError("Failed to post score to leaderboard " + leaderboardID); }
            });
        }
    }

    // =============================================================
    // HÀM HIỂN THỊ UI (ĐƯỢC SỬA LẠI HOÀN TOÀN)
    // =============================================================
    public void ShowLeaderboardUI()
    {
        // Nếu đã đăng nhập, hiển thị luôn
        if (IsAuthenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            // Nếu chưa, gọi lại hàm đăng nhập SignIn()
            // Hàm này sẽ hiện pop-up nếu người dùng chưa từng đăng nhập
            Debug.Log("User not signed in. Trying to sign in...");
            SignIn();
        }
    }

    public void ShowAchievementsUI()
    {
        if (IsAuthenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
        else
        {
            Debug.Log("User not signed in. Trying to sign in...");
            SignIn();
        }
    }
}