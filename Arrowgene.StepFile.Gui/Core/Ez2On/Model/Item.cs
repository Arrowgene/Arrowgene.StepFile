using System;

namespace Arrowgene.StepFile.Core.Asset.Ez2On.Model
{
    [Serializable]
    public class Item
    {
        public Item()
        {
            Id = -1;
        }

        public string Image { get; set; }
        public int a { get; set; }
        public string Name { get; set; }
        public int b { get; set; }
        public int Duration { get; set; }
        public int Coins { get; set; }
        public int Level { get; set; }

        /// <summary>
        /// 경험치
        /// </summary>
        public int ExpPlus { get; set; }

        public int CoinPlus { get; set; }
        public int HpPlus { get; set; }

        /// <summary>
        /// 회복력
        /// </summary>
        public int ResiliencePlus { get; set; }

        /// <summary>
        /// 방어력
        /// </summary>
        public int DefensePlus { get; set; }

        public int k { get; set; }
        public int l { get; set; }
        public int m { get; set; }
        public int n { get; set; }
        public int o { get; set; }
        public string Effect { get; set; }
        public int Id { get; set; }
        public int q { get; set; }
        public ItemType Type { get; set; }
        public int s { get; set; }
        public int t { get; set; }
        public int u { get; set; }
        
        
        public int v { get; set; }
        public int w { get; set; }
        public int x { get; set; }
    }
}