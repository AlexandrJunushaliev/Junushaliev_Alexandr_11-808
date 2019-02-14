using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    public class AccountingModel : ModelBase
    {
        private double price;
        public double Price//цена за ночь
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0) throw new ArgumentException();//если цена за ночь меньше 0, то ошибка 
                else
                {
                    price = value;
                    Notify(nameof(Price));
                    ChangeTotal();
                }
            }
        }

        private int nightsCount;
        public int NightsCount//колчество ночей
        {
            get
            {
                return nightsCount;
            }
            set
            {
                if (!(value > 0)) throw new ArgumentException();//если ночь меньше 0, то ошибка
                else
                {
                    nightsCount = value;
                    Notify(nameof(NightsCount));
                    ChangeTotal();
                }

            }
        }

        private double discount;
        public double Discount//скидка
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
                if (discount > 100) throw new ArgumentException();//если скидка больше 100%, то ошибка
                Notify(nameof(Discount));
                ChangeTotal();
            }
        }

        private double total;
        public double Total//итоговая стоимость
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                Notify(nameof(Total));
                discount = 100 - (total * 100) / (price * nightsCount);//пересчет скидки, если изменяется итоговая цена
                if (discount > 100) throw new ArgumentException();//ошибка, если скидка получается больше 100%
                Notify(nameof(Discount));
            }
        }

        private void ChangeTotal()//обновлять тотал, если меняется цена за ночь, количество ночей или скидка
        {
            total = price * nightsCount * (1 - discount / 100);
            Notify(nameof(Total));
        }
    }
}
