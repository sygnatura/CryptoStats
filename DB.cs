using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CryptoStats
{
    class DB
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"" + System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\cryptostats.accdb\";User Id=;Password=;";

        public void UpdateDB(List<Waluta> waluty)
        {
            string queryString =
            "INSERT INTO dane ([name],[rank],[price_usd],[price_btc],[volume],[percent_change_1h],[percent_change_24h],[percent_change_7d],[last_updated],[symbol],[available_supply]) "
              + "VALUES (@name,@rank,@price_usd,@price_btc,@volume,@percent_change_1h,@percent_change_24h,@percent_change_7d,@last_updated,@symbol,@available_supply);";

            foreach (var item in waluty)
            {
                if (item.name != null)
                {
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        try
                        {
                            if (item.rank == null) item.rank = "0";
                            if (item.price_usd == null) item.price_usd = "0";
                            if (item.price_btc == null) item.price_btc = "0";
                            if (item.volume == null) item.volume = "0";
                            if (item.percent_change_1h == null) item.percent_change_1h = "0";
                            if (item.percent_change_24h == null) item.percent_change_24h = "0";
                            if (item.percent_change_7d == null) item.percent_change_7d = "0";

                            OleDbCommand command = new OleDbCommand(queryString, connection);
                            command.Parameters.AddWithValue("@name", item.name);
                            command.Parameters.AddWithValue("@rank", item.rank);
                            command.Parameters.AddWithValue("@price_usd", item.price_usd.Replace(".",","));
                            command.Parameters.AddWithValue("@price_btc", item.price_btc.Replace(".", ","));
                            command.Parameters.AddWithValue("@volume", item.volume.Replace(".", ","));
                            command.Parameters.AddWithValue("@percent_change_1h", item.percent_change_1h.Replace(".", ","));
                            command.Parameters.AddWithValue("@percent_change_24h", item.percent_change_1h.Replace(".", ","));
                            command.Parameters.AddWithValue("@percent_change_7d", item.percent_change_7d.Replace(".", ","));
                            command.Parameters.AddWithValue("@last_updated", item.last_updated.ToString());
                            command.Parameters.AddWithValue("@symbol", item.symbol.ToString().ToLower());
                            command.Parameters.AddWithValue("@available_supply", item.available_supply.Replace(".", ","));

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            System.Console.WriteLine(ex.Message + ": " + item.price_usd);
                        }
                    }
                }
                else System.Console.WriteLine("Nieprawidłowe dane wejściowe do bazy danych");
            }
        }

        public void AddMonitorRule(Monitor rule)
        {
            string queryString =
            "INSERT INTO monitor ([name],[monitor_index],[rule_index],[value]) "
              + "VALUES (@name,@monitor_index,@rule_index,@value);";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    command.Parameters.AddWithValue("@name", rule.name);
                    command.Parameters.AddWithValue("@monitor_index", rule.monitor_index);
                    command.Parameters.AddWithValue("@rule_index", rule.rule_index);
                    command.Parameters.AddWithValue("@value", rule.value.ToString());

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message + ": " + rule.name);
                }
            }
        }

        public List<Monitor> GetRules()
        {
            List<Monitor> lista = new List<Monitor>();
            string queryString = "SELECT * FROM monitor ORDER BY id;";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                OleDbCommand command = new OleDbCommand(queryString, connection);

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string nazwa = Convert.ToString(reader[0]);
                        //jezeli waluta nie istnieje na liscie to ja dodaj
                        Monitor item = new Monitor();
                        item.id = Convert.ToUInt32(reader[0]);
                        item.name = Convert.ToString(reader[1]);
                        item.monitor_index = Convert.ToByte(reader[2]);
                        item.rule_index = Convert.ToByte(reader[3]);
                        item.value = Convert.ToDecimal(reader[4]);

                        lista.Add(item);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            return lista;
        }

        public void DeleteMonitorID(long id)
        {
            string queryString = "DELETE FROM monitor WHERE id=" + id + ";";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        public List<Waluta> GetFromTime(long time, bool from_start)
        {
            //System.Console.WriteLine("Time: " + time);
            List<Waluta> lista = new List<Waluta>();
            string queryString = null;
            if (from_start) queryString = "SELECT * FROM dane WHERE last_updated >= @input_time ORDER BY name, last_updated;";
            else queryString = "SELECT * FROM dane WHERE last_updated <= @input_time ORDER BY name, last_updated DESC;";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                OleDbCommand command = new OleDbCommand(queryString, connection);
                command.Parameters.AddWithValue("@input_time", time.ToString());

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string nazwa = Convert.ToString(reader[0]);
                        //jezeli waluta nie istnieje na liscie to ja dodaj
                        if(!CzyIstnieje(lista, nazwa))
                        {
                            Waluta item = new Waluta();
                            item.name = nazwa;
                            item.rank = Convert.ToString(reader[1]);
                            item.price_usd = Convert.ToString(Convert.ToDecimal(reader[2]));
                            item.price_btc = Convert.ToString(Convert.ToDecimal(reader[3]));
                            item.volume = Convert.ToString(reader[4]);
                            item.percent_change_1h = Convert.ToString(Math.Round(Convert.ToDouble(reader[5]), 2));
                            item.percent_change_24h = Convert.ToString(Math.Round(Convert.ToDouble(reader[6]), 2));
                            item.percent_change_7d = Convert.ToString(Math.Round(Convert.ToDouble(reader[7]), 2));
                            item.last_updated = Convert.ToInt64(reader[8]);
                            item.symbol = Convert.ToString(reader[9]);
                            item.available_supply = Convert.ToString(Math.Round(Convert.ToDouble(reader[10]), 2));

                            lista.Add(item);
                        }
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            return lista;
        }

        public List<string> GetNames()
        {
            List<string> lista = new List<string>();
            string queryString = "SELECT name FROM dane GROUP BY name ORDER BY name";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                OleDbCommand command = new OleDbCommand(queryString, connection);
                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(Convert.ToString(reader[0]));
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            return lista;
        }


        // szuka czy waluta o podanej nazwie znajduje sie na liscie
        private bool CzyIstnieje(List<Waluta> lista, string nazwa)
        {
            foreach (var item in lista)
            {
                if (item.name.Equals(nazwa)) return true;
            }
            return false;
        }

    }
}
