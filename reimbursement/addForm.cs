using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace reimbursement
{
    public partial class addForm : Form
    {
        private SQLiteConnection connection;

        public addForm(SQLiteConnection conn)
        {
            InitializeComponent();
            connection = conn;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            decimal compensation = 0;
            if (Decimal.TryParse(compensationsTextBox.Text, out decimal result))
            {
                compensation = result;
            }
            DateTime date = dateTimePicker.Value;

            try
            {
                connection.Open();
                string insertQuery = @"
                    INSERT INTO Reimbursements (Name, Compensation, Date)
                    VALUES (@Name, @Compensation, @Date);";

                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Compensation", compensation);
                    cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));

                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        MessageBox.Show("Запись успешно добавлена в базу данных.");
                        ClearFields();
                        this.Close(); // Закрыть текущую форму после успешного добааления
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении записи в базу данных.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        private void ClearFields()
        {
            nameTextBox.Text = "";
            compensationsTextBox.Text = "";
            dateTimePicker.Value = DateTime.Now;
        }
    }
}