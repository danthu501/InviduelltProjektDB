using InviduelltProjektDB.Models;
using System;
using System.Linq;
using System.Data;
using Microsoft.Data.SqlClient;


namespace InviduelltProjektDB
{
    class Program
    {
        static void Main(string[] args)
        {

            var Context = new IndividuelltDatabasprojektContext();

            bool menybool = true;

            while (menybool)
            {

                Console.WriteLine("Hej Välkommen till Skolans system");
                Console.WriteLine();
                Console.WriteLine("Var god ange en siffra i menyn");
                Console.WriteLine();
                Console.WriteLine("[1] Vissar hur många so jobbar på avdelningar");
                Console.WriteLine("[2] Visa information om alla elever");
                Console.WriteLine("[3] Visa en lista på alla aktiva kurser");

                int UserInput;
                Int32.TryParse(Console.ReadLine(), out UserInput);


                switch (UserInput)
                {
                    case 1:

                        EmployeesDepartment();


                        break;


                    case 2:


                        var Elever = from Elev in Context.Elev
                                     join Klass in Context.Klass on Elev.Klass equals Klass.KlassId
                                     join ElevBetyg in Context.ElevBetyg on Elev.ElevId equals ElevBetyg.ElevId
                                     join Betyg in Context.Betyg on ElevBetyg.BetygId equals Betyg.BetygId
                                     select new { ElevId = Elev.ElevId, FörNamn = Elev.FörNamn, EfterNamn = Elev.EfterNamn, Personnummer = Elev.Personnummer, KlassNamn = Klass.KlassNamn, };


                        foreach (var item in Elever)
                        {
                          
                            string FullName = item.FörNamn + " " + item.EfterNamn;
                            Console.WriteLine("ElevId: " + item.ElevId + "\t Namn: " + FullName + "\t Personnummer: " + item.Personnummer + "\t KlassNamn: " + item.KlassNamn);
                        }
                        

                        break;

                    case 3:
                        var AktivaKurser = from Kurs in Context.Kurs
                                           where Kurs.KursSlutDatum > DateTime.Today
                                           select Kurs;
                        foreach (var item in AktivaKurser)
                        {
                            Console.WriteLine(item.KursNamn + " Kursen Avslutas: " + item.KursSlutDatum);
                        }


                        break;

                    default:
                        Console.WriteLine("Var god ange en siffra mellan 1 och 3");
                        break;
                }

                Console.ReadKey();

            }


        }
        public static void EmployeesDepartment()
        {

            SqlConnection sqlCon1 = new SqlConnection(@"Data Source = DESKTOP-6TSF82P; Initial Catalog = IndividuelltDatabasprojekt; Integrated Security = True");
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from AvdelningAnställda", sqlCon1);//Uses a stored procedure with the name "AvdelningAnställda"
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);

            foreach (DataRow r in dtbl.Rows)
            {
             
                Console.Write(r["AvdelningsNamn"] + "\t");
                if (r["AvdelningsNamn"].ToString().Count() <= 16)
                {
                    Console.Write("\t");
                }
                Console.Write(" Antal anställda ");
                Console.WriteLine(r["Antal Anställda"]);

            }
            Console.ReadKey();

        }


    }
}
