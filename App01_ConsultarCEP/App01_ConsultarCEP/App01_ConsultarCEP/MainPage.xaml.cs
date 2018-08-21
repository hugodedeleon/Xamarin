using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //Todo - Lógica do programa.


            //Todo - Validações.
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try //tratamento de Exception
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("{0}, {1} - {2}, {3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("Erro", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }

                } catch(Exception e)
                {
                    DisplayAlert("Erro Crítico", e.Message, "OK");
                }
            }
            
        }
        
        private bool isValidCEP(string cep)
        {
            bool valido = true;
            
            if(cep.Length != 8)
            {
                //Erro
                DisplayAlert("Erro", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }
            
            
            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                //Erro
                DisplayAlert("Erro", "CEP inválido! O CEP deve ser composto apenas por números.", "OK");
                valido = false;
            }
            else
            {
                valido = true;
            }
            
            return valido;
        }
        
    }
}
