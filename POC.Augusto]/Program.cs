using Ninject;
using System;
using Viajanet.SOLID.Avianca;
using Viajanet.SOLID.Azul.Domain;
using Viajanet.SOLID.Domain.Interfaces;
using Viajanet.SOLID.Domain.Interfaces.ExternalServices;
using Viajanet.SOLID.Domain.Service;
using Viajanet.SOLID.Gol;
using Viajanet.SOLID.Latam.DTO;
using Viajanet.SOLID.Passaredo.DTO;

namespace POC.Augusto_
{
    class Program
    {
        private static StandardKernel _kernel;

        static void Main(string[] args)
        {
            WarmUp();
            Menu();
        }


        private static void WarmUp()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<ISearchFlights>().To<SearchFlightsAvianca>().InSingletonScope().Named("Avianca").WithConstructorArgument("DTO/Repository/RespositoryAvianca.json");
            _kernel.Bind<ISearchFlights>().To<SearchFlightsAzul>().InSingletonScope().Named("Azul").WithConstructorArgument("DTO/Repository/RepositoryAzul.json");
            _kernel.Bind<ISearchFlights>().To<SearchFlightsGol>().InSingletonScope().Named("Gol").WithConstructorArgument(@"Infra/RepositoryGol.json");
            _kernel.Bind<ISearchFlights>().To<SearchFlightsLatam>().InSingletonScope().Named("Latam").WithConstructorArgument(@"DTO/Repository/RepositoryLatam.json");
            _kernel.Bind<ISearchFlights>().To<SearchFlightsPassaredo>().InSingletonScope().Named("Passaredo").WithConstructorArgument(@"DTO/Repository/RepositoryPassaredo.json");
            _kernel.Bind<IIataService>().To<IataService>();
            _kernel.Bind<ISearchRecomendationService>().To<SearchRecomendationService>().InSingletonScope();

        }

        private static void Menu()
        {
            int cont;
            string origem = "";
            string destino = "";

            Console.WriteLine("IATAS de Origem: CGH, GRU, VCP; \nIATAS Destino: GIG, CPV, ROR, NYC;\n");
            Console.WriteLine("Selecione uma das opções abaixo:\n");
            Console.WriteLine("01 - Pesquisa");
            Console.WriteLine("02 - Sair\n");

            int.TryParse(Console.ReadLine(), out cont);
            Console.WriteLine();
            Cases(cont, origem, destino);
        }

        private static void Cases(int cont, string origem, string destino)
        {
            switch (cont)
            {
                case 1:
                    Console.WriteLine("Qual Origem você deseja ?");
                    origem = Console.ReadLine();
                    origem = origem.ToUpper();
                    Console.WriteLine();

                    Console.WriteLine("Qual Destino você deseja ?");
                    destino = Console.ReadLine();
                    destino = destino.ToUpper();
                    Console.WriteLine();


                    var search = _kernel.Get<ISearchRecomendationService>();
                    var flightList = search.Search(origem, destino);

                    foreach (var item in flightList)
                    {
                        Console.WriteLine("\n" + item.Departure.IATA);
                        Console.WriteLine(item.Departure.Name);
                        Console.WriteLine(item.Arrival.IATA);
                        Console.WriteLine(item.Arrival.Name);
                        Console.WriteLine(item.Date);
                        Console.WriteLine(item.Source + "\n");
                    }

                    Console.WriteLine("Aperte ENTER para selecionar uma nova opção");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("\n\n\n*************************Até Logo*************************");
                    Console.ReadKey();
                    Environment.Exit(2);
                    break;

                default:
                    Console.WriteLine("OPS, aperte Enter para selecionar outra opção");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }
    }
}
