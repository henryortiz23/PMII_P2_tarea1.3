using Ejercicio_1._3.Models;
using Ejercicio_1._3.Views;

namespace Ejercicio_1._3;

public partial class MainPage : ContentPage
{

    public static Personas personaSeleccionado = null;

    public MainPage()
	{
		InitializeComponent();
        
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        list.ItemsSource = await App.Instancia.ListPersonas();
        
        
    }
    private void OnCounterClicked(object sender, EventArgs e)
	{
		
	}

    private async void btnInsertar_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Views.PagePersonas());
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        var PagePersona = new PagePersonas();
        PagePersona.BindingContext = personaSeleccionado;

        await Navigation.PushAsync(PagePersona);
        btnActualizar.IsEnabled = false;
        btnEliminar.IsEnabled = false;
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        bool res = await DisplayAlert("Confirmar", "¿Desea eliminar la persona seleccionada?", "Sí", "No");

        if (res)
        {
            if (await App.Instancia.DeletePersona(personaSeleccionado) > 0)
            {
                await DisplayAlert("Aviso", "Persona eliminada correctamente", "Ok");
                list.ItemsSource = await App.Instancia.ListPersonas();
                btnActualizar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
            }
        }
    }

    private async void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Personas selectedPersona)
        {
            if (selectedPersona != null)
            {
                personaSeleccionado = selectedPersona;
                if (personaSeleccionado != null)
                {
                    btnActualizar.IsEnabled = true;
                    btnEliminar.IsEnabled = true;
                }
            }
            else
            {
                btnActualizar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
            }
        }
    }
}

