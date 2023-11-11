namespace Ejercicio_1._3.Views;

public partial class PagePersonas : ContentPage
{
    public PagePersonas()
    {
        InitializeComponent();
    }

    //private bool actualizar = false;
    private int idPersona = 0;

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (txtnombres.Text != null)
        {
            Title = "Actualizar persona";
            btnSalvar.Text = "Actualizar";
            idPersona = MainPage.personaSeleccionado.id;
        }
    }
    private async void btnSavar_Clicked(object sender, EventArgs e)
    {
        if (validar())
        {

            var persona = new Models.Personas
            {
                nombres = txtnombres.Text,
                apellidos = txtapellidos.Text,
                edad = int.Parse(txtedad.Text),
                correo = txtcorreo.Text,
                direccion = txtdireccion.Text
            };
            if (idPersona == 0)
            {
                if (await App.Instancia.AddPersona(persona) > 0)
                {
                    await DisplayAlert("Aviso", "Persona agregada correctamente", "Ok");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Aviso", "Ocurrio un error", "Ok");
                }
            }
            else
            {
                persona.id = idPersona;
                if (await App.Instancia.UpdatePersona (persona) > 0)
                {
                    await DisplayAlert("Aviso", "Persona actualizada correctamente", "Ok");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Aviso", "Ocurrio un error", "Ok");
                }
            }
        }


        else
        {
            await DisplayAlert("Campos vacios", "Debe proporcionar toda la informacion solicitada", "Ok");
        }
    }

    private bool validar()
    {
        var nombres = txtnombres.Text;
        var apellidos = txtapellidos.Text;
        var edad = txtedad.Text;
        var correo = txtcorreo.Text;
        var direccion = txtdireccion.Text;
        if (nombres != null && apellidos != null && edad != null && correo != null && direccion != null)
        {
            return true;
        }
        return false;
    }
}