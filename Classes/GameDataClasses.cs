using System.Collections;
using System.Diagnostics;

namespace GBF_Never_Buddy.Classes
{
    public class GameDataClasses
    {
        public class Character
        {
            public string name;
            public string series;
            public string element;
            public string image;
            public string link;

            public Character(string name, string element, string series, string image, string link)
            {
                this.name = name;
                this.element = element;
                this.series = series;
                this.image = image;
                this.link = link;
            }
        }

        public class GachaCharacterDetails
        {
            int id;
            public string name;
            public string image;
            public string link;
            public int refId;
            public string element;
            public string series;
            public string desc { get; set; }

            public GachaCharacterDetails(int id, string name, string image, string link, int rid, string element, string series)
            {   
                this.id = id;   
                this.name = name;
                this.image = image;
                this.link = link;
                this.refId = rid;
                this.element = element;
                this.series = series;
                desc = string.Empty;
            }

          
        }

        public class WeaponList
        {
            public string weaponName;

            public string weaponLink;

            public string weaponElement;

            public string weaponImage;

            public WeaponList(string weaponName, string weaponLink, string element, string weaponImage)
            {
                this.weaponName = weaponName;
                this.weaponLink = weaponLink;
                this.weaponElement = element;
                this.weaponImage = weaponImage;
            }
        }

    
        public class Summon
        {
            public string name;
            public string series;
            public string element;
            public string image;
            public string link;

            public Summon(string name, string series, string element, string image, string link)
            {
                this.name = name;
                this.series = series;
                this.element = element;
                this.image = image;
                this.link = link;
            }
        }

        public class GachaTable
        {
            public int id;
            public int drawId;
            public int crystalsUsed;
            public string date;

            public GachaTable(int id, int drawId, int crystalsUsed, string date)
            {
                this.id = id;
                this.drawId = drawId;
                this.crystalsUsed = crystalsUsed;
                this.date = date;
            }
        }

        public class GachaDetails
        {
            public int id;
            public int drawId;
            public string characters;
            public string summons;
            public int drawNumber;
            public int crystalsUsed;

            public GachaDetails(int id, int drawId, string characters, string summons, int drawNumber, int crystalsUsed)
            {
                this.id = id;
                this.drawId = drawId;
                this.characters = characters;
                this.summons = summons;
                this.crystalsUsed = crystalsUsed;
                this.drawNumber = drawNumber;
            }
        }

        public class ItemComparer : IComparer
        {
            public int Column { get; set; }

            public SortOrder Order { get; set; }
            private CaseInsensitiveComparer ObjectCompare;

            public ItemComparer()
            {
                Order = SortOrder.None;
                ObjectCompare = new CaseInsensitiveComparer();
            }
            public int Compare(object x, object y)
            {
                int result;
                ListViewItem listviewX, listviewY;

                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;
                result = ObjectCompare.Compare(listviewX.SubItems[Column].Text, listviewY.SubItems[Column].Text);
                var xStr = listviewX.SubItems[Column].Text;
                var yStr = listviewY.SubItems[Column].Text;
                int xValue = 0;
                int yValue = 0;
                DateTime xTime;
                DateTime yTime;
                DateTime.TryParse(xStr, out xTime);
                DateTime.TryParse(yStr, out yTime);
                if (xTime != null && yTime != null)
                {
                    result = xTime.CompareTo(yTime);
                }
                int.TryParse(xStr, System.Globalization.NumberStyles.Currency, null, out xValue);
                int.TryParse(yStr, System.Globalization.NumberStyles.Currency, null, out yValue);
                if (yValue != 0 && xValue != 0)
                {
                    Debug.WriteLine($"Number, comparing: {xValue} to {yValue}");
                    result = xValue - yValue;
                }

                if (Order == SortOrder.Descending)
                {
                    return (-result);
                }
                else if (Order == SortOrder.Ascending)
                {
                    return result;
                }
                return 0;
            }
            public int SortColumn
            {
                set
                {
                    Column = value;
                }
                get
                {
                    return Column;
                }
            }

            public SortOrder OrderCol
            {
                set
                {
                    Order = value;
                }
                get
                {
                    return Order;
                }
            }
        }
    }
}
