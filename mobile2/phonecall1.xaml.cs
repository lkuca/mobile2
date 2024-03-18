using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Plugin.Messaging;
using Xamarin.Essentials;
using System.Runtime.InteropServices;
using System.Linq;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace mobile2
{
    public partial class phonecall1 : ContentPage
    {
        TableView tableView;

        EntryCell tel_nr_email, text;
        


        public phonecall1()
        {
            tel_nr_email = new EntryCell()
            {
                Text = "Kirjuta siia telefoni number"
                
            };
            text = new EntryCell()
            {
                Text =" Kirjuta siia text"
            };
            
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("+79876543210");

            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if (smsMessenger.CanSendSms)
                smsMessenger.SendSms("+79876543210", "Hello World!");
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail("адрес получателя", "тема письма", "текст письма");
            }


           


        }
        private async void call_btn_Clicked(object sender, EventHandler e)
        {

            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall)
            {
                call.MakePhoneCall(tel_nr_email.Text);
            }
            //try
            //{
            //    var number = ((EntryCell)tableView.Root[1][0]).Text;
            //    if (!string.IsNullOrWhiteSpace(number))
            //    {
            //        await Launcher.OpenAsync(new Uri("tel:" + number));
            //    }
            //    else
            //    {
            //        await DisplayAlert("Viga", "Palun sissesta tel. number", "OK");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    await DisplayAlert("Viga", $"Tekkis tõrge helistamisel: {ex.Message}", "OK");
            //}
        }
        private void sms_btn_Clicked(object sender, EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
            {
                sms.SendSms(tel_nr_email.Text, text.Text);
            }
        }
        private void mail_btn_Clicked(Object sender, EventArgs e)
        {
            var mail = CrossMessaging.Current.EmailMessenger;
            if (mail.CanSendEmail)
            {
                mail.SendEmail(tel_nr_email.Text, "Tervitsus!", text.Text);
            }
        }
    }

}
