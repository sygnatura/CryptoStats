using System;
using System.Collections;
using System.Windows.Forms;

namespace CryptoStats
{
    internal class ListViewItemComparer : IComparer
    {
        private int column;
        private SortOrder sorting;

        public ListViewItemComparer(int column)
        {
            this.column = column;

        }

        public ListViewItemComparer(int column, SortOrder sorting) : this(column)
        {
            this.sorting = sorting;
        }

        public int Compare(object x, object y)
        {
            int returnVal = -1;

            switch(column)
            {
                // jezeli to kolumna z nazwa to porownaj jako string
                case 0:
                    returnVal = String.Compare(((ListViewItem)x).SubItems[column].Text, ((ListViewItem)y).SubItems[column].Text);
                    break;
                    // wolumen usd
                case 3:
                    long value1 = Convert.ToInt64(((ListViewItem)x).SubItems[column].Text.Replace(",", ""));
                    long value2 = Convert.ToInt64(((ListViewItem)y).SubItems[column].Text.Replace(",", ""));
                    if (value1 > value2) returnVal = 1;
                    else if (value1 < value2) returnVal = -1;
                    else returnVal = 0;
                    break;
                //trend
                case 8:
                    int value1i = Convert.ToInt32(((ListViewItem)x).SubItems[column].Text);
                    int value2i = Convert.ToInt32(((ListViewItem)y).SubItems[column].Text);
                    if (value1i > value2i) returnVal = 1;
                    else if (value1i < value2i) returnVal = -1;
                    else returnVal = 0;
                    break;
                //pompa
                case 9:
                    double value1dd = Convert.ToDouble(((ListViewItem)x).SubItems[column].Text);
                    double value2dd = Convert.ToDouble(((ListViewItem)y).SubItems[column].Text);
                    if (value1dd > value2dd) returnVal = 1;
                    else if (value1dd < value2dd) returnVal = -1;
                    else returnVal = 0;
                    break;
                case 10:
                    value1i = Convert.ToInt32(((ListViewItem)x).SubItems[column].Text);
                    value2i = Convert.ToInt32(((ListViewItem)y).SubItems[column].Text);
                    if (value1i > value2i) returnVal = 1;
                    else if (value1i < value2i) returnVal = -1;
                    else returnVal = 0;
                    break;

                //domyslna
                default:
                    decimal value1d = Convert.ToDecimal(((ListViewItem)x).SubItems[column].Text.Replace(" %", ""));
                    decimal value2d = Convert.ToDecimal(((ListViewItem)y).SubItems[column].Text.Replace(" %", ""));
                    returnVal = Decimal.Compare(value1d, value2d);
                    break;
            }

            

            // Determine whether the sort order is descending.
            if (sorting == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
    }
}