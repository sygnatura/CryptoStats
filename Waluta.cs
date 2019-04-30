using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoStats
{
    class Waluta
    {
        [JsonProperty(PropertyName = "24h_volume_usd")]
        public string volume { get; set; }
        public string rank { get; set; }
        //public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string price_usd { get; set; }
        public string price_btc { get; set; }
        //public decimal market_cap_usd { get; set; }
        //public decimal available_supply { get; set; }
        public string available_supply { get; set; }
        public string percent_change_1h { get; set; }
        public string percent_change_24h { get; set; }
        public string percent_change_7d { get; set; }
        public long last_updated { get; set; }
        public double percent_volume { get; set; }
        public int trend { get; set; }
        public double pompa { get; set; }
        public int rank_diff = 0;
        public double balans;

        public void CalculateDiff(Waluta old)
        {
            CalculateVolumeDiff(old.volume);
            CalculateTrend(old.Get_price_usd());
            CalculatePomp(old.Get_price_usd());
            CalculateRank(old.rank);
        }

        public void CalculateBalans(Waluta main)
        {
            double mainSupply = main.Get_available_supply();
            double thisSupply = this.Get_available_supply();
            if(mainSupply > 0 && thisSupply > 0)
            {
                double priceBalans = (double) main.Get_price_usd() / (thisSupply / mainSupply);
                balans = Math.Round(priceBalans /(double) this.Get_price_usd(), 2);
                //balans = Math.Round(priceBalans);
            }
        }


        private void CalculateVolumeDiff(string volumeOld)
        {
            double volumeLongActual = 0;
            double volumeLongOld = 0;

            if (this.volume != null) volumeLongActual = Convert.ToDouble(this.volume);
            if (volumeOld != null) volumeLongOld = Convert.ToDouble(volumeOld);

            percent_volume = Math.Round(((volumeLongActual - volumeLongOld) / ((volumeLongActual + volumeLongOld) /2)) * 100, 2);
        }

        private void CalculatePomp(decimal priceOld)
        {
            pompa = 0;
            decimal percent_price = Math.Round(((Get_price_usd() - priceOld) / ((Get_price_usd() + priceOld) / 2)) * 100, 2);
            pompa = (double)percent_price * percent_volume;
            //if (percent_volume > 0 && percent_price > 0) pompa = (double) percent_price * percent_volume;
            if ((percent_volume < 0 || percent_price < 0) && pompa > 0) pompa *= -1;
            
        }

        private void CalculateRank(string rankOld)
        {
            int rankIntOld = getInt(rankOld);
            int rankIntActual = getInt(rank);

            rank_diff = rankIntOld - rankIntActual;
        }

        private void CalculateTrend(decimal priceOld)
        {
            trend = 0;
            if(price_usd != null)
            {
                if (Get_price_usd() > priceOld) trend = 1;
                else if (Get_price_usd() < priceOld) trend = -1;
            }
        }

        private double getDouble(string value)
        {
            double convert = 0;
            if (value != null) convert = Convert.ToDouble(value);
            return convert;
        }

        private int getInt(string value)
        {
            int convert = 0;
            if (value != null) convert = Convert.ToInt32(value);
            return convert;
        }


        private decimal getDecimal(string value)
        {
            decimal convert = 0;
            if (value != null) convert = Convert.ToDecimal(value);
            return convert;
        }

        public decimal Get_price_usd()
        {
            return getDecimal(price_usd);
        }

        public decimal Get_price_btc()
        {
            return getDecimal(price_btc);
        }

        public decimal Get_volume()
        {
            return getDecimal(volume);
        }

        public double Get_percent_change_1h()
        {
            return getDouble(percent_change_1h);
        }

        public double Get_percent_change_24h()
        {
            return Math.Round(getDouble(percent_change_24h), 2);
        }

        public double Get_percent_change_7d()
        {
            return Math.Round(getDouble(percent_change_7d), 2);
        }

        public double Get_available_supply()
        {
            if (available_supply != null && available_supply.Equals("null") == false)
            {
                return Math.Round(getDouble(available_supply), 2);
            }
            else return 0;
        }

    }
}
