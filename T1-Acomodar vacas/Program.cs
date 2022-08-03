using System;
using System.Collections.Generic;
using System.Linq;

namespace T1_Acomodar_vacas
{




  public  class Program
    {


       



        static void Main(string[] args)
        {

            Camion[] camiones = new Camion[7];

            //Instanciamos 7 camiones
            for (int i = 0; i < 7; i++)
            {
                camiones[i] = new Camion();
            }

            List<Vaca> vacas = new List<Vaca>();

            vacas.Add(new Vaca() { Peso =114 });
            vacas.Add(new Vaca() { Peso = 121 });
            vacas.Add(new Vaca() { Peso =50 });
            vacas.Add(new Vaca() { Peso = 110});
            vacas.Add(new Vaca() { Peso = 210});
            vacas.Add(new Vaca() { Peso =89 });
            vacas.Add(new Vaca() { Peso = 172});
            vacas.Add(new Vaca() { Peso =100 });
            vacas.Add(new Vaca() { Peso =70 });
            vacas.Add(new Vaca() { Peso = 128});

            for (int i = 0; i < vacas.Count; i++)
            {
                if (vacas[i].Cargada == false)
                {
                    foreach (var camion in camiones)
                    {
                        if (camion.AddVaca(vacas[i]))
                        {
                            break;
                        }
                    }

                }

            }

            for (int i = 0; i < camiones.Length; i++)
            {
                if (camiones[i].CantidadDeVacasCargadas > 0)
                {
                    int index = 1;
                    Console.WriteLine($"El Camion {i+1}  tiene {camiones[i].CantidadDeVacasCargadas} vacas con un peso total de {camiones[i].PesoTotal()} Kilos");
                    foreach (var vaca in camiones[i].Vacas)
                    {
                        Console.WriteLine($"Vaca {index} con un peso de {vaca.Peso} kilos ");
                        index++;
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"El Camion {i+1} no esta cargado!");
                    Console.WriteLine();
                }
               
                

            }






            Console.WriteLine("Hello World!");
        }
    }



    public class Vaca
    {
       public int Peso { get; set; }
       public bool Cargada { get; set; }
    }

    public class Camion
    {
       public  List<Vaca> Vacas = new List<Vaca>();

        public int CantidadDeVacasCargadas => Vacas.Count;

        public int PesoTotal()
        {
           return Vacas.Sum(v => v.Peso);
        }

        public bool AddVaca(Vaca vaca)
        {
            if (Vacas.Count < 3)
            {
                if (PesoTotal() + vaca.Peso <= 300)
                {
                    vaca.Cargada = true;
                    Vacas.Add(vaca);
                    return true;
                }
                return false;
            }
            return false;
        }

    }
}
