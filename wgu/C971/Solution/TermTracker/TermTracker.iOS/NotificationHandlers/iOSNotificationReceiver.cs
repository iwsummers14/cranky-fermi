﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using TermTracker.Interfaces;
using UIKit;
using UserNotifications;
using Xamarin.Forms;

namespace TermTracker.iOS.NotificationHandlers
{
    /// <summary>
    /// Delegate class to receive notifications on iOS devices.
    /// </summary>
    public class iOSNotificationReceiver : UNUserNotificationCenterDelegate
    {
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            //DependencyService.Get<INotificationManager>().ReceiveNotification(notification.Request.Content.Title, notification.Request.Content.Body);
            completionHandler(UNNotificationPresentationOptions.Alert);
        }
    }
}