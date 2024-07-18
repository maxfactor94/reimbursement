using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace reimbursement
{
    public partial class Изменить : Form
    {
        private int id;
        private SQLiteConnection connection;

        public Изменить(int id, string name, decimal compensation, DateTime date, SQLiteConnection conn)
        {
            InitializeComponent();

            this.id = id;
            connection = conn;

            // Заполнение элементов управления данными текущей строки
            nameTextBox.Text = name;
            compensationsTextBox.Text = compensation.ToString();
            dateTimePicker.Value = date;
        }

        private void EditBtn_Click(object sender, EventArgs e)
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
                string updateQuery = @"
                    UPDATE Reimbursements
                    SET Name = @Name,
                        Compensation = @Compensation,
                        Date = @Date
                    WHERE Id = @Id;";

                using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Compensation", compensation);
                    cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Id", id);

                    int rowsUpdated = cmd.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        MessageBox.Show("Данные успешно обновлены в базе данных.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при обновлении данных в базе данных.");
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
    }
}