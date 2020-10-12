using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using System;
using TermTracker.Events;
using TermTracker.Interfaces;
using AndroidApp = Android.App.Application;
using NotificationCompat = Android.Support.V4.App.NotificationCompat;

[assembly: Xamarin.Forms.Dependency(typeof(TermTracker.Droid.NotificationHandlers.AndroidNotificationManager))]
namespace TermTracker.Droid.NotificationHandlers
{
    /// <summary>
    /// Android implementation of the INotificationManager class.  Handles notifications for android devices. 
    /// </summary>
    public class AndroidNotificationManager : INotificationManager
    {
        const string channelId = "default";
        const string channelName = "Default";
        const string channelDescription = "The default channel for notifications.";
        const int pendingIntentId = 0;

        public const string TitleKey = "title";
        public const string MessageKey = "message";

        bool channelInitialized = false;
        int messageId = -1;
        NotificationManager manager;

        public event EventHandler NotificationReceived;

        public void Initialize()
        {
            CreateNotificationChannel();        
        }

        public void ReceiveNotification(string title, string message)
        {
            var args = new NotificationEventArgs()
            {
                Title = title,
                Message = message
            };

            NotificationReceived?.Invoke(null, args);
        }

        public int ScheduleNotification(string title, string message)
        {
            if (channelInitialized == false)
            {
                CreateNotificationChannel();
            }

            messageId++;

            Intent intent = new Intent(AndroidApp.Context, typeof(MainActivity));
            intent.PutExtra(TitleKey, title);
            intent.PutExtra(MessageKey, message);

            PendingIntent pendingIntent = PendingIntent.GetActivity(AndroidApp.Context, pendingIntentId, intent, PendingIntentFlags.OneShot);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(AndroidApp.Context, channelId);
            builder.SetContentIntent(pendingIntent);
            builder.SetContentTitle(title);
            builder.SetContentText(message);
            builder.SetLargeIcon(BitmapFactory.DecodeResource(AndroidApp.Context.Resources, Resource.Drawable.wgu_owl));
            builder.SetSmallIcon(Resource.Drawable.wgu_owl);
            builder.SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate);

            var notification = builder.Build();
            manager.Notify(messageId, notification);

            return messageId;
        }


        private void CreateNotificationChannel()
        {
            manager = (NotificationManager)AndroidApp.Context.GetSystemService(AndroidApp.NotificationService);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelNameJava = new Java.Lang.String(channelName);
                var channel = new NotificationChannel(channelId, channelNameJava, NotificationImportance.Default)
                {
                    Description = channelDescription
                };
                manager.CreateNotificationChannel(channel);

                channelInitialized = true;
            }
        }
    }
}