using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktu16_5
{ 
    class Program
    {

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu16-5\ktu16-5\salys.txt");
            int saliuSkaicius = Convert.ToInt32(lines[0]);
            Salys[] salys = new Salys[saliuSkaicius];
            for (int i = 0; i < saliuSkaicius; i++)
            {
                string eilute = lines[i + 1];
                string[] eile = eilute.Split(' ');
                string santrumpa = eile[0];
                string[] pilnasPav = new string[eile.Length - 1];
                for (int j = 0; j < eile.Length - 1; j++)
                {
                    pilnasPav[j] = eile[j + 1];
                }
                string pavadinimas = string.Join(" ", pilnasPav);
                salys[i] = new Salys(santrumpa, pavadinimas);
            }

            string[] lines2 = System.IO.File.ReadAllLines(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu16-5\ktu16-5\plaukikai.txt");
            Plaukikai[] plaukikai = new Plaukikai[lines2.Length];
            for (int i = 0; i < lines2.Length; i++)
            {
                string eilute = lines2[i];
                string[] eile = eilute.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                string vardas = eile[0];
                string pavarde = eile[1];
                string salis = eile[2];
                string laikas = eile[3];
                plaukikai[i] = new Plaukikai(vardas, pavarde, salis, laikas);
            }

            for (int i = 0; i < plaukikai.Length; i++)
            {
                String salis = plaukikai[i].salis;
                for (int j = 0; j < salys.Length; j++)
                {
                    if (salis == salys[j].santrumpa)
                    {
                        plaukikai[i].salis = salys[j].pavadinimas;
                        break;
                    }
                }
            }
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu16-5\ktu16-5\galutinis_sarasas.txt"))
            {
                foreach (Plaukikai plauk in plaukikai)
                {
                    file.WriteLine(plauk.vardas+" "+plauk.pavarde + " " + plauk.salis + " " + plauk.laikas);
                }
                

            }
        }
    }
}
