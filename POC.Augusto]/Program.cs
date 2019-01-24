using Ninject;
using System;
using Viajanet.SOLID.Avianca;
using Viajanet.SOLID.Azul.Domain;
using Viajanet.SOLID.Domain.Interfaces;
using Viajanet.SOLID.Domain.Interfaces.ExternalServices;
using Viajanet.SOLID.Domain.Service;
using Viajanet.SOLID.Gol.Domain;
using Viajanet.SOLID.Latam.DTO;
using Viajanet.SOLID.Passaredo.DTO;

namespace POC.Augusto_
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<ISearchFlights>().To<SearchFlightsAvianca>().InSingletonScope().Named("Avianca").WithConstructorArgument(@"C:\Users\apcarli\source\repos\ProjectSOLID\Viajanet.SOLID.Avianca\DTO\Repository\RespositoryAvianca.json");
            kernel.Bind<ISearchFlights>().To<SearchFlightsAzul>().InSingletonScope().Named("Azul").WithConstructorArgument(@"C:\Users\apcarli\source\repos\ProjectSOLID\Viajanet.SOLID.Azul\DTO\Repository\RepositoryAzul.json");
            kernel.Bind<ISearchFlights>().To<SearchFlightsGol>().InSingletonScope().Named("Gol").WithConstructorArgument(@"C:\Users\apcarli\source\repos\ProjectSOLID\Viajanet.SOLID.Gol\DTO\Repository\RepositoryGol.json");
            kernel.Bind<ISearchFlights>().To<SearchFlightsLatam>().InSingletonScope().Named("Latam").WithConstructorArgument(@"C:\Users\apcarli\source\repos\ProjectSOLID\Viajanet.SOLID.Latam\DTO\Repository\RepositoryLatam.json");
            kernel.Bind<ISearchFlights>().To<SearchFlightsPassaredo>().InSingletonScope().Named("Passaredo").WithConstructorArgument(@"C:\Users\apcarli\source\repos\ProjectSOLID\Viajanet.SOLID.Passaredo\DTO\Repository\RepositoryPassaredo.json");
            kernel.Bind<ISearchRecomendationService>().To<SearchRecomendationService>().InSingletonScope();

            Menu(kernel);
        }

        private static void Menu(IKernel kernel)
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

            Cases(kernel, cont, origem, destino);
        }

        private static void Cases(IKernel kernel, int cont, string origem, string destino)
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

                    var list = kernel.GetAll(typeof(ISearchFlights));
                    kernel.Bind<IValidationRecomendationService>().To<ValidationRecomendationService>();

                    var search = kernel.Get<ISearchRecomendationService>();
                    search.Search(origem, destino);

                    Console.WriteLine("Aperte ENTER para selecionar uma nova opção");
                    Console.ReadKey();
                    Console.Clear();
                    Menu(kernel);
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
                    Cases(kernel, 1, origem, destino);
                    break;
            }
        }
    }
}
