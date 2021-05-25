using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectP3.Others
{
    public static class Extensions
    {
        public static void DropDownWidth(this ComboBox combo)
        {
            var maxWidth = 0;
            int temp;
            var label1 = new Label();

            foreach (var obj in combo.Items)
            {
                label1.Text = obj.ToString();
                temp = label1.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            label1.Dispose();
            combo.DropDownWidth = maxWidth;
        }

        public static void SelectIndex(this ComboBox combo, string retorno)
        {

            if (string.IsNullOrWhiteSpace(retorno))
            {
                combo.SelectedIndex = -1;
                return;
            }

            var items = combo.Items.OfType<string>().ToList();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].StartsWith(retorno))
                {
                    combo.SelectedIndex = i;
                }
            }
        }

        //-----------------------Grid---------------------------------//    


        /// <summary>
        /// Adiciona uma coluna ao DataGridView
        /// </summary>
        /// <param name="dataGrid">DataGridView</param>
        /// <param name="DataPropertyName">Nome da Coluna</param>
        /// <param name="HeaderText">Título da Coluna</param>
        /// <param name="autoSize">Largura de autopreenchimento</param>
        /// <param name="Mask">Máscara de exibição</param>
        public static void BuilderColumn(this DataGridView dataGrid, string DataPropertyName, string HeaderText, DataGridViewAutoSizeColumnMode autoSize, string Mask = null)
        {
            var column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = DataPropertyName,
                HeaderText = HeaderText,
                ReadOnly = true,
                Name = DataPropertyName,
                AutoSizeMode = autoSize
            };

            column.DefaultCellStyle.Format = Mask;

            dataGrid.Columns.Add(column);
        }


        /// <summary>
        /// Adiciona uma coluna ao DataGridView
        /// </summary>
        /// <param name="dataGrid">DataGridView</param>
        /// <param name="DataPropertyName">Nome da Coluna</param>
        /// <param name="HeaderText">Título da Coluna</param>
        /// <param name="Width">Largura da Coluna</param>
        /// <param name="Mask">Máscara de exibição</param>
        public static void BuilderColumn(this DataGridView dataGrid, string DataPropertyName, string HeaderText, int Width = 100, string Mask = null)
        {
            var column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = DataPropertyName,
                HeaderText = HeaderText,
                ReadOnly = true,
                Name = DataPropertyName,
                Width = Width
            };

            column.DefaultCellStyle.Format = Mask;

            dataGrid.Columns.Add(column);
        }

        /// <summary>
        /// Adiciona uma row ao DataGridView
        /// </summary>
        /// <param name="dataGrid">DataGridView</param>
        /// <param name="args">Campos para serem adicionados</param>
        public static void DataGridAdd(this DataGridView dataGrid, params string[] args)
        {
            dataGrid.Rows.Add(1);

            for (int i = 0; i < args.Length; i++)
            {
                dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[i].Value = args[i];
            }
        }

        /// <summary>
        /// Delete a Row Selecionada ao DataGridView
        /// </summary>
        /// <param name="dataGrid">DataGridView</param>
        public static void DataGridDelete(this DataGridView dataGrid)
        {
            //Apaga linha selecionada do dataGridRotas
            if (dataGrid.Rows.Count != 0 && dataGrid.CurrentRow.Index >= 0)
            {
                dataGrid.Rows.RemoveAt(dataGrid.CurrentRow.Index);
            }
        }


        /// <summary>
        /// Adiciona uma coluna Invisível ao DataGridView
        /// </summary>
        /// <param name="dataGrid">DataGridView</param>
        /// <param name="DataPropertyName">Nome da Coluna</param>

        public static void BuilderColumn(this DataGridView dataGrid, string DataPropertyName)
        {
            var column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = DataPropertyName,
                ReadOnly = true,
                Name = DataPropertyName,
                Visible = false
            };

            dataGrid.Columns.Add(column);
        }



        /// <summary>
        /// Carrega um List<T> no DataGridView.
        /// </summary>
        /// <typeparam name="T">Classe Model T</typeparam>
        /// <param name="dataGrid">DataGridView</param>
        /// <param name="List">Lista de Models T</param>
        public static void LoadFromList<T>(this DataGridView dataGrid, List<T> List)
        {
            //Esse método Limpa o DataGridView, Adiciona uma linha no DataGridView para cada 
            //linha do List e preenche as colunas que tenham o mesmo nome da propriedade da classe T

            dataGrid.Rows.Clear();
            dataGrid.Refresh();

            //Para caada linha do List
            for (int i = 0; i < List.Count; i++)
            {
                //Cria uma linha no Grid
                dataGrid.Rows.Add(1);

                //Para cada propriedade do Objeto no List
                foreach (PropertyInfo Propriedade in typeof(T).GetProperties())
                {
                    //Para cada Coluna no Grid
                    foreach (DataGridViewColumn Coluna in dataGrid.Columns)
                    {
                        //Se o nome da coluna for igual ao da propriedade do Objeto do List
                        if (Propriedade.Name.ToUpper() == Coluna.Name.ToUpper())
                        {
                            dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[Coluna.Name].Value =
                                List[i].GetType().GetProperty(Propriedade.Name).GetValue(List[i], null);
                        }
                    }
                }
            }
        }


    }
}
