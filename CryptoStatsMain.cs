using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CryptoStats
{
    public partial class CryptoStatsMain : Form
    {
        private DownloadStats downloadStats;
        private DB access_db;
        private int time_diff = 0;
        private int sortColumn = -1;
        private List<Monitor> lista_regul = null;
        private ImageList ikony;

        private string mail_to;
        private string mail_from;
        private string username;
        private string password;
        private string smtpclient;

        public CryptoStatsMain()
        {
            InitializeComponent();
            loadIcons();
            access_db = new DB();
            refreshMonitorCryptoName();
            refreshMonitorList();
            timeRangeBox.SelectedIndex = 0;
            downloadStats = new DownloadStats(access_db);
            downloadStats.Download();
            refreshList();

            mail_to = ReadSetting("mail_to");
            mail_from = ReadSetting("mail_from");
            username = ReadSetting("username");
            password = ReadSetting("password");
            smtpclient = ReadSetting("smtpclient");
        }

        private void loadIcons()
        {
            ikony = new ImageList();
            ikony.ImageSize = new Size(32, 32);
            String[] paths = { };
            paths = Directory.GetFiles(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\icons\\");

            try
            {
                foreach(String path in paths)
                {
                    ikony.Images.Add(Path.GetFileNameWithoutExtension(path), Image.FromFile(path));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            cryptoListView.SmallImageList = ikony;
        }

        private void downloadTime_Tick(object sender, EventArgs e)
        {
            downloadStats.Download();
            refreshList();
        }

        private void timeRangeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(timeRangeBox.SelectedIndex)
            {
                // 5 minut
                case 0:
                    time_diff = -10;
                    break;
                // 10 minut
                case 1:
                    time_diff = -15;
                    break;
                // 30 minut
                case 2:
                    time_diff = -30;
                    break;
                // 1 godzina
                case 3:
                    time_diff = -60;
                    break;
                // 24 godziny
                case 4:
                    time_diff = -1440;
                    break;
                // 7 dni
                case 5:
                    time_diff = -10080;
                    break;
            }
            refreshList();
        }

        private void cryptoListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            cryptoListView.ListViewItemSorter = new ListViewItemComparer(e.Column);
            cryptoListView.Sort();

            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                cryptoListView.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (cryptoListView.Sorting == SortOrder.Ascending)
                    cryptoListView.Sorting = SortOrder.Descending;
                else
                    cryptoListView.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            cryptoListView.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.cryptoListView.ListViewItemSorter = new ListViewItemComparer(e.Column, cryptoListView.Sorting);
        }

        private void refreshMonitorCryptoName()
        {
            walutyLista.Items.Clear();
            walutyLista.Items.Add("*Dowolna*");
            List<string> nazwy = access_db.GetNames();
            // dodaj walute do listy z powiadomieniami
            foreach (var item in nazwy)
            {
                walutyLista.Items.Add(item.ToString());
            }
        }

        private void refreshMonitorList()
        {
            rulesList.Items.Clear();

            lista_regul = access_db.GetRules();
            foreach (var item in lista_regul)
            {
                ListViewItem lista = new ListViewItem(item.id.ToString());
                lista.SubItems.Add(item.name);
                switch(item.monitor_index)
                {
                    case 0:
                        lista.SubItems.Add("Cena USD");
                        break;
                    case 1:
                        lista.SubItems.Add("Cena BTC");
                        break;
                    case 2:
                        lista.SubItems.Add("Wolumen");
                        break;
                    case 3:
                        lista.SubItems.Add("Zmiana ceny 1h");
                        break;
                    case 4:
                        lista.SubItems.Add("Zmiana ceny 24h");
                        break;
                    case 5:
                        lista.SubItems.Add("Zmiana ceny 7d");
                        break;
                    case 6:
                        lista.SubItems.Add("Zmiana wolumenu");
                        break;


                }
                switch (item.rule_index)
                {
                    case 0:
                        lista.SubItems.Add("<=");
                        break;
                    case 1:
                        lista.SubItems.Add(">=");
                        break;
                }

                lista.SubItems.Add(item.value.ToString());

                rulesList.Items.Add(lista);
            }
          
        }

        private void checkRule(Waluta waluta)
        {
            foreach (var item in lista_regul)
            {
                // jezeli to regula dla tej waluty
                if(item.name.Equals("*Dowolna*") || item.name.Equals(waluta.name))
                {
                    string message = null;
                    bool mniejsza = item.rule_index == 0 ? true : false;
                    switch (item.monitor_index)
                    {
                        //Cena USD
                        case 0:
                            if (mniejsza)
                            {
                                if (waluta.Get_price_usd() <= item.value) message = "Cena USD waluty " + waluta.name + " jest <= " + item.value + " i wynosi " + waluta.Get_price_usd();
                            }
                            else
                            {
                                if (waluta.Get_price_usd() >= item.value) message = "Cena USD waluty " + waluta.name + " jest >= " + item.value + " i wynosi " + waluta.Get_price_usd();
                            }
                            break;
                        //Cena BTC
                        case 1:
                            if (mniejsza)
                            {
                                if (waluta.Get_price_btc() <= item.value) message = "Cena BTC waluty " + waluta.name + " jest <= " + item.value + " i wynosi " + waluta.Get_price_btc();
                            }
                            else
                            {
                                if (waluta.Get_price_btc() >= item.value) message = "Cena BTC waluty " + waluta.name + " jest >= " + item.value + " i wynosi " + waluta.Get_price_btc();
                            }
                            break;
                        //Wolumen
                        case 2:
                            if (mniejsza)
                            {
                                if (waluta.Get_volume() <= item.value) message = "Wolumen waluty " + waluta.name + " jest <= " + item.value + " i wynosi " + waluta.volume;
                            }
                            else
                            {
                                if (waluta.Get_volume() >= item.value) message = "Wolumen waluty " + waluta.name + " jest >= " + item.value + " i wynosi " + waluta.volume;
                            }
                            break;
                        // cena 1h
                        case 3:
                            if (mniejsza)
                            {
                                if (waluta.Get_percent_change_1h() <= Convert.ToDouble(item.value)) message = "Cena 1h waluty " + waluta.name + " jest <= " + item.value + " i wynosi " + waluta.Get_percent_change_1h();
                            }
                            else
                            {
                                if (waluta.Get_percent_change_1h() >= Convert.ToDouble(item.value)) message = "Cena 1h waluty " + waluta.name + " jest >= " + item.value + " i wynosi " + waluta.Get_percent_change_1h();
                            }
                            break;
                        // cena 24h
                        case 4:
                            if (mniejsza)
                            {
                                if (waluta.Get_percent_change_24h() <= Convert.ToDouble(item.value)) message = "Cena 24h waluty " + waluta.name + " jest <= " + item.value + " i wynosi " + waluta.Get_percent_change_24h();
                            }
                            else
                            {
                                if (waluta.Get_percent_change_24h() >= Convert.ToDouble(item.value)) message = "Cena 24h waluty " + waluta.name + " jest >= " + item.value + " i wynosi " + waluta.Get_percent_change_24h();
                            }
                            break;
                        // cena 7d
                        case 5:
                            if (mniejsza)
                            {
                                if (waluta.Get_percent_change_7d() <= Convert.ToDouble(item.value)) message = "Cena 7d waluty " + waluta.name + " jest <= " + item.value + " i wynosi " + waluta.Get_percent_change_7d();
                            }
                            else
                            {
                                if (waluta.Get_percent_change_7d() >= Convert.ToDouble(item.value)) message = "Cena 7d waluty " + waluta.name + " jest >= " + item.value + " i wynosi " + waluta.Get_percent_change_7d();
                            }
                            break;
                        // zmiana wolumenu
                        case 6:
                            if (mniejsza)
                            {
                                if (waluta.percent_volume <= Convert.ToDouble(item.value)) message = "Zmiana % wolumenu waluty " + waluta.name + " jest <= " + item.value + " i wynosi " + waluta.percent_volume;
                            }
                            else
                            {
                                if (waluta.percent_volume >= Convert.ToDouble(item.value)) message = "Zmiana % wolumenu waluty " + waluta.name + " jest >= " + item.value + " i wynosi " + waluta.percent_volume;
                            }
                            break;
                    }
                    if(message != null)
                    {
                        System.Console.WriteLine(message);
                        sendMail(message);
                        access_db.DeleteMonitorID(item.id);
                        refreshMonitorList();
                    }

                }
            }
        }


        // odswiezanie listy
        private void refreshList()
        {
            cryptoListView.Items.Clear();

            DateTimeOffset dto = new DateTimeOffset(DateTime.Now.AddMinutes(time_diff));
            List<Waluta> oldList = access_db.GetFromTime(dto.ToUnixTimeSeconds(), true);
            dto = new DateTimeOffset(DateTime.Now);
            List <Waluta> latestList = access_db.GetFromTime(dto.ToUnixTimeSeconds(), false);

            Waluta BCH = null;
            // szukanie Bitcoin Cash do porownania
            foreach(var item in latestList)
            {
                if(item.name.Equals("Bitcoin Cash"))
                {
                    BCH = item;
                    break;
                }
            }

            // obliczenie roznicy na wolumenie, trendu oraz pompy
            if (latestList != null && oldList != null)
            {
                for (int i = 0; i < latestList.Count; i++)
                {
                    Waluta itemActual = latestList[i];
                    if (BCH != null) itemActual.CalculateBalans(BCH);

                    foreach (var itemOld in oldList)
                    {
                        if (itemOld.name.Equals(itemActual.name))
                        {
                            itemActual.CalculateDiff(itemOld);
                            break;
                        }
                    }
                    // sprawdzanie czy sa zdefiniowane reguly do monitorowania jezeli tak to sprawdza dla danej waluty
                    if (lista_regul != null) checkRule(itemActual);

                    ListViewItem lista = new ListViewItem(itemActual.name);
                    lista.UseItemStyleForSubItems = false;
                    lista.SubItems.Add(itemActual.price_usd.ToString());
                    lista.SubItems.Add(itemActual.price_btc.ToString());
                    lista.SubItems.Add(itemActual.volume.ToString());

                    if (itemActual.Get_percent_change_1h() > 0.0) lista.SubItems.Add(itemActual.percent_change_1h + " %", Color.Green, Color.White, null);
                    else if (itemActual.Get_percent_change_1h() < 0.0) lista.SubItems.Add(itemActual.percent_change_1h + " %", Color.Red, Color.White, null);
                    else lista.SubItems.Add(itemActual.percent_change_1h + " %", Color.Blue, Color.White, null);

                    if (itemActual.Get_percent_change_24h() > 0.0) lista.SubItems.Add(itemActual.percent_change_24h + " %", Color.Green, Color.White, null);
                    else if (itemActual.Get_percent_change_24h() < 0.0) lista.SubItems.Add(itemActual.percent_change_24h + " %", Color.Red, Color.White, null);
                    else lista.SubItems.Add(itemActual.percent_change_24h + " %", Color.Blue, Color.White, null);

                    if (itemActual.Get_percent_change_7d() > 0.0) lista.SubItems.Add(itemActual.percent_change_7d + " %", Color.Green, Color.White, null);
                    else if (itemActual.Get_percent_change_7d() < 0.0) lista.SubItems.Add(itemActual.percent_change_7d + " %", Color.Red, Color.White, null);
                    else lista.SubItems.Add(itemActual.percent_change_7d + " %", Color.Blue, Color.White, null);

                    if (itemActual.percent_volume > 0.0) lista.SubItems.Add(itemActual.percent_volume + " %", Color.Green, Color.White, null);
                    else if (itemActual.percent_volume < 0.0) lista.SubItems.Add(itemActual.percent_volume + " %", Color.Red, Color.White, null);
                    else lista.SubItems.Add(itemActual.percent_volume + " %", Color.Blue, Color.White, null);

                    if (itemActual.trend > 0.0) lista.SubItems.Add(itemActual.trend.ToString(), Color.Green, Color.White, null);
                    else if (itemActual.trend < 0.0) lista.SubItems.Add(itemActual.trend.ToString(), Color.Red, Color.White, null);
                    else lista.SubItems.Add(itemActual.trend.ToString(), Color.Blue, Color.White, null);

                    if (itemActual.pompa > 0.0) lista.SubItems.Add(itemActual.pompa.ToString(), Color.Green, Color.White, null);
                    else if (itemActual.pompa < 0.0) lista.SubItems.Add(itemActual.pompa.ToString(), Color.Red, Color.White, null);
                    else lista.SubItems.Add(itemActual.pompa.ToString(), Color.Blue, Color.White, null);

                    if (itemActual.rank_diff > 0) lista.SubItems.Add(itemActual.rank_diff.ToString(), Color.Green, Color.White, null);
                    else if (itemActual.rank_diff < 0) lista.SubItems.Add(itemActual.rank_diff.ToString(), Color.Red, Color.White, null);
                    else lista.SubItems.Add(itemActual.rank_diff.ToString(), Color.Blue, Color.White, null);

                    if (itemActual.balans > 0) lista.SubItems.Add(itemActual.balans.ToString(), Color.Green, Color.White, null);
                    else if (itemActual.balans < 0) lista.SubItems.Add(itemActual.balans.ToString(), Color.Red, Color.White, null);
                    else lista.SubItems.Add(itemActual.balans.ToString(), Color.Blue, Color.White, null);


                    lista.ImageKey = itemActual.symbol;
                    cryptoListView.Items.Add(lista);
                }
            }
            cryptoListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            cryptoListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void refreshTime_Tick(object sender, EventArgs e)
        {
            refreshList();
        }

        private void dodajButton_Click(object sender, EventArgs e)
        {
            Monitor monitor = new Monitor();
            monitor.name = walutyLista.Items[walutyLista.SelectedIndex].ToString();
            monitor.monitor_index = (byte) monitorLista.SelectedIndex;
            monitor.rule_index = (byte) warunekLista.SelectedIndex;
            monitor.value = Decimal.Parse(wartoscBox.Text.ToString().Replace(".",","));

            access_db.AddMonitorRule(monitor);

            refreshMonitorList();
        }

        private void usunButton_Click(object sender, EventArgs e)
        {
            if(rulesList.SelectedItems.Count > 0)
            {
                long id = Convert.ToInt32(rulesList.SelectedItems[0].Text);
                access_db.DeleteMonitorID(id);
                refreshMonitorList();
            }
        }

        private void sendMail(string tresc)
        {
            if(mail_from != null && mail_to != null && smtpclient != null && username != null && password != null)
            {
                MailMessage message = new MailMessage(mail_from, mail_to);
                message.Subject = "Powiadomienie CryptoStats";
                message.Body = tresc;
                SmtpClient client = new SmtpClient(smtpclient);
                // Credentials are necessary if the server requires the client 
                // to authenticate before it will send e-mail on the client's behalf.
                client.UseDefaultCredentials = false;
                NetworkCredential basicCredential = new NetworkCredential(username, password);
                client.Credentials = basicCredential;

                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                                ex.ToString());
                }
            }
        }

        private void cryptoListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string currency = cryptoListView.SelectedItems[0].Text.ToLower().Replace(" ","-");
            Process.Start("https://coinmarketcap.com/currencies/"+ currency);
        }

        private string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? null;
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
                return null;
            }
        }
    }
}
