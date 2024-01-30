namespace BestLearn
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                "Dial a Number",
                "Would you like to call" + translatedNumber + "?",
                "Yes",
                "No"))
            {
                // Todo: dial the phone
                try
                {
                    if (PhoneDialer.Default.IsSupported)
                        PhoneDialer.Default.Open(translatedNumber);
                }
                catch (ArgumentException)
                {
                    await DisplayAlert("Unable to dial", "Phone number was not valid", "OK");

                }
                catch (Exception) {
                    await DisplayAlert("Unable to Dial", "Phone Dialing failed", "OK");
                }


            }
        }

        string translatedNumber;
        
        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = PhoneNumberText.Text;
            translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrEmpty(translatedNumber) )
            {
                CallButton.IsEnabled = true;
                CallButton.Text = "Call" + translatedNumber;
            }
            else
            {
                CallButton.IsEnabled= false;
                CallButton.Text = "Call";
            }
        }

    }
}
