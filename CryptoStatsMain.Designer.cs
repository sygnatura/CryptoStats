namespace CryptoStats
{
    partial class CryptoStatsMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CryptoStatsMain));
            this.downloadTime = new System.Windows.Forms.Timer(this.components);
            this.refreshTime = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.timeRangeBox = new System.Windows.Forms.ComboBox();
            this.cryptoListView = new System.Windows.Forms.ListView();
            this.Nazwa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CenaUSD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CenaBTC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Wolumen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Zmiana1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Zmiana2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Zmiana3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ZmianaWolumen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Trend = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pompa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ranking = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rulesList = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cryptoName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.monitorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ruleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usunButton = new System.Windows.Forms.Button();
            this.dodajButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.wartoscBox = new System.Windows.Forms.TextBox();
            this.warunekLista = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.monitorLista = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.walutyLista = new System.Windows.Forms.ComboBox();
            this.Balans = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // downloadTime
            // 
            this.downloadTime.Enabled = true;
            this.downloadTime.Interval = 150000;
            this.downloadTime.Tick += new System.EventHandler(this.downloadTime_Tick);
            // 
            // refreshTime
            // 
            this.refreshTime.Interval = 60000;
            this.refreshTime.Tick += new System.EventHandler(this.refreshTime_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1669, 841);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.timeRangeBox);
            this.tabPage1.Controls.Add(this.cryptoListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1661, 812);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Statystyki";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // timeRangeBox
            // 
            this.timeRangeBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.timeRangeBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.timeRangeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeRangeBox.FormattingEnabled = true;
            this.timeRangeBox.Items.AddRange(new object[] {
            "10 minut",
            "15 minut",
            "30 minut",
            "1 godzina",
            "24 godziny",
            "7 dni"});
            this.timeRangeBox.Location = new System.Drawing.Point(3, 786);
            this.timeRangeBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timeRangeBox.Name = "timeRangeBox";
            this.timeRangeBox.Size = new System.Drawing.Size(1655, 24);
            this.timeRangeBox.TabIndex = 6;
            this.timeRangeBox.SelectedIndexChanged += new System.EventHandler(this.timeRangeBox_SelectedIndexChanged);
            // 
            // cryptoListView
            // 
            this.cryptoListView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.cryptoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nazwa,
            this.CenaUSD,
            this.CenaBTC,
            this.Wolumen,
            this.Zmiana1,
            this.Zmiana2,
            this.Zmiana3,
            this.ZmianaWolumen,
            this.Trend,
            this.Pompa,
            this.Ranking,
            this.Balans});
            this.cryptoListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryptoListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cryptoListView.FullRowSelect = true;
            this.cryptoListView.GridLines = true;
            this.cryptoListView.Location = new System.Drawing.Point(3, 2);
            this.cryptoListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cryptoListView.MultiSelect = false;
            this.cryptoListView.Name = "cryptoListView";
            this.cryptoListView.Size = new System.Drawing.Size(1655, 808);
            this.cryptoListView.TabIndex = 5;
            this.cryptoListView.UseCompatibleStateImageBehavior = false;
            this.cryptoListView.View = System.Windows.Forms.View.Details;
            this.cryptoListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.cryptoListView_ColumnClick);
            this.cryptoListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cryptoListView_MouseDoubleClick);
            // 
            // Nazwa
            // 
            this.Nazwa.Text = "Nazwa";
            this.Nazwa.Width = 45;
            // 
            // CenaUSD
            // 
            this.CenaUSD.Text = "Cena USD";
            this.CenaUSD.Width = 63;
            // 
            // CenaBTC
            // 
            this.CenaBTC.Text = "Cena BTC";
            this.CenaBTC.Width = 61;
            // 
            // Wolumen
            // 
            this.Wolumen.Text = "Wolumen USD";
            this.Wolumen.Width = 83;
            // 
            // Zmiana1
            // 
            this.Zmiana1.Text = "Zmiana (1h)";
            this.Zmiana1.Width = 68;
            // 
            // Zmiana2
            // 
            this.Zmiana2.Text = "Zmiana (24h)";
            this.Zmiana2.Width = 74;
            // 
            // Zmiana3
            // 
            this.Zmiana3.Text = "Zmiana 7d";
            this.Zmiana3.Width = 62;
            // 
            // ZmianaWolumen
            // 
            this.ZmianaWolumen.Text = "Zmiana Wolumenu";
            this.ZmianaWolumen.Width = 101;
            // 
            // Trend
            // 
            this.Trend.Text = "Trend";
            this.Trend.Width = 40;
            // 
            // Pompa
            // 
            this.Pompa.Text = "Pompa";
            this.Pompa.Width = 45;
            // 
            // Ranking
            // 
            this.Ranking.Text = "Ranking";
            this.Ranking.Width = 484;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rulesList);
            this.tabPage2.Controls.Add(this.usunButton);
            this.tabPage2.Controls.Add(this.dodajButton);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.wartoscBox);
            this.tabPage2.Controls.Add(this.warunekLista);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.monitorLista);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.walutyLista);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1543, 684);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Powiadomienia";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rulesList
            // 
            this.rulesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.cryptoName,
            this.monitorName,
            this.ruleName,
            this.valueName});
            this.rulesList.FullRowSelect = true;
            this.rulesList.GridLines = true;
            this.rulesList.Location = new System.Drawing.Point(8, 6);
            this.rulesList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rulesList.MultiSelect = false;
            this.rulesList.Name = "rulesList";
            this.rulesList.Size = new System.Drawing.Size(925, 656);
            this.rulesList.TabIndex = 10;
            this.rulesList.UseCompatibleStateImageBehavior = false;
            this.rulesList.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // cryptoName
            // 
            this.cryptoName.Text = "Nazwa waluty";
            this.cryptoName.Width = 185;
            // 
            // monitorName
            // 
            this.monitorName.Text = "Monitorowana wartość";
            this.monitorName.Width = 161;
            // 
            // ruleName
            // 
            this.ruleName.Text = "Warunek";
            this.ruleName.Width = 102;
            // 
            // valueName
            // 
            this.valueName.Text = "Wartość";
            this.valueName.Width = 169;
            // 
            // usunButton
            // 
            this.usunButton.Location = new System.Drawing.Point(1123, 208);
            this.usunButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usunButton.Name = "usunButton";
            this.usunButton.Size = new System.Drawing.Size(133, 30);
            this.usunButton.TabIndex = 9;
            this.usunButton.Text = "Usuń";
            this.usunButton.UseVisualStyleBackColor = true;
            this.usunButton.Click += new System.EventHandler(this.usunButton_Click);
            // 
            // dodajButton
            // 
            this.dodajButton.Location = new System.Drawing.Point(959, 208);
            this.dodajButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(133, 30);
            this.dodajButton.TabIndex = 8;
            this.dodajButton.Text = "Dodaj";
            this.dodajButton.UseVisualStyleBackColor = true;
            this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1044, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Wartość:";
            // 
            // wartoscBox
            // 
            this.wartoscBox.Location = new System.Drawing.Point(1123, 140);
            this.wartoscBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wartoscBox.Name = "wartoscBox";
            this.wartoscBox.Size = new System.Drawing.Size(183, 22);
            this.wartoscBox.TabIndex = 6;
            // 
            // warunekLista
            // 
            this.warunekLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warunekLista.FormattingEnabled = true;
            this.warunekLista.Items.AddRange(new object[] {
            "<=",
            ">="});
            this.warunekLista.Location = new System.Drawing.Point(1123, 98);
            this.warunekLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.warunekLista.Name = "warunekLista";
            this.warunekLista.Size = new System.Drawing.Size(183, 24);
            this.warunekLista.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1039, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Warunek:";
            // 
            // monitorLista
            // 
            this.monitorLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monitorLista.FormattingEnabled = true;
            this.monitorLista.Items.AddRange(new object[] {
            "Cena USD",
            "Cena BTC",
            "Wolumen",
            "Zmiana ceny 1h",
            "Zmiana ceny 24h",
            "Zmiana ceny 7d",
            "Zmiana wolumenu"});
            this.monitorLista.Location = new System.Drawing.Point(1123, 57);
            this.monitorLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.monitorLista.Name = "monitorLista";
            this.monitorLista.Size = new System.Drawing.Size(183, 24);
            this.monitorLista.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(955, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Monitorowana wartość:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1052, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Waluta:";
            // 
            // walutyLista
            // 
            this.walutyLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.walutyLista.FormattingEnabled = true;
            this.walutyLista.Location = new System.Drawing.Point(1123, 15);
            this.walutyLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.walutyLista.Name = "walutyLista";
            this.walutyLista.Size = new System.Drawing.Size(183, 24);
            this.walutyLista.TabIndex = 0;
            // 
            // Balans
            // 
            this.Balans.Text = "Balans";
            // 
            // CryptoStatsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1669, 841);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CryptoStatsMain";
            this.Text = "Crypto Stats";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer downloadTime;
        private System.Windows.Forms.Timer refreshTime;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox timeRangeBox;
        private System.Windows.Forms.ListView cryptoListView;
        private System.Windows.Forms.ColumnHeader Nazwa;
        private System.Windows.Forms.ColumnHeader CenaUSD;
        private System.Windows.Forms.ColumnHeader CenaBTC;
        private System.Windows.Forms.ColumnHeader Wolumen;
        private System.Windows.Forms.ColumnHeader Zmiana1;
        private System.Windows.Forms.ColumnHeader Zmiana2;
        private System.Windows.Forms.ColumnHeader Zmiana3;
        private System.Windows.Forms.ColumnHeader ZmianaWolumen;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox monitorLista;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox walutyLista;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox wartoscBox;
        private System.Windows.Forms.ComboBox warunekLista;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button usunButton;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.ListView rulesList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader cryptoName;
        private System.Windows.Forms.ColumnHeader monitorName;
        private System.Windows.Forms.ColumnHeader ruleName;
        private System.Windows.Forms.ColumnHeader valueName;
        private System.Windows.Forms.ColumnHeader Trend;
        private System.Windows.Forms.ColumnHeader Pompa;
        private System.Windows.Forms.ColumnHeader Ranking;
        private System.Windows.Forms.ColumnHeader Balans;
    }
}

