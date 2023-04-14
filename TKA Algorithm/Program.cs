
TKA tkaMethods = new TKA();

TKA ornek1 = new TKA
{
    // Örnek değerleri
    X1_1 = 1,
    X1_2 = 0,
    BeklenenDeger1 = 1, // Portakal

    X2_1 = 0,
    X2_2 = 1,
    BeklenenDeger2 = 0, // Elma


    // İterasyon değerleri
    W1 = 1,
    W2 = 2,
    EsikDeger = -1,
    OgrenmeKatsayi = 0.5

};



tkaMethods.TKA_Hesapla(ornek1);




public class TKA
{
    public double W1 { get; set; }
    public double W2 { get; set; }
    public double X1_1 { get; set; }
    public double X1_2 { get; set; }
    public double X2_1 { get; set; }
    public double X2_2 { get; set; }
    public double EsikDeger { get; set; }
    public double OgrenmeKatsayi { get; set; }
    public double BeklenenDeger1 { get; set; }
    public double BeklenenDeger2 { get; set; }
    public double? LastW1 { get; set; }
    public double? LastW2 { get; set; }
    public double? Cikti1 { get; set; }
    public double? Cikti2 { get; set; }



    public TKA TKA_Hesapla(TKA tka)
    {


        TKA resultTKA = new TKA
        {
            W1 = tka.W1,
            W2 = tka.W2,

            X1_1 = tka.X1_1,
            X1_2 = tka.X1_2,
            X2_1 = tka.X2_1,
            X2_2 = tka.X2_2,

            EsikDeger = tka.EsikDeger,
            OgrenmeKatsayi = tka.OgrenmeKatsayi,

            BeklenenDeger1 = tka.BeklenenDeger1,
            BeklenenDeger2 = tka.BeklenenDeger2,

            LastW1 = tka.W1,
            LastW2 = tka.W2,

            Cikti1 = tka.Cikti1,
            Cikti2 = tka.Cikti2,

        };

        double net1 = 0;
        double net2 = 0;
        int adimSayisi = 0;

        while (adimSayisi<20)
        {
            adimSayisi++;

            net1 = ((double)resultTKA.LastW1 * resultTKA.X1_1) + ((double)resultTKA.LastW2 * resultTKA.X1_2);
            resultTKA.Cikti1 = CiktiHesapla(net1, resultTKA.EsikDeger);



            if ((resultTKA.Cikti1 >= resultTKA.BeklenenDeger1 - (resultTKA.BeklenenDeger1 * 0.01) && resultTKA.Cikti1 <= resultTKA.BeklenenDeger1 + (resultTKA.BeklenenDeger1 * 0.01)) &&
                resultTKA.Cikti2 >= resultTKA.BeklenenDeger2 - (resultTKA.BeklenenDeger2 * 0.01) && resultTKA.Cikti2 <= resultTKA.BeklenenDeger2 + (resultTKA.BeklenenDeger2 * 0.01))
            {
                resultTKA.LastW1 = resultTKA.W1;
                resultTKA.LastW2 = resultTKA.W2;

                if (adimSayisi == 1)
                {
                    AdimlariYazdir(adimSayisi, net1, net2, resultTKA);
                }

                return resultTKA;

            }

            AdimlariYazdir(adimSayisi, net1, net2, resultTKA);



            if (resultTKA.Cikti1 > resultTKA.BeklenenDeger1)
            {
                resultTKA.LastW1 = resultTKA.LastW1 - (resultTKA.OgrenmeKatsayi * resultTKA.X1_1);
                resultTKA.LastW2 = resultTKA.LastW2 - (resultTKA.OgrenmeKatsayi * resultTKA.X1_2);

            }

            if (resultTKA.Cikti1 < resultTKA.BeklenenDeger1)
            {
                resultTKA.LastW1 = resultTKA.LastW1 + (resultTKA.OgrenmeKatsayi * resultTKA.X1_1);
                resultTKA.LastW2 = resultTKA.LastW2 + (resultTKA.OgrenmeKatsayi * resultTKA.X1_2);

            }

            adimSayisi++;


            net2 = ((double)resultTKA.LastW1 * resultTKA.X2_1) + ((double)resultTKA.LastW2 * resultTKA.X2_2);
            resultTKA.Cikti2 = CiktiHesapla(net2, resultTKA.EsikDeger);

            AdimlariYazdir(adimSayisi, net1, net2, resultTKA);

            if (resultTKA.Cikti2 > resultTKA.BeklenenDeger2)
            {
                resultTKA.LastW1 = resultTKA.LastW1 - (resultTKA.OgrenmeKatsayi * resultTKA.X2_1);
                resultTKA.LastW2 = resultTKA.LastW2 - (resultTKA.OgrenmeKatsayi * resultTKA.X2_2);

            }

            if (resultTKA.Cikti2 < resultTKA.BeklenenDeger1)
            {
                resultTKA.LastW1 = resultTKA.LastW1 + (resultTKA.OgrenmeKatsayi * resultTKA.X2_1);
                resultTKA.LastW2 = resultTKA.LastW2 + (resultTKA.OgrenmeKatsayi * resultTKA.X2_2);

            }

        }
        return resultTKA;

    }

    private double CiktiHesapla(double net, double esikDeger)
    {
        if (net > esikDeger)
        {
            return 1;
        }
        return 0;
    }

    private void AdimlariYazdir(int adimSayisi, double net1, double net2, TKA tka)
    {
        if (adimSayisi % 2 != 0)
        {
            Console.WriteLine(adimSayisi + ". İterasyon - 1.Örnek ağa gösterilir \n\n");
        }
        else
        {
            Console.WriteLine(adimSayisi + ". İterasyon - 2.Örnek ağa gösterilir \n\n");
        }

        Console.WriteLine("X1_1 : " + tka.X1_1);
        Console.WriteLine("X1_2 : " + tka.X1_2);
        Console.WriteLine("X2_1 : " + tka.X2_1);
        Console.WriteLine("X2_2 : " + tka.X2_2);

        Console.WriteLine("W1 : " + tka.LastW1);
        Console.WriteLine("W2 : " + tka.LastW2);

        Console.WriteLine("Eşik Değer : " + tka.EsikDeger);
        Console.WriteLine("Öğrenme Katsayısı : " + tka.OgrenmeKatsayi);

        Console.WriteLine("Çıktı-1 : " + tka.Cikti1);
        Console.WriteLine("Beklenen Değer-1 : " + tka.BeklenenDeger1);
        Console.WriteLine("Net-1 : " + net1);

        Console.WriteLine("Beklenen Değer-2 : " + tka.BeklenenDeger2);
        Console.WriteLine("Net-2 : " + net2);        
        Console.WriteLine("Çıktı-2 : " + tka.Cikti2);

        Console.WriteLine("\n");

    }
}
