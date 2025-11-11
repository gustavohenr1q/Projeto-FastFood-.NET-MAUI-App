using System.Globalization;

namespace fastafood2._0;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        bool EntryInvalid = string.IsNullOrWhiteSpace(txt_usuario.Text);

        if (EntryInvalid)
        {
            DisplayAlert("Atenção", "Por Favor, Insira o Nome de Usuário.", "Voltar");
        }
        else
        {


            string usuario_logado;

            Task.Run(async () =>
            {
                usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
                txt_usuario.Text = $"Bem Vindo(a),{usuario_logado}!";


            });

            SecureStorage.Default.SetAsync("usuario_logado", txt_usuario.Text);
            App.Current.MainPage = new Protection();

        }
                
    }

}