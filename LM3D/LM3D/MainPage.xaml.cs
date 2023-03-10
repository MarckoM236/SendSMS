using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using LM3D.Commons;
using LM3D.Models;
using LM3D.Data;
using System.Linq.Expressions;
using LM3D.Views;

namespace LM3D
{
    public partial class MainPage : ContentPage
    {
        public Messages msg;
        public OperationsMessages opr;
        public MainPage()
        {
            InitializeComponent();
            var status = Permissions.RequestAsync<Permissions.Sms>();
            
            msg = new Messages();
            opr = new OperationsMessages();
           
        }

        
//--------------------------------------------------------------------------------------------------
        //Stop Motor
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var message = new SendMessage
                {
                    Message = msg.Stop.ToString(),
                    Number = msg.Phone.ToString()
                };

                var result = opr.Send(message);

                if (result == 1)
                {
                    await DisplayAlert("Exito", "Se envio comando de Apagado Exitosamente", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo enviar el mensaje", "Aceptar");
                }
            }

            catch (System.Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }

        }
        //Start Motor
        private async void TurnOn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var message = new SendMessage
                {
                    Message = msg.Start.ToString(),
                    Number = msg.Phone.ToString()
                };


                var result = opr.Send(message);

                if (result == 1)
                {
                    await DisplayAlert("Exito", "Se envio comando de Encendido" +
                        " Exitosamente", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo enviar el mensaje", "Aceptar");
                }
            }

            catch (System.Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
//--------------------------------------------------------------------------------------------

        //Location
        private async void Location_Clicked(object sender, EventArgs e)
        {
            try{
                var phone = new SendMessage
                {
                    Number = msg.Phone.ToString()
                };

                opr.PlacePhoneCall(phone);
            }
            catch(System.Exception ex){
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
//---------------------------------------------------------------------------------------------------------

        //On Alarm
        private async void AlarmOn_Clicked(object sender, EventArgs e) {
            try
            {
                var message = new SendMessage
                {
                    Message = msg.Arm.ToString(),
                    Number = msg.Phone.ToString()
                };


                var result = opr.Send(message);

                if (result == 1)
                {
                    await DisplayAlert("Exito", "Se envio comando para Activar Alarma" +
                        " Exitosamente", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo enviar el mensaje", "Aceptar");
                }
            }

            catch (System.Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
        //Off Alarm
        private async void AlarmOff_Clicked(object sender, EventArgs e) {
            try
            {
                var message = new SendMessage
                {
                    Message = msg.Disarm.ToString(),
                    Number = msg.Phone.ToString()
                };


                var result = opr.Send(message);

                if (result == 1)
                {
                    await DisplayAlert("Exito", "Se envio comando para Desactivar Alarma" +
                        " Exitosamente", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo enviar el mensaje", "Aceptar");
                }
            }

            catch (System.Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

//------------------------------------------------------------------------------------------
       
        //Activate microphone
        private async void ActMic_Clicked(object sender, EventArgs e) {
            try
            {
                var message = new SendMessage
                {
                    Message = msg.OnMicro.ToString(),
                    Number = msg.Phone.ToString()
                };


                var result = opr.Send(message);

                if (result == 1)
                {
                    await DisplayAlert("Exito", "Se envio comando para Activar Microfono" +
                        " Exitosamente", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo enviar el mensaje", "Aceptar");
                }
            }

            catch (System.Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
        //Desactivate Microphone
        private async void DesactMic_Clicked(object sender, EventArgs e) {
            try
            {
                var message = new SendMessage
                {
                    Message = msg.OffMicro.ToString(),
                    Number = msg.Phone.ToString()
                };


                var result = opr.Send(message);

                if (result == 1)
                {
                    await DisplayAlert("Exito", "Se envio comando para Desactivar microfono" +
                        " Exitosamente", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo enviar el mensaje", "Aceptar");
                }
            }

            catch (System.Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

//-----------------------------------------------------------------------------------
        
        //Authorize Phone number
        private async void Auth_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new AuthorizeAdmin());
        }

    }
}
