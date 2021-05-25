using System;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace ProjectP3.componentes
{

    [System.ComponentModel.DesignerCategory("Code")]

    public class CmpDataCalendario : UserControl
    {

        public CmpDataCalendario()
        {
            InitializeComponent();
        }

        /// Variável de designer necessária.
        private System.ComponentModel.IContainer components = null;

        /// Componentes da Classe
        private MaskedTextBox textBox1;
        private Button button1;
        private DateTime? _Date;
        public DateTime? Date
        {
            //--------------- Importante ---------------//
            //Erro -> Não funciona no VS2019 colocar o GET diretamente em 'public DateTime? Date' da seguinte forma:
            //Causa -> get {return _Date};
            //Solução -> Por isso foi criado "private DateTime? _Date;"
            get { return _Date;}

            set
            {
                if (value == null)
                {
                    textBox1.Text = "";
                }
                else
                {
                    var ano = value.Value.Year.ToString("0000");
                    var mes = value.Value.Month.ToString("00");
                    var dia = value.Value.Day.ToString("00");

                    if (formatoCompetencia && value.Value.Day != 1)
                    {
                        throw new Exception("Competência com dia maior que 1");
                    }

                    textBox1.Text = formatoCompetencia ? mes + ano : dia + mes + ano;
                }

                _Date = value;
            }
        }

        //Propriedades
        public bool formatoCompetencia
        {
            get { if (textBox1.Mask == "00/0000") return true; else return false; }
            set { if (value == true) { textBox1.Mask = "00/0000"; } else textBox1.Mask = "00/00/0000"; }
        }

        public DateTime DataMaxima { get; set; }

        public DateTime DataMinima { get; set; }

        public Color CorFundo
        {
            get { return BackColor; }
            set { BackColor = value; }
        }

        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Clear()
        {
            Date = null;
        }


        //Cria Calendario Dinamicamente
        public void CriarCalendario()
        {
            //Cria um form pop e add o componente de calendario 
            Form frmCal = new Form();
            MonthCalendar Calendario = new MonthCalendar();

            int X = PointToScreen(Point.Empty).X + 1;
            int Y = PointToScreen(Point.Empty).Y + Height;

            frmCal.Location = new Point(X, Y);
            frmCal.StartPosition = FormStartPosition.Manual;
            frmCal.FormBorderStyle = FormBorderStyle.None;
            frmCal.Width = 225;
            frmCal.Height = 160;
            frmCal.Controls.Add(Calendario);


            Calendario.Visible = true;
            Calendario.Location = new Point(-1, -1);
            Calendario.MaxSelectionCount = 1;
            Calendario.ShowTodayCircle = false;
            Calendario.DateSelected += new DateRangeEventHandler(CalendarioSelecionarData);
            Calendario.LostFocus += new System.EventHandler(tdccalendario_LostFocus);
            Calendario.MaxDate = new System.DateTime(9999, 12, 31, 0, 0, 0, 0);
            Calendario.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            Calendario.MaxDate = DataMaxima;
            Calendario.MinDate = DataMinima;
            Calendario.Focus();

            frmCal.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Definido no Designer do componente
            CriarCalendario();

        }

        //Preenche o textBox com a data selecionada de acordo com a formatação escolhida
        private void CalendarioSelecionarData(object sender, DateRangeEventArgs e)
        {
            MonthCalendar calendar = (MonthCalendar)sender;

            if (formatoCompetencia == true)
            {
                textBox1.Text = calendar.SelectionRange.Start.Date.Month.ToString("00") +
                    calendar.SelectionRange.Start.Date.Year.ToString("0000");


                Date = new DateTime(calendar.SelectionRange.Start.Date.Year, calendar.SelectionRange.Start.Date.Month, 1);
            }
            else
            {
                textBox1.Text = calendar.SelectionRange.Start.Date.Day.ToString("00") +
                    calendar.SelectionRange.Start.Date.Month.ToString("00") +
                    calendar.SelectionRange.Start.Date.Year.ToString("0000");

                Date = calendar.SelectionRange.Start.Date;
            }

            button1.FindForm().Controls.Remove(calendar);

            textBox1.Focus();
        }

        private void DataValidacao(object sender, EventArgs e)
        {
            if ((formatoCompetencia == false && textBox1.Text != "  /  /") ||
                (formatoCompetencia == true && textBox1.Text != "  /"))//verifica se o campo é nulo
            {
                try
                {
                    if (formatoCompetencia)
                    {
                        var ano = Convert.ToInt32(textBox1.Text.Substring(3, 4));
                        var mes = Convert.ToInt32(textBox1.Text.Substring(0, 2));
                        var dia = 1;

                        Date = new DateTime(ano, mes, dia);

                        //Coloca a data máxima com o dia=1 para fazer a comparação por competênica
                        DateTime DataMaximaTemp = new DateTime(DataMaxima.Year, DataMaxima.Month, dia);

                        if (DateTime.Compare(Date.Value, DataMaximaTemp) > 0)
                        {
                            Date = null;
                            textBox1.Clear();
                            var msg = string.Format("Maior que data máxima estabelecida({0})!", DataMaximaTemp.ToString("MM/yyyy"));
                            MessageBox.Show("Maior que data máxima estabelecida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Focus();
                        }
                    }
                    else
                    {
                        var ano = Convert.ToInt32(textBox1.Text.Substring(6, 4));
                        var mes = Convert.ToInt32(textBox1.Text.Substring(3, 2));
                        var dia = Convert.ToInt32(textBox1.Text.Substring(0, 2));

                        Date = new DateTime(ano, mes, dia);

                        if (DateTime.Compare(Date.Value, DataMaxima) > 0)
                        {
                            Date = null;
                            textBox1.Clear();                            
                            var msg = string.Format("Maior que data máxima estabelecida({0})!", DataMaxima.ToString("dd/MM/yyyy"));
                            MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Focus();
                        }
                    }


                    if (DateTime.Compare(Date.Value, DataMinima) < 0)
                    {
                        Date = null;
                        textBox1.Clear();
                        var msg = string.Format("Menor que data mínima estabelecida({0})!", DataMinima.ToString("dd/MM/yyyy"));
                        MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Focus();
                    }
                }
                catch
                {
                    textBox1.Clear();
                    Date = null;
                    MessageBox.Show("Data Inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
            }
            else
            {
                Date = null;
            }
        }




        private void tdccalendario_LostFocus(object sender, EventArgs e)
        {
            //Se perder o foco fecha form popup
            (sender as MonthCalendar).FindForm().Close();
        }


        private void InitializeComponent()
        {
            //Declaração
            textBox1 = new System.Windows.Forms.MaskedTextBox();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();

            // 
            // textBox1
            // 
            textBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            textBox1.Location = new System.Drawing.Point(1, 1);
            textBox1.Name = "dataTxt";
            formatoCompetencia = false;
            textBox1.Size = new System.Drawing.Size(100, 20);
            textBox1.TabIndex = 0;
            textBox1.ValidatingType = typeof(System.DateTime);
            textBox1.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(DataValidacao);
            // 
            // button1
            // 
            button1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            button1.BackColor = System.Drawing.Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Image = global::ProjectP3.Properties.Resources.calendar;
            button1.Location = new System.Drawing.Point(80, 2);
            button1.Name = "calendarioButton";
            button1.Size = new System.Drawing.Size(20, 18);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(button1_Click);
            // 
            // CmpDataCalendario
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "cmpDataCalendario";
            Size = new System.Drawing.Size(101, 21);
            ResumeLayout(false);
            PerformLayout();

        }

    }
}
