using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using LM3D.Models;
using SmsManager = Android.Telephony.SmsManager;
using Xamarin.Forms;
using Android.Bluetooth;
using Android.OS;
using Java.Lang;
using DotLiquid.Tags;
using Xamarin.Essentials;

namespace LM3D.Data
{
    public class OperationsMessages 
    {
        private SmsManager sms;
        private PendingIntent sentPI;
      
        public OperationsMessages() {
             sms = SmsManager.Default;
        }
        
        public int Send (SendMessage message)
        {
            string SENT = "SMS_SENT";

            sentPI = PendingIntent.GetBroadcast(Android.App.Application.Context, 0, new Intent(SENT), 0);
            //var pendingIntent = PendingIntent.GetActivity(Android.App.Application.Context, 0, new Intent(Android.App.Application.Context, typeof(MainActivity)).AddFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask), PendingIntentFlags.NoCreate);
            sms.SendTextMessage(message.Number, null,message.Message, sentPI, null);
            
            if (sentPI != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //------------------------------------------------------------------
        public void PlacePhoneCall(SendMessage phone)
        {
            PhoneDialer.Open(phone.Number);
            
        }


    }
}
