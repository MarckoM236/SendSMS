using LM3D.Commons;
using LM3D.Data;
using LM3D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LM3D.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizeAdmin : ContentPage
    {
        public Messages msg;
        public OperationsMessages opr;
        public AuthorizeAdmin()
        {
            InitializeComponent();
            msg = new Messages();
            opr = new OperationsMessages();
        }

        private async void Enviar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var CellPhone = phone.Text;

                var message = new SendMessage
                {
                    Message = (msg.Auth + " " + CellPhone).ToString(),
                    Number = msg.Phone.ToString()
                };


                if (CellPhone.Length >= 10)
                {
                    var result = opr.Send(message);

                    if (result == 1)
                    {
                        await DisplayAlert("Exito", "Se envio comando para autorizar a: " + CellPhone +
                            " Exitosamente", "Aceptar");
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo enviar el mensaje", "Aceptar");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Introduzca un numero Correcto", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        private async void Disavow_Clicked(object sender, EventArgs e)
        {
            try
            {
                var CellPhone = phone.Text;

                var message = new SendMessage
                {
                    Message = (msg.Dis + " " + CellPhone).ToString(),
                    Number = msg.Phone.ToString()
                };


                if (CellPhone.Length >= 10)
                {
                    var result = opr.Send(message);

                    if (result == 1)
                    {
                        await DisplayAlert("Exito", "Se envio comando para desautorizar a: " + CellPhone +
                            " Exitosamente", "Aceptar");
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo enviar el mensaje", "Aceptar");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Introduzca un numero Correcto", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}