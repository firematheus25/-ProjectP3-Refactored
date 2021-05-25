using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectP3.Componentes
{
    [System.ComponentModel.DesignerCategory("Code")]
    class CpmNumericwithoutmask : TextBox
    {
        private decimal? _Valor;
        private int _CasasDecimais = 2;
        private decimal _ValorMaximo = 999999999;
        private bool foco = false;
        private bool cod = false;

        [Browsable(false)]
        public decimal? Valor
        {
            get { return _Valor; }
            set
            {
                this._Valor = value;

                //Executa apenas quando o usuário digitar virgula
                if (!cod)
                {
                    this.Text = Convert.ToString(value);
                }
            }
        }

        [Browsable(false)]
        public int? ValorInteiro
        {
            get
            {
                if ((_Valor > 2147483647) || (_CasasDecimais != 0))
                {
                    throw new FormatException();
                }
                return (int)_Valor;
            }
        }

        public int CasasDecimais
        {
            get { return _CasasDecimais; }
            set
            {
                this._CasasDecimais = value;
            }
        }

        public decimal ValorMaximo
        {
            get { return _ValorMaximo; }
            set { this._ValorMaximo = value; }
        }

        public CpmNumericwithoutmask()
        {
            this.TextAlign = HorizontalAlignment.Right;
            this.Enter += new EventHandler(TextNumericEnter);
            this.KeyPress += new KeyPressEventHandler(TextNumericKeyPress);
            this.Leave += new EventHandler(TextNumericLeave);
            this.TextChanged += new EventHandler(TextNumericChange);
        }

        //Executado ao entrar no campo de texto
        private void TextNumericEnter(object sender, EventArgs e)
        {
            this.foco = true;

            if (this.Valor != null)
            {
                this.Text = this.Valor.Value.ToString();
            }
        }

        //Executado na digitação
        private void TextNumericKeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada não é CTRL ou um digito não númerico
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Permite a digitação de somente uma virgula ou nenhuma se o campo for inteiro
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1) || ((e.KeyChar == ',') && _CasasDecimais == 0))
            {
                e.Handled = true;
            }
        }

        //Executado após alteração de texto no campo
        private void TextNumericChange(object sender, EventArgs e)
        {
            //Só faz validação se o campo estiver com foco
            if (this.foco == true)
            {
                string formatado;

                try
                {
                    //Retira espaços em branco;
                    this.Text = Text.Trim();

                    //Verifica se há caracteres invalidos
                    foreach (char numero in this.Text)
                    {
                        if ((numero < '0' || numero > '9') && !numero.Equals(','))
                        {
                            throw new FormatException();
                        }
                    }

                    //Verifica se numero é inteiro e tem virgulas
                    if (this.Text.IndexOf(",") != -1 && _CasasDecimais == 0)
                    {
                        throw new FormatException();
                    }

                    //Faz validação das virgulas
                    if (ValidarVirgulas(this.Text) == false)
                    {
                        throw new FormatException();
                    }

                    //Seta o valor da propriedade Valor do componente
                    try
                    {
                        cod = true;
                        this.Valor = decimal.Parse(this.Text);
                    }
                    catch
                    {
                        this.Valor = null;
                    }
                    finally
                    {
                        cod = false;
                    }

                    //Faz validação das casas decimais após a virgula
                    formatado = FormatarCasasDecimais(this.Text, _CasasDecimais);
                    if (this.Text != formatado)
                    {
                        this.Text = formatado;
                        this.SelectionStart = this.Text.Length;
                    }
                }
                catch
                {
                    this.Clear();
                }
            }
        }

        //Executado ao tirar o foco do campo
        private void TextNumericLeave(object sender, EventArgs e)
        {
            //Se der erro na conversão, o componente fica com foco.
            try
            {
                if (this.Text != "")
                {
                    this.Valor = decimal.Parse(this.Text);
                }
                else
                {
                    this.Valor = null;
                }

                //Ao sair do campo, coloca mascara
                this.foco = false;
                //Mascarar();
            }
            catch
            {
                if (this.Valor != null)
                {
                    this.Clear();
                    this.Focus();
                }
            }

            //Se o valor for maior que o limite, exibe mensagem e fica em foco
            try
            {
                if (this.Valor > _ValorMaximo)
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Valor maior que o permitido", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.Focus();
            }
        }


        //Faz a formatação das casas decimais após a virgula
        private string FormatarCasasDecimais(string texto, int qtdCasasDecimais)
        {
            int indiceVirgula = this.Text.IndexOf(',');
            int tamanhoNumero = this.Text.Length;

            //Remove a partir do 3º número após a virgula
            if (indiceVirgula != -1 && tamanhoNumero - (indiceVirgula + 1) > qtdCasasDecimais)
            {
                texto = texto.Remove(indiceVirgula + (qtdCasasDecimais + 1), (tamanhoNumero - (indiceVirgula + (qtdCasasDecimais + 1))));
                return texto;
            }

            return texto;
        }

        //Faz a validação da quantidade de vírgulas
        private bool ValidarVirgulas(string texto)
        {
            int virgulas = 0;

            foreach (char numero in texto)
            {
                if (numero.Equals(','))
                {
                    virgulas++;
                }
            }

            return virgulas > 1 ? false : true;
        }

        public new void Clear()
        {
            Valor = null;
        }
    }
}
