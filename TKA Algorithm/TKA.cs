using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKA_Algorithm
{
    public class TKA
    {
        public double W1 { get; set; }
        public double W2 { get; set; }
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double EsikDeger { get; set; }
        public double OgrenmeKatsayi { get; set; }
        public double BeklenenDeger { get; set; }
        public double? LastW1 { get; set; }
        public double? LastW2 { get; set; }
        public double? Cikti { get; set; }


        public TKA TKA_Hesapla(TKA tka)
        {
            //TKA tka = new TKA
            //{
            //    W1 = this.W1,
            //    W2 = this.W2,
            //    X1 = this.X1,
            //    X2 = this.X2,
            //    EsikDeger = this.EsikDeger,
            //    OgrenmeKatsayi = this.OgrenmeKatsayi,
            //    BeklenenDeger = this.BeklenenDeger
            //};

            TKA resultTKA = new TKA
            {
                W1 = tka.W1,
                W2 = tka.W2,
                X1 = tka.X1,
                X2 = tka.X2,
                EsikDeger = tka.EsikDeger,
                OgrenmeKatsayi = tka.OgrenmeKatsayi,
                BeklenenDeger = tka.BeklenenDeger,
                LastW1 = tka.LastW1,
                LastW2 = tka.LastW2,
                Cikti = tka.Cikti,
            };

            double net;
            int adimSayisi = 1;

            while (true)
            {
                Console.WriteLine(adimSayisi + ". Adım");
                net = (resultTKA.W1 * resultTKA.X1) + (resultTKA.W2 * resultTKA.X2);
                resultTKA.Cikti = CiktiHesapla(net, resultTKA.EsikDeger);

                Console.WriteLine(resultTKA);

                if (resultTKA.Cikti >= resultTKA.BeklenenDeger - (resultTKA.BeklenenDeger * 0.1) && resultTKA.Cikti <= resultTKA.BeklenenDeger + (resultTKA.BeklenenDeger * 0.1))
                {
                    resultTKA.LastW1 = resultTKA.W1;
                    resultTKA.LastW2 = resultTKA.W2;
                    resultTKA.Cikti = resultTKA.Cikti;

                    return resultTKA;
                }

                if (resultTKA.Cikti > resultTKA.BeklenenDeger)
                {
                    resultTKA.W1 = resultTKA.W1 - (resultTKA.OgrenmeKatsayi * resultTKA.X1);
                }

                if (resultTKA.Cikti < resultTKA.BeklenenDeger)
                {
                    resultTKA.W1 = resultTKA.W1 + (resultTKA.OgrenmeKatsayi * resultTKA.X1);
                }


            }



        }

        private double CiktiHesapla(double net, double esikDeger)
        {
            if (net > esikDeger)
            {
                return 1;
            }
            return 0;
        }
    }
}
