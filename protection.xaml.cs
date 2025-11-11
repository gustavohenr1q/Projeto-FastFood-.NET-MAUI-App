using System.Security.Cryptography.X509Certificates;

namespace fastafood2._0;

public partial class Protection : ContentPage
{
	public Protection()
	{
		InitializeComponent();

        string usuario_logado;

        Task.Run(async () =>
        {
            usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
            nameperson.Text = $"Bem Vindo(a),{usuario_logado}!";


        });}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		bool sair = await DisplayAlert("Tem Certeza?", "Deseja Sair do app?", "Sim", "Não");
		if (sair)
		{
			SecureStorage.Default.Remove("usuario_logado");
            App.Current.MainPage = new Login();
        }

		

    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {

        if (IsPickerInvalid(PaoPicker, HamburgPicker, Ing1, Ing2, Ing3))
        {
            await DisplayAlert("Atenção", "Por Favor, Selecione todos os Ingredientes.", "Voltar");

        }
        else
        {
            bool novoPedido = await DisplayAlert("Pedido Realizado!", "Dentro de 30 Minutos Estará Pronto.", "Novo Pedido", "OK");

            if (novoPedido)
            {
               
                PaoPicker.SelectedIndex = -1;
                HamburgPicker.SelectedIndex = -1;
                Ing1.SelectedIndex = -1;
                Ing2.SelectedIndex = -1;
                Ing3.SelectedIndex = -1;
            }
            else
            {
                PaoPicker.SelectedIndex = -1;
                HamburgPicker.SelectedIndex = -1;
                Ing1.SelectedIndex = -1;
                Ing2.SelectedIndex = -1;
                Ing3.SelectedIndex = -1;
            }
        }
    }

    private bool IsPickerInvalid(Picker paoPicker, Picker hamburgPicker, object img1, object img2, object img3) => throw new NotImplementedException();

    private bool IsPickerInvalid(params Picker[] pickers)
    {
        return pickers.Any(p => p.SelectedIndex == -1);
    }


}
