using System;
using Unity.Notifications.Android;
using UnityEngine;

public class PushNotification : MonoBehaviour
{
    [SerializeField] private GameObject gm;

    void Start()
    {
        CreateChannel();
        OnNotificationClick();
    }

    public void CreateChannel()
    {
        AndroidNotificationChannel channel = new()
        {
            Id = "channel_id",
            Name = "Standart",
            Importance = Importance.High,
            Description = "Notification"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        AndroidNotificationCenter.CancelAllNotifications();
    }

    public void StartNotification()
    {
        var notification = new AndroidNotification
        {
            Title = "Увернись от двойки",
            Text = "Быстрее поступай в ВУЗ и не получи двойку",
            SmallIcon = "icon_0",
            Style = NotificationStyle.BigTextStyle,
            FireTime = DateTime.Now.AddSeconds(10),
            IntentData = "123",
            ShowInForeground = true,
            RepeatInterval = TimeSpan.FromSeconds(1),
        };
        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }    

    public void OnNotificationClick()
    {
        AndroidNotificationIntentData intent = AndroidNotificationCenter.GetLastNotificationIntent();
        if (intent != null)
        {
            string intentData = intent.Channel.ToString();

            if (intentData == "channel_id")
            {
                gm.SetActive(true);
            }
        }
    }
}