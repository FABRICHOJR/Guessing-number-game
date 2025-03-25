class Calculadora
{
    static bool JugarDeNuevo()
    {
        string respuesta = "";
        do
        {
            Console.WriteLine("\n¿Queres jugar de nuevo? (SI/NO): ");
            respuesta = Console.ReadLine()!.ToUpper().Trim();
        } while (respuesta != "SI" && respuesta != "NO");
        return respuesta == "SI";
    }

    static void Main()
    {
        Random random = new Random();
        int minRandomNum = 1;
        int maxRandomNum = 50;
        int guessUsuarioNum, intentos = 0;
        int intentosMaximos = 5;
        bool jugarDeNuevo = true;

        Console.WriteLine("GUESSING NUMBER GAME");

        while (jugarDeNuevo)
        {
            intentos = 0;
            int randomPCNumber = random.Next(minRandomNum, maxRandomNum + 1);

            while (intentos < intentosMaximos)
            {
                Console.WriteLine($"Intentos restantes: {intentosMaximos - intentos}");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Ingresa un número entre {minRandomNum} y {maxRandomNum}: ");
                while (!int.TryParse(Console.ReadLine(), out guessUsuarioNum))
                {
                    Console.WriteLine("¡Error! No es un número válido. Intenta de nuevo: ");
                }
                intentos++;

                if (guessUsuarioNum == randomPCNumber)
                {
                    Console.WriteLine("¡Felicidades, ganaste!");
                    break;
                }
                else if (guessUsuarioNum > randomPCNumber && intentos < intentosMaximos)
                {
                    Console.WriteLine($"{guessUsuarioNum} NO. ¡Prueba con un número más bajo!");
                }
                else if (guessUsuarioNum < randomPCNumber && intentos < intentosMaximos)

                {
                    Console.WriteLine($"{guessUsuarioNum} NO. ¡Prueba con un número más alto!");
                }

                if (intentos == intentosMaximos)
                {
                    Console.WriteLine($"¡Se acabaron los intentos! El número era {randomPCNumber}");
                    break;
                }
            }
            jugarDeNuevo = JugarDeNuevo();
        }
        Console.WriteLine("¡Gracias por jugar!");
    }
}
