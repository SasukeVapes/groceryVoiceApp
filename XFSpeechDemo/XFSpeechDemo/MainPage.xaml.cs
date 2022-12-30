using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace XFSpeechDemo
{

    public partial class MainPage : ContentPage
    {    
        private ISpeechToText _speechRecongnitionInstance;
        public MainPage()
        {
            InitializeComponent();
            try
            {
                _speechRecongnitionInstance = DependencyService.Get<ISpeechToText>();
            }
            catch (Exception ex)
            {
                recon.Text = ex.Message;
            }


            MessagingCenter.Subscribe<ISpeechToText, string>(this, "STT", (sender, args) =>
            {
                SpeechToTextFinalResultRecieved(args);
            });

            MessagingCenter.Subscribe<ISpeechToText>(this, "Final", (sender) =>
            {
                start.IsEnabled = true;
            });

            MessagingCenter.Subscribe<IMessageSender, string>(this, "STT", (sender, args) =>
            {
                SpeechToTextFinalResultRecieved(args);
            });
            
        }
        

      

        private void SpeechToTextFinalResultRecieved(string args)
        {
            recon.Text = args;
            
            if (recon.Text == "test")
            {
                recon.Text = "test";
              
            }

        }

        private void Start_Clicked(object sender, EventArgs e)
        {
            try
            {
                _speechRecongnitionInstance.StartSpeechToText();
                
                
            }
            catch (Exception ex)
            {
                recon.Text = ex.Message;
                
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                start.IsEnabled = false;
            }



        }
        
        private void recon_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var stepperValue = e.NewValue;
            amount.Text = $"Колличество: {stepperValue}";

            //  Amount=stepperValue;
        }

    }


}
