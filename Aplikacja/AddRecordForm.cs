using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Aplikacja
{
    public partial class AddRecordForm : Form
    {
        private OracleConnection connection;
        private string selectedTable;
        private TextBox[] textBoxes;

        public AddRecordForm(OracleConnection connection, string selectedTable)
        {
            InitializeComponent();
            this.connection = connection;
            this.selectedTable = selectedTable;

            OracleCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT column_name FROM user_tab_columns WHERE table_name = '{selectedTable}'";
            OracleDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            textBoxes = new TextBox[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Label label = new Label();
                label.Text = dataTable.Rows[i][0].ToString();
                label.Location = new System.Drawing.Point(10, 10 + i * 30);
                label.AutoSize = true;
                this.Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Location = new System.Drawing.Point(150, 10 + i * 30);
                this.Controls.Add(textBox);
                textBoxes[i] = textBox;
            }

            Button insertButton = new Button();
            insertButton.Text = "DODAJ";
            insertButton.Location = new System.Drawing.Point(10, 20 + dataTable.Rows.Count * 30);
            insertButton.Click += InsertButton_Click;
            this.Controls.Add(insertButton);
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] values = new string[textBoxes.Length];
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    values[i] = $"'{textBoxes[i].Text}'";
                }
                string valuesStr = string.Join(", ", values);

                OracleCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO {selectedTable} VALUES ({valuesStr})";
                command.ExecuteNonQuery();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
