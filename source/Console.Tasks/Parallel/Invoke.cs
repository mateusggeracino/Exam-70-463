using System.Threading;

namespace Console.Tasks.Parallel
{
    public class Invoke
    {
        public static void Execute()
        {
            /*
             * A classe Parallel pode ser encontrada na biblioteca  --System.Threading.Tasks
             * O método --Invoke, pode receber N parametros delegates.
             * Ele não executa em uma ordem especifica e não espera um método terminar para começar o outro. Executando assim cada todos os métodos a medida que os núcleos do processador foram liberados.
             * Para cada delegate passado por parâmetro ele cria uma Task e passar para a linha seguinte, apenas, após a executação de todos os métodos.
             * Abaixo os delegates passados por parâmetro funcionam apenas para métodos void. Caso queira passar um método que retorne algo, é necessário usar lambda expression
             */
            System.Threading.Tasks.Parallel.Invoke(Task1, Task2);

            //Com método que retorna valor e passa valor por parâmetro
            System.Threading.Tasks.Parallel.Invoke(Task1, Task2, () => Task3(true));

            //Descomente o código abaixo e veja que o mesmo ainda é funcional
            //System.Threading.Tasks.Parallel.Invoke(Task1, Task2, Task2, Task2, Task2, Task2, Task2, Task2, Task2, Task2, Task2, Task2, Task2, Task2, Task2, Task2, Task2, Task2);
            System.Console.WriteLine("Finish processing.");
        }

        /// <summary>
        /// Método que simula a execução de uma task e aguarda 2 segundos para finalizar
        /// </summary>
        private static void Task1()
        {
            System.Console.WriteLine("Task 1 starting");
            Thread.Sleep(2000);
            System.Console.WriteLine("Task 1 ending");
        }

        /// <summary>
        /// Método que simula a execução de uma task e aguarda 1 segundos para finalizar
        /// </summary>
        private static void Task2()
        {
            System.Console.WriteLine("Task 2 starting");
            Thread.Sleep(1000);
            System.Console.WriteLine("Task 2 ending");
        }

        private static bool Task3(bool test)
        {
            System.Console.WriteLine("Task 2 starting");
            Thread.Sleep(1000);
            System.Console.WriteLine("Task 2 ending");

            return test;
        }
    }
}